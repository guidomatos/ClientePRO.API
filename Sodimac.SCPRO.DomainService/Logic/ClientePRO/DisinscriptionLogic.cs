using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Sodimac.SCPRO.Common.Error;
using Sodimac.SCPRO.DomainModel.Interface.ClientePRO;
using Sodimac.SCPRO.Model.ClientePRO;
using Sodimac.SCPRO.Model.DataTransferObject.ClientePRO;
using System;
using System.Threading.Tasks;
using Sodimac.SCPRO.DomainService.Core;
using System.IO;
using Sodimac.SCPRO.Common.Helper;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;

namespace Sodimac.SCPRO.DomainService.Logic.ClientePRO
{
    public class DisinscriptionLogic
    {
        private readonly IDisinscriptionRepository _disinscriptionRepository;
        private readonly IDisinscriptionEvidenceRepository _disinscriptionEvidenceRepository;
        private readonly IMapper _mapper;
        private readonly IRequestRepository _requestRepository;
        private readonly string _BlobContainerAccessKey;
        private readonly AppSettings _appSettings;

        public DisinscriptionLogic(
            IDisinscriptionRepository disinscriptionRepository,
            IDisinscriptionEvidenceRepository disinscriptionEvidenceRepository,
            IRequestRepository requestRepository,
            IMapper mapper
            ,IConfiguration configuration
            ,IOptions<AppSettings> appSettings
            )
        {
            _disinscriptionRepository = disinscriptionRepository;
            _disinscriptionEvidenceRepository = disinscriptionEvidenceRepository;
            _requestRepository = requestRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _BlobContainerAccessKey = configuration.GetConnectionString("BlobContainerAccessKey");
        }
        public async Task<DisinscriptionDto> AddDisinscription(DisinscriptionDto disinscriptionDto)
        {
            DisinscriptionDto response;

            try
            {
                var findDisinscription = _disinscriptionRepository.FindAsync(
                            x => x.SolicitudId == disinscriptionDto.SolicitudId && x.Activo
                        ).Result
                        ;

                if (findDisinscription == null)
                {

                    // Validamos si el socio está inscrito

                    var findSolicitud = _requestRepository.FindAsync(
                            x => x.SolicitudId == disinscriptionDto.SolicitudId && x.EstadoSolicitudId == 2 && x.Activo
                        ).Result;

                    if (findSolicitud != null)
                    {
                        // registra desinscripcion
                        var disinscription = _mapper.Map<Desinscripcion>(disinscriptionDto);
                        disinscription = await _disinscriptionRepository.AddDisinscription(disinscription);

                        // registra detalle de evidencias
                        List<DesinscripcionEvidencia> DesinscripcionEvidencias = new List<DesinscripcionEvidencia>();

                        try
                        {
                            foreach (var item in disinscriptionDto.DisinscriptionEvidences)
                            {
                                string UrlImagen = string.Empty;
                                if (item.EvidenciaImagen.Length != 0)
                                {
                                    var ContenedorAzure = _appSettings.EvidenceBlobContainer;
                                    var stream_Documento = new MemoryStream(item.EvidenciaImagen);
                                    var ruta_doc = await BlobStorageAzure.UploadFromStream(_BlobContainerAccessKey,
                                                                                            ContenedorAzure,
                                                                                            item.EvidenciaImagenNombre,
                                                                                            stream_Documento);
                                    if (ruta_doc != null)
                                    {
                                        UrlImagen = _appSettings.UrlAzureBlobContainer + ruta_doc.AbsolutePath;

                                        var desinscripcionEvidencia = _mapper.Map<DesinscripcionEvidencia>(item);
                                        desinscripcionEvidencia.DesinscripcionId = disinscription.DesinscripcionId;
                                        desinscripcionEvidencia.EvidenciaImagenUrl = UrlImagen;
                                        desinscripcionEvidencia.UsuarioRegistra = disinscription.UsuarioRegistra;
                                        desinscripcionEvidencia.FechaRegistra = DateTime.Now;
                                        DesinscripcionEvidencias.Add(desinscripcionEvidencia);

                                    }
                                }
                            }
                        } catch(StorageException)
                        {
                            await _disinscriptionRepository.Remove(disinscription);
                            throw;
                        }
                        catch (Exception)
                        {
                            await _disinscriptionRepository.Remove(disinscription);
                            throw;
                        }

                        await _disinscriptionEvidenceRepository.AddMassive(DesinscripcionEvidencias);

                        // actualiza estado de solicitud
                        findSolicitud.UsuarioModifica = disinscriptionDto.UsuarioRegistra;
                        findSolicitud.EstadoSolicitudId = 3; // Desinscrito
                        await _requestRepository.UpdateRequest(findSolicitud);


                        response = _mapper.Map<DisinscriptionDto>(disinscription);

                    } else {

                        string messageError = "No se pudo desinscribir socio.\nSocio no está inscrito";
                        response = new DisinscriptionDto() { Error = new ServiceException(messageError) };
                        response.Error.Code = "3";

                    }

                }
                else
                {

                    string messageError = "No se pudo desinscribir socio.\nSocio ya está desinscrito";
                    response = new DisinscriptionDto() { Error = new ServiceException(messageError) };
                    response.Error.Code = "2";

                }
            }
            catch (Exception e)
            {
                response = new DisinscriptionDto() { Error = new ServiceException(e.Message) };
                response.Error.Code = "0";
            }

            return response;
        }

    }
}
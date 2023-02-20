using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Sodimac.SCPRO.Common.Error;
using Sodimac.SCPRO.DomainModel.Interface.ClientePRO;
using Sodimac.SCPRO.DomainService.Core;
using Sodimac.SCPRO.DomainService.Interface.ClientePRO;
using Sodimac.SCPRO.DomainService.Logic.ClientePRO;
using Sodimac.SCPRO.Model.DataTransferObject.ClientePRO;
using System;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainService.Service.ClientePRO
{
    public class DisinscriptionService : IDisinscriptionService
    {
        private readonly DisinscriptionLogic _disinscriptionLogic;
        public DisinscriptionService(
            IDisinscriptionRepository disinscriptionRepository,
            IDisinscriptionEvidenceRepository disinscriptionEvidenceRepository,
            IRequestRepository requestRepository,
            IMapper mapper
            ,IConfiguration configuration
            ,IOptions<AppSettings> appSettings
            )
        {
            _disinscriptionLogic = new DisinscriptionLogic(disinscriptionRepository, disinscriptionEvidenceRepository, requestRepository, mapper, configuration, appSettings);
        }

        public async Task<DisinscriptionDto> AddDisinscription(DisinscriptionDto disinscriptionDto)
        {
            DisinscriptionDto response;
            try
            {
                response = await _disinscriptionLogic.AddDisinscription(disinscriptionDto);
            }
            catch (Exception e)
            {
                response = new DisinscriptionDto() { Error = new ServiceException(e.Message) };                
            }
            return response;
        }
    }
}
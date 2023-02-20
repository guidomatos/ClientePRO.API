using AutoMapper;
using Sodimac.SCPRO.Common.Error;
using Sodimac.SCPRO.DomainModel.Interface.ClientePRO;
using Sodimac.SCPRO.Model.ClientePRO;
using Sodimac.SCPRO.Model.DataTransferObject.ClientePRO;
using System;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainService.Logic.ClientePRO
{
    public class RequestLogic
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;

        public RequestLogic(
            IRequestRepository requestRepository,
            IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }
        public async Task<RequestDto> AddRequest(RequestDto requestDto)
        {
            RequestDto response;

            try
            {
                var findSolicitudByCliente = _requestRepository.FindAsync(
                            x => x.NumeroDocCliente.ToUpper().Equals(requestDto.NumeroDocCliente.ToUpper())
                        ).Result
                        ;

                if (findSolicitudByCliente == null)
                {
                    var request = _mapper.Map<Solicitud>(requestDto);
                    request = await _requestRepository.AddRequest(request);
                    response = _mapper.Map<RequestDto>(request);
                }
                else
                {
                    string messageError = "No se pudo enviar solicitud.\nUsted ya tiene una solicitud en proceso";
                    response = new RequestDto() { Error = new ServiceException(messageError) };
                    response.Error.Code = "2";
                }
            }
            catch (Exception e)
            {
                response = new RequestDto() { Error = new ServiceException(e.Message) };
                response.Error.Code = "0";
            }

            return response;
        }

        public async Task<RequestDto> UpdateRequest(RequestDto requestDto)
        {
            RequestDto response;
            try
            {
                var request = _mapper.Map<Solicitud>(requestDto);
                request = await _requestRepository.UpdateRequest(request);
                response = _mapper.Map<RequestDto>(request);
            }
            catch (Exception e)
            {
                response = new RequestDto() { Error = new ServiceException(e.Message) };
                response.Error.Code = "0";
            }
            return response;
        }

        public async Task<RequestDto> GetRequest(RequestDto requestDto)
        {
            var request = await _requestRepository.FindAsync(x => x.SolicitudId == requestDto.SolicitudId);
            return _mapper.Map<RequestDto>(request);
        }

        public async Task<RequestFilterSearchDto> GetRequestByFilter(RequestFilterDto requestFilterDto)
        {
            var response = await _requestRepository.GetRequestByFilter(requestFilterDto);
            return response;
        }

    }
}
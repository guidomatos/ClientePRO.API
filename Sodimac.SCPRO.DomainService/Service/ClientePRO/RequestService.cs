using AutoMapper;
using Sodimac.SCPRO.Common.Error;
using Sodimac.SCPRO.DomainModel.Interface.ClientePRO;
using Sodimac.SCPRO.DomainService.Interface.ClientePRO;
using Sodimac.SCPRO.DomainService.Logic.ClientePRO;
using Sodimac.SCPRO.Model.DataTransferObject.ClientePRO;
using System;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainService.Service.ClientePRO
{
    public class RequestService : IRequestService
    {
        private readonly RequestLogic _requestLogic;
        public RequestService(IRequestRepository requestRepository,
                                         IMapper mapper)
        {
            _requestLogic = new RequestLogic(requestRepository, mapper);
        }

        public async Task<RequestDto> AddRequest(RequestDto requestDto)
        {
            RequestDto response;
            try
            {
                response = await _requestLogic.AddRequest(requestDto);
            }
            catch (Exception e)
            {
                response = new RequestDto() { Error = new ServiceException(e.Message) };                
            }
            return response;
        }

        public async Task<RequestDto> UpdateRequest(RequestDto requestDto)
        {
            RequestDto response;
            try
            {
                response = await _requestLogic.UpdateRequest(requestDto);
            }
            catch (Exception e)
            {
                response = new RequestDto() { Error = new ServiceException(e.Message) };
            }
            return response;
        }

        public async Task<RequestDto> GetRequest(RequestDto requestDto)
        {
            RequestDto response;
            try
            {
                response = await _requestLogic.GetRequest(requestDto);
            }
            catch (Exception e)
            {
                response = new RequestDto() { Error = new ServiceException(e.Message) };
            }
            return response;
        }

        public async Task<RequestFilterSearchDto> GetRequestByFilter(RequestFilterDto requestFilterDto)
        {
            RequestFilterSearchDto response;
            try
            {
                response = await _requestLogic.GetRequestByFilter(requestFilterDto);
            }
            catch (Exception e)
            {
                response = new RequestFilterSearchDto() { Error = new ServiceException(e.Message) };
            }
            return response;
        }
    }
}
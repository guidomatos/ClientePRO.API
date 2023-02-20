using Sodimac.SCPRO.Model.DataTransferObject.ClientePRO;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainService.Interface.ClientePRO
{
    public interface IRequestService
    {
        Task<RequestDto> AddRequest(RequestDto requestDto);
        Task<RequestDto> UpdateRequest(RequestDto requestDto);
        Task<RequestDto> GetRequest(RequestDto requestDto);
        Task<RequestFilterSearchDto> GetRequestByFilter(RequestFilterDto requestFilterDto);
    }
}

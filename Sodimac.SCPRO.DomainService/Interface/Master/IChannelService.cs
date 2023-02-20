using Sodimac.SCPRO.Model.DataTransferObject.Master;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainService.Interface.Master
{
    public interface IChannelService
    {
        Task<ListChannelDto> GetAll();
    }
}

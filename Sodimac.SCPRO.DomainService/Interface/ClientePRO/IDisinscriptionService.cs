using Sodimac.SCPRO.Model.DataTransferObject.ClientePRO;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainService.Interface.ClientePRO
{
    public interface IDisinscriptionService
    {
        Task<DisinscriptionDto> AddDisinscription(DisinscriptionDto disinscriptionDto);
    }
}

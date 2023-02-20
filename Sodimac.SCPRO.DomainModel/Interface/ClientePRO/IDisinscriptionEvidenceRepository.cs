using Sodimac.SCPRO.Model.ClientePRO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainModel.Interface.ClientePRO
{
    public interface IDisinscriptionEvidenceRepository
    {
        Task<List<DesinscripcionEvidencia>> AddMassive(List<DesinscripcionEvidencia> lstDesinscripcionEvidencia);
    }
}

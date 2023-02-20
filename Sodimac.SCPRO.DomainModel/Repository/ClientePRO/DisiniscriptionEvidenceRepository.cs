using Sodimac.SCPRO.DomainModel.Common;
using Sodimac.SCPRO.DomainModel.Interface.ClientePRO;
using Sodimac.SCPRO.Model.ClientePRO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainModel.Repository.ClientePRO
{
    public class DisinscriptionEvidenceRepository : BaseRepository<DesinscripcionEvidencia>, IDisinscriptionEvidenceRepository
    {
        private readonly CommonRepository unitOfWork;
        public DisinscriptionEvidenceRepository(ScproContext context) : base(context)
        {
            unitOfWork = new CommonRepository(context);
        }
        public async Task<List<DesinscripcionEvidencia>> AddMassive(List<DesinscripcionEvidencia> lstDesinscripcionEvidencia)
        {
            unitOfWork.InsertMassive(lstDesinscripcionEvidencia);
            await unitOfWork.SaveChangesAsync();
            return lstDesinscripcionEvidencia;
        }
    }
}

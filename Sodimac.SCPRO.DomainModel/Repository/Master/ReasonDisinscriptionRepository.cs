using Sodimac.SCPRO.DomainModel.Common;
using Sodimac.SCPRO.DomainModel.Interface.Master;
using Sodimac.SCPRO.Model.Master;

namespace Sodimac.SCPRO.DomainModel.Repository.Master
{
    public class ReasonDisinscriptionRepository : BaseRepository<RazonDesinscripcion>, IReasonDisinscriptionRepository
    {
        private readonly CommonRepository unitOfWork;
        public ReasonDisinscriptionRepository(ScproContext context) : base(context)
        {
            unitOfWork = new CommonRepository(context);
        }
    }
}

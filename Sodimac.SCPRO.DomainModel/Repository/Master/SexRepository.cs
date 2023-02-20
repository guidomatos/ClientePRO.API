using Microsoft.EntityFrameworkCore;
using Sodimac.SCPRO.DomainModel.Common;
using Sodimac.SCPRO.DomainModel.Interface.Master;
using Sodimac.SCPRO.Model.DataTransferObject.Master;
using Sodimac.SCPRO.Model.Master;
using System.Linq;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainModel.Repository.Master
{
    public class SexRepository : BaseRepository<Sexo>, ISexRepository
    {
        private readonly CommonRepository unitOfWork;
        public SexRepository(ScproContext context) : base(context)
        {
            unitOfWork = new CommonRepository(context);
        }
    }
}

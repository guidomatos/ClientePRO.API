using Microsoft.EntityFrameworkCore;
using Sodimac.SCPRO.DomainModel.Common;
using Sodimac.SCPRO.DomainModel.Interface.Master;
using Sodimac.SCPRO.Model.DataTransferObject;
using Sodimac.SCPRO.Model.DataTransferObject.Master;
using Sodimac.SCPRO.Model.Master;
using System.Linq;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainModel.Repository.Master
{
    public class UbigeoRepository : BaseRepository<Ubigeo>, IUbigeoRepository
    {
        private readonly CommonRepository unitOfWork;

        public UbigeoRepository(ScproContext context) : base(context)
        {
            unitOfWork = new CommonRepository(context);
        }

    }

}
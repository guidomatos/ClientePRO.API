using Microsoft.EntityFrameworkCore;
using Sodimac.SCPRO.DomainModel.Common;
using Sodimac.SCPRO.DomainModel.Interface.Master;
using Sodimac.SCPRO.Model.DataTransferObject.Master;
using Sodimac.SCPRO.Model.Master;
using System.Linq;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainModel.Repository.Master
{
    public class TypeIdentityDocumentRepository : BaseRepository<TipoDocumentoIdentidad>, ITypeIdentityDocumentRepository
    {
        private readonly CommonRepository unitOfWork;
        public TypeIdentityDocumentRepository(ScproContext context) : base(context)
        {
            unitOfWork = new CommonRepository(context);
        }
    }
}
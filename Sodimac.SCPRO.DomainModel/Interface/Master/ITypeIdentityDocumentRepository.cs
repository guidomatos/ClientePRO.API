using Sodimac.SCPRO.Model.DataTransferObject.Master;
using Sodimac.SCPRO.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainModel.Interface.Master
{
    public interface ITypeIdentityDocumentRepository
    {
        Task<IEnumerable<TipoDocumentoIdentidad>> ToListAsync(Expression<Func<TipoDocumentoIdentidad, bool>> filter = null, Func<IQueryable<TipoDocumentoIdentidad>, IOrderedQueryable<TipoDocumentoIdentidad>> orderBy = null, string includeProperties = "");
        Task<TipoDocumentoIdentidad> FindAsync(Expression<Func<TipoDocumentoIdentidad, bool>> filter, string includeProperties = "");
    }
}

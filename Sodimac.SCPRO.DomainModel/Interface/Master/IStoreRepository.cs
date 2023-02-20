using Sodimac.SCPRO.Model.DataTransferObject.Master;
using Sodimac.SCPRO.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainModel.Interface.Master
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Tienda>> ToListAsync(Expression<Func<Tienda, bool>> filter = null, Func<IQueryable<Tienda>, IOrderedQueryable<Tienda>> orderBy = null, string includeProperties = "");
        Task<Tienda> FindAsync(Expression<Func<Tienda, bool>> filter, string includeProperties = "");
    }
}

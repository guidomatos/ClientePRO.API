using Sodimac.SCPRO.Model.DataTransferObject.Master;
using Sodimac.SCPRO.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainModel.Interface.Master
{
    public interface ITradeRepository
    {
        Task<IEnumerable<Oficio>> ToListAsync(Expression<Func<Oficio, bool>> filter = null, Func<IQueryable<Oficio>, IOrderedQueryable<Oficio>> orderBy = null, string includeProperties = "");
        Task<Oficio> FindAsync(Expression<Func<Oficio, bool>> filter, string includeProperties = "");
    }
}

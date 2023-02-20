using Sodimac.SCPRO.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainModel.Interface.Master
{
    public interface IUbigeoRepository
    {
        Task<IEnumerable<Ubigeo>> ToListAsync(Expression<Func<Ubigeo, bool>> filter = null, Func<IQueryable<Ubigeo>, IOrderedQueryable<Ubigeo>> orderBy = null, string includeProperties = "");
    }
}

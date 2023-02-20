using Sodimac.SCPRO.Model.DataTransferObject.Master;
using Sodimac.SCPRO.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainModel.Interface.Master
{
    public interface ISexRepository
    {
        Task<IEnumerable<Sexo>> ToListAsync(Expression<Func<Sexo, bool>> filter = null, Func<IQueryable<Sexo>, IOrderedQueryable<Sexo>> orderBy = null, string includeProperties = "");
        Task<Sexo> FindAsync(Expression<Func<Sexo, bool>> filter, string includeProperties = "");
    }
}

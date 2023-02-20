using Sodimac.SCPRO.Model.DataTransferObject.Master;
using Sodimac.SCPRO.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainModel.Interface.Master
{
    public interface IEducationalLevelRepository
    {
        Task<IEnumerable<NivelEducativo>> ToListAsync(Expression<Func<NivelEducativo, bool>> filter = null, Func<IQueryable<NivelEducativo>, IOrderedQueryable<NivelEducativo>> orderBy = null, string includeProperties = "");
        Task<NivelEducativo> FindAsync(Expression<Func<NivelEducativo, bool>> filter, string includeProperties = "");
    }
}

using Sodimac.SCPRO.Model.DataTransferObject.Master;
using Sodimac.SCPRO.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainModel.Interface.Master
{
    public interface IReasonDisinscriptionRepository
    {
        Task<IEnumerable<RazonDesinscripcion>> ToListAsync(Expression<Func<RazonDesinscripcion, bool>> filter = null, Func<IQueryable<RazonDesinscripcion>, IOrderedQueryable<RazonDesinscripcion>> orderBy = null, string includeProperties = "");
        Task<RazonDesinscripcion> FindAsync(Expression<Func<RazonDesinscripcion, bool>> filter, string includeProperties = "");
    }
}

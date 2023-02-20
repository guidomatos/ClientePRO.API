using Sodimac.SCPRO.Model.ClientePRO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainModel.Interface.ClientePRO
{
    public interface IDisinscriptionRepository
    {
        Task<Desinscripcion> AddDisinscription(Desinscripcion desinscripcion);
        Task<IEnumerable<Desinscripcion>> ToListAsync(Expression<Func<Desinscripcion, bool>> filter = null, Func<IQueryable<Desinscripcion>, IOrderedQueryable<Desinscripcion>> orderBy = null, string includeProperties = "");
        Task<Desinscripcion> FindAsync(Expression<Func<Desinscripcion, bool>> filter, string includeProperties = "");
        Task<Desinscripcion> Remove(Desinscripcion desinscripcion);
    }
}

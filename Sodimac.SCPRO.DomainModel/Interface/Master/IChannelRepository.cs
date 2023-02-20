using Sodimac.SCPRO.Model.DataTransferObject.Master;
using Sodimac.SCPRO.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainModel.Interface.Master
{
    public interface IChannelRepository
    {
        Task<IEnumerable<Canal>> ToListAsync(Expression<Func<Canal, bool>> filter = null, Func<IQueryable<Canal>, IOrderedQueryable<Canal>> orderBy = null, string includeProperties = "");
        Task<Canal> FindAsync(Expression<Func<Canal, bool>> filter, string includeProperties = "");
    }
}

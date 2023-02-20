using Sodimac.SCPRO.DomainModel.Common;
using Sodimac.SCPRO.Model.ClientePRO;
using Sodimac.SCPRO.Model.DataTransferObject.ClientePRO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainModel.Interface.ClientePRO
{
    public interface IRequestRepository
    {
        Task<Solicitud> AddRequest(Solicitud solicitud);
        Task<Solicitud> UpdateRequest(Solicitud solicitud);
        Task<IEnumerable<Solicitud>> ToListAsync(Expression<Func<Solicitud, bool>> filter = null, Func<IQueryable<Solicitud>, IOrderedQueryable<Solicitud>> orderBy = null, string includeProperties = "");
        Task<Solicitud> FindAsync(Expression<Func<Solicitud, bool>> filter, string includeProperties = "");
        Task<RequestFilterSearchDto> GetRequestByFilter(RequestFilterDto requestFilterDto);
    }
}

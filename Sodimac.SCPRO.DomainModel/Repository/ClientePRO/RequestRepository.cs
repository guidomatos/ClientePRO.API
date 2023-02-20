using Sodimac.SCPRO.DomainModel.Common;
using Sodimac.SCPRO.DomainModel.Interface.ClientePRO;
using Sodimac.SCPRO.Model.ClientePRO;
using Sodimac.SCPRO.Model.DataTransferObject.ClientePRO;
using System.Threading.Tasks;
using System.Linq;

namespace Sodimac.SCPRO.DomainModel.Repository.ClientePRO
{
    public class RequestRepository : BaseRepository<Solicitud>, IRequestRepository
    {
        private readonly CommonRepository unitOfWork;

        public RequestRepository(ScproContext context) : base(context)
        {
            unitOfWork = new CommonRepository(context);
        }

        public async Task<Solicitud> AddRequest(Solicitud solicitud)
        {
            unitOfWork.Add(solicitud);
            await unitOfWork.SaveChangesAsync();

            return solicitud;
        }

        public async Task<Solicitud> UpdateRequest(Solicitud solicitud)
        {
            unitOfWork.Update(solicitud);
            await unitOfWork.SaveChangesAsync();

            return solicitud;
        }

        public async Task<RequestFilterSearchDto> GetRequestByFilter(RequestFilterDto requestFilterDto)
        {
            RequestFilterSearchDto requestFilterSearchDto = new RequestFilterSearchDto();

            var query = (from sol in context.Solicitud
                         join tda in context.Tienda on new { TiendaId = sol.TiendaId.HasValue ? sol.TiendaId.Value : 0 } equals new { tda.TiendaId } into tda_join
                         from tda in tda_join.DefaultIfEmpty()
                         join dist in context.Ubigeo on new { UbigeoId = sol.UbigeoId, Nivel = 3 } equals new { dist.UbigeoId, dist.Nivel } into dist_join
                         from dist in dist_join.DefaultIfEmpty()
                         join prov in context.Ubigeo on new { UbigeoId = dist.PadreId.HasValue ? dist.PadreId.Value : 0, Nivel = 2 } equals new { prov.UbigeoId, prov.Nivel } into prov_join
                         from prov in prov_join.DefaultIfEmpty()
                         join dpto in context.Ubigeo on new { UbigeoId = prov.PadreId.HasValue ? prov.PadreId.Value : 0, Nivel = 1 } equals new { dpto.UbigeoId, dpto.Nivel } into dpto_join
                         from dpto in dpto_join.DefaultIfEmpty()
                         where
                           (requestFilterDto.ChannelId == 0 || sol.Canal.CanalId == requestFilterDto.ChannelId) &&
                           (requestFilterDto.TypeIdentityDocumentId == 0 || sol.TipoDocumentoIdentidadId == requestFilterDto.TypeIdentityDocumentId) &&
                           (string.IsNullOrWhiteSpace(requestFilterDto.DocumentNumberClient) || sol.NumeroDocCliente.Contains(requestFilterDto.DocumentNumberClient)) &&
                           (string.IsNullOrWhiteSpace(requestFilterDto.LastName) || sol.ApellidoCliente.Contains( requestFilterDto.LastName)) &&
                           (string.IsNullOrWhiteSpace(requestFilterDto.FirstName) || sol.NombreCliente.Contains( requestFilterDto.FirstName)) &&
                           (requestFilterDto.SexId == 0 || sol.SexoId == requestFilterDto.SexId) &&
                           (requestFilterDto.TradeId == 0 || sol.OficioId == requestFilterDto.TradeId) &&
                           (requestFilterDto.DistrictId == 0 || dist.UbigeoId == requestFilterDto.DistrictId) &&
                           (requestFilterDto.ProvinceId == 0 || prov.UbigeoId == requestFilterDto.ProvinceId) &&
                           (requestFilterDto.DepartmentId == 0 || dpto.UbigeoId == requestFilterDto.DepartmentId) &&
                           (requestFilterDto.ChannelId == 0 || sol.Canal.CanalId == requestFilterDto.ChannelId) &&
                           (requestFilterDto.StoreId == 0 || tda.TiendaId == requestFilterDto.StoreId)
                         select new RequestSearchDto
                         {
                             SolicitudId = sol.SolicitudId,
                             FechaRegistra = sol.FechaRegistra.ToString("dd/MM/yyyy"),
                             Canal = sol.Canal.Nombre,
                             Tienda = tda.Nombre,
                             TipoDocumentoIdentidad = sol.TipoDocumentoIdentidad.Nombre,
                             NumeroDocCliente = sol.NumeroDocCliente,
                             NombreCliente = sol.NombreCliente,
                             ApellidoCliente = sol.ApellidoCliente,
                             Oficio = sol.Oficio.Nombre,
                             Celular = sol.Celular.ToString(),
                             Correo = sol.Correo,
                             EstadoSolicitudId = sol.EstadoSolicitudId,
                             FechaModifica = sol.FechaModifica.HasValue ? sol.FechaModifica.Value.ToString("dd/MM/yyyy") : ""
                         });

            var result = await unitOfWork.GetQueryAny(query);

            requestFilterSearchDto.Requests = result.Results.ToList();


            //var response = await unitOfWork.GetPaged(query, requestFilterDto.CurrentPage, requestFilterDto.PageSize);
            //response.CurrentPage = response.CurrentPage;
            //response.PageCount = response.PageCount;
            //response.PageSize = response.PageSize;
            //response.RowCount = response.RowCount;
            //response.PanelDetailSearchs = response.Results.ToList();


            return requestFilterSearchDto;
        }

    }
}
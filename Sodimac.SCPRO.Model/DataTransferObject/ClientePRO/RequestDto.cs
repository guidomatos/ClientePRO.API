using Sodimac.SCPRO.Common.Error;
using Sodimac.SCPRO.Model.ClientePRO;
using System.Collections.Generic;

namespace Sodimac.SCPRO.Model.DataTransferObject.ClientePRO
{
    public class RequestDto : Solicitud
    {
        public string Message { get; set; }
        public ServiceException Error { get; set; }
    }
    public class RequestFilterSearchDto
    {
        public List<RequestSearchDto> Requests { get; set; }
        public ServiceException Error { get; set; }
    }


    public class RequestFilterDto: RequestPaginationDto
    {
        public int RequestId { get; set; }
        public int TypeIdentityDocumentId { get; set; }
        public string DocumentNumberClient { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int TradeId { get; set; }
        public int DepartmentId { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int ChannelId { get; set; }
        public int StoreId { get; set; }
        public int SexId { get; set; }
    }

    public class RequestSearchDto : ResponsePaginationDto
    {
        public int SolicitudId { get; set; }
        public string FechaRegistra { get; set; }
        public string Canal { get; set; }
        public string Tienda { get; set; }
        public string TipoDocumentoIdentidad { get; set; }
        public string NumeroDocCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string Oficio { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public int EstadoSolicitudId { get; set; }
        public string FechaModifica { get; set; }
    }
}

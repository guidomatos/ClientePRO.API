using System.Collections.Generic;

namespace Sodimac.SCPRO.ViewModel.ClientePRO
{
    public class RequestViewModel
    {
        public int RequestId { get; set; }
        public int TypeIdentityDocumentId { get; set; }
        public string DocumentNumberClient { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public int SexId { get; set; }
        public int EducationalLevelId { get; set; }
        public int TradeId { get; set; }
        public int UbigeoId { get; set; }
        public string Email { get; set; }
        public int Cellphone { get; set; }
        public int? ChannelId { get; set; }
        public int? StoreId { get; set; }
        public int? RequestStatusId { get; set; }
        public string UserProcess { get; set; }
    }
    public class ResponseRequestViewModel
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
    public class RequestFilterViewModel : RequestPaginationViewModel
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
    public class RequestSearchViewModel: ResponsePaginationViewModel
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
    public class RequestFilterSearchViewModel
    {
        public List<RequestSearchViewModel> Requests { get; set; }
    }
    public class RequestEditViewModel
    {
        public int RequestId { get; set; }
        public int TypeIdentityDocumentId { get; set; }
        public string DocumentNumberClient { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public int SexId { get; set; }
        public int EducationalLevelId { get; set; }
        public int TradeId { get; set; }
        public int UbigeoId { get; set; }
        public string Email { get; set; }
        public int Cellphone { get; set; }
        public int? ChannelId { get; set; }
        public int? StoreId { get; set; }
    }



    public class RequestReportViewModel
    {
        public string FechaRegistro { get; set; }
        public string OrigenRegistro { get; set; }
        public string TiendaRegistro { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Oficio { get; set; }
        public string Celular { get; set; }
        public string CorreoElectronico { get; set; }
    }
    public class RequestFilterReportViewModel
    {
        public List<RequestReportViewModel> Requests { get; set; }
    }
}

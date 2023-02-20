using Sodimac.SCPRO.Common.Error;
using Sodimac.SCPRO.Model.Master;
using System.Collections.Generic;

namespace Sodimac.SCPRO.Model.DataTransferObject.Master
{
    public class RequestStatusDto : EstadoSolicitud
    {
        public string Message { get; set; }
        public ServiceException Error { get; set; }
    }

    public class ListRequestStatusDtoDto
    {
        public List<RequestStatusDto> RequestStatus { get; set; }
        public ServiceException Error { get; set; }
    }
}
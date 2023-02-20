using Sodimac.SCPRO.Common.Error;
using Sodimac.SCPRO.Model.Master;
using System.Collections.Generic;

namespace Sodimac.SCPRO.Model.DataTransferObject.Master
{
    public class ReasonDisinscriptionDto : RazonDesinscripcion
    {
        public string Message { get; set; }
        public ServiceException Error { get; set; }
    }

    public class ListReasonDisinscriptionDto
    {
        public List<ReasonDisinscriptionDto> ReasonDisinscriptions { get; set; }
        public ServiceException Error { get; set; }
    }
}
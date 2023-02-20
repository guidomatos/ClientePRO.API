using Sodimac.SCPRO.Common.Error;
using Sodimac.SCPRO.Model.Master;
using System.Collections.Generic;

namespace Sodimac.SCPRO.Model.DataTransferObject.Master
{
    public class UbigeoDto : Ubigeo
    {
        public string Message { get; set; }
        public ServiceException Error { get; set; }
    }

    public class ListUbigeoDto
    {
        public List<UbigeoDto> Ubigeos { get; set; }
        public ServiceException Error { get; set; }
    }
}
using Sodimac.SCPRO.Common.Error;
using Sodimac.SCPRO.Model.Master;
using System.Collections.Generic;

namespace Sodimac.SCPRO.Model.DataTransferObject.Master
{
    public class SexDto : Sexo
    {
        public string Message { get; set; }
        public ServiceException Error { get; set; }
    }

    public class ListSexDto
    {
        public List<SexDto> Sexs { get; set; }
        public ServiceException Error { get; set; }
    }
}
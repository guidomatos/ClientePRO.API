using Sodimac.SCPRO.Common.Error;
using Sodimac.SCPRO.Model.Master;
using System.Collections.Generic;

namespace Sodimac.SCPRO.Model.DataTransferObject.Master
{
    public class StoreDto : Tienda
    {
        public string Message { get; set; }
        public ServiceException Error { get; set; }
    }

    public class ListStoreDto
    {
        public List<StoreDto> Stores { get; set; }
        public ServiceException Error { get; set; }
    }
}
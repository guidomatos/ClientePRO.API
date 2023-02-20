using Sodimac.SCPRO.Common.Error;
using Sodimac.SCPRO.Model.Master;
using System.Collections.Generic;

namespace Sodimac.SCPRO.Model.DataTransferObject.Master
{
    public class TradeDto : Oficio
    {
        public string Message { get; set; }
        public ServiceException Error { get; set; }
    }

    public class ListTradeDto
    {
        public List<TradeDto> Trades { get; set; }
        public ServiceException Error { get; set; }
    }
}
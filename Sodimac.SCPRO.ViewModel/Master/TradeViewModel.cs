using System.Collections.Generic;

namespace Sodimac.SCPRO.ViewModel.Master
{
    public class TradeViewModel
    {
        public int TradeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class ListTradeViewModel
    {
        public List<TradeViewModel> Trades { get; set; }
    }
}

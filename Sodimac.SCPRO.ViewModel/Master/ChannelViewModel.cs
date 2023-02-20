using System.Collections.Generic;

namespace Sodimac.SCPRO.ViewModel.Master
{
    public class ChannelViewModel
    {
        public int ChannelId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class ListChannelViewModel
    {
        public List<ChannelViewModel> Channels { get; set; }
    }
}

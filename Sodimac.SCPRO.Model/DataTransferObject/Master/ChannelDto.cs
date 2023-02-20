using Sodimac.SCPRO.Common.Error;
using Sodimac.SCPRO.Model.Master;
using System.Collections.Generic;

namespace Sodimac.SCPRO.Model.DataTransferObject.Master
{
    public class ChannelDto : Canal
    {
        public string Message { get; set; }
        public ServiceException Error { get; set; }
    }

    public class ListChannelDto
    {
        public List<ChannelDto> Channels { get; set; }
        public ServiceException Error { get; set; }
    }
}
using AutoMapper;
using Sodimac.SCPRO.Common.Error;
using Sodimac.SCPRO.DomainModel.Interface.Master;
using Sodimac.SCPRO.DomainService.Interface.Master;
using Sodimac.SCPRO.DomainService.Logic.Master;
using Sodimac.SCPRO.Model.DataTransferObject.Master;
using System;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainService.Service.Master
{
    public class ChannelService: IChannelService
    {
        private readonly ChannelLogic _channelLogic;

        public ChannelService(IChannelRepository channelRepository, IMapper mapper)
        {
            _channelLogic = new ChannelLogic(channelRepository, mapper);
        }

        public async Task<ListChannelDto> GetAll()
        {
            var response = new ListChannelDto();
            try
            {
                response.Channels = await _channelLogic.GetAll();
            }
            catch (Exception e)
            {
                response.Error = new ServiceException(e.Message);
            }
            return response;
        }
    }
}

using AutoMapper;
using Sodimac.SCPRO.DomainModel.Interface.Master;
using Sodimac.SCPRO.Model.DataTransferObject.Master;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainService.Logic.Master
{
    public class ChannelLogic
    {
        private readonly IChannelRepository _channelRepository;
        private readonly IMapper _mapper;

        public ChannelLogic(IChannelRepository channelRepository, IMapper mapper)
        {
            _channelRepository = channelRepository;
            _mapper = mapper;
        }

        public async Task<List<ChannelDto>> GetAll()
        {
            var channelsDto = new List<ChannelDto>();

            var channels = await _channelRepository.ToListAsync(x => x.Activo);
            channelsDto.AddRange(from channel in channels
                            let ChannelDto = _mapper.Map<ChannelDto>(channel)
                        select ChannelDto);
            return channelsDto;
        }
    }
}

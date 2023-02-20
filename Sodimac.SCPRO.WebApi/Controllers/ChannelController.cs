using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sodimac.SCPRO.Common.Resource;
using Sodimac.SCPRO.DomainService.Interface.Master;
using Sodimac.SCPRO.ViewModel.Master;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        private readonly IChannelService _channelService;
        private readonly IMapper _mapper;

        public ChannelController(IChannelService channelService, IMapper mapper)
        {
            _channelService = channelService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetChannel()
        {
            IActionResult response = BadRequest(new { message = ErrorMessage.RequestError });
            var channelDto = await _channelService.GetAll();

            if (channelDto.Error == null)
            {
                var channelResponse = _mapper.Map<ListChannelViewModel>(channelDto);
                response = Ok(channelResponse);
            }

            return response;
        }

    }
}

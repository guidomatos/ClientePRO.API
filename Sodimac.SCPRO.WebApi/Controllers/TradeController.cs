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
    public class TradeController : ControllerBase
    {
        private readonly ITradeService _tradeService;
        private readonly IMapper _mapper;

        public TradeController(ITradeService tradeService, IMapper mapper)
        {
            _tradeService = tradeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrade()
        {
            IActionResult response = BadRequest(new { message = ErrorMessage.RequestError });
            var tradeDto = await _tradeService.GetAll();

            if (tradeDto.Error == null)
            {
                var tradeResponse = _mapper.Map<ListTradeViewModel>(tradeDto);
                response = Ok(tradeResponse);
            }

            return response;
        }
    }
}

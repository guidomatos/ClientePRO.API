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
    public class SexController : ControllerBase
    {
        private readonly ISexService _sexService;
        private readonly IMapper _mapper;

        public SexController(ISexService sexService, IMapper mapper)
        {
            _sexService = sexService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSex()
        {
            IActionResult response = BadRequest(new { message = ErrorMessage.RequestError });
            var sexDto = await _sexService.GetAll();

            if (sexDto.Error == null)
            {
                var sexResponse = _mapper.Map<ListSexViewModel>(sexDto);
                response = Ok(sexResponse);
            }

            return response;
        }

    }
}

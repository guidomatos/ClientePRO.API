using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sodimac.SCPRO.Common.Resource;
using Sodimac.SCPRO.DomainService.Interface.Master;
using System.Threading.Tasks;
using Sodimac.SCPRO.ViewModel.Master;

namespace Sodimac.SCPRO.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbigeoController : ControllerBase
    {
        private readonly IUbigeoService _ubigeoService;
        private readonly IMapper _mapper;

        public UbigeoController(IUbigeoService ubigeoService, IMapper mapper)
        {
            _ubigeoService = ubigeoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUbigeo()
        {
            IActionResult response = BadRequest(new { message = ErrorMessage.RequestError });
            var ubigeoDto = await _ubigeoService.GetAll();

            if (ubigeoDto.Error == null)
            {
                var ubigeoResponse = _mapper.Map<ListUbigeoViewModel>(ubigeoDto);
                response = Ok(ubigeoResponse);
            }

            return response;
        }

    }
}
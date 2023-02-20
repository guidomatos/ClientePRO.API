using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sodimac.SCPRO.DomainService.Interface.ClientePRO;
using Sodimac.SCPRO.Model.DataTransferObject.ClientePRO;
using Sodimac.SCPRO.ViewModel.ClientePRO;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisinscriptionController : Controller
    {
        private readonly IDisinscriptionService _disinscriptionService;
        private readonly IMapper _mapper;

        public DisinscriptionController(IDisinscriptionService disinscriptionService, IMapper mapper)
        {
            _disinscriptionService = disinscriptionService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddDisinscription([FromBody] DisinscriptionViewModel disinscriptionViewModel)
        {
            IActionResult response = BadRequest("0");

            var disinscriptionDto = _mapper.Map<DisinscriptionDto>(disinscriptionViewModel);
            var addDisinscription = await _disinscriptionService.AddDisinscription(disinscriptionDto);

            if (addDisinscription.Error == null)
            {
                response = Ok("1");
            }
            else
            {
                response = Ok(addDisinscription.Error.Code);
            }

            return response;
        }

    }
}

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
    public class ReasonDisinscriptionController : ControllerBase
    {
        private readonly IReasonDisinscriptionService _reasonDisinscriptionService;
        private readonly IMapper _mapper;

        public ReasonDisinscriptionController(IReasonDisinscriptionService reasonDisinscriptionService, IMapper mapper)
        {
            _reasonDisinscriptionService = reasonDisinscriptionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetReasonDisinscription()
        {
            IActionResult response = BadRequest(new { message = ErrorMessage.RequestError });
            var reasonDisinscriptionDto = await _reasonDisinscriptionService.GetAll();

            if (reasonDisinscriptionDto.Error == null)
            {
                var sexResponse = _mapper.Map<ListReasonDisinscriptionViewModel>(reasonDisinscriptionDto);
                response = Ok(sexResponse);
            }

            return response;
        }

    }
}

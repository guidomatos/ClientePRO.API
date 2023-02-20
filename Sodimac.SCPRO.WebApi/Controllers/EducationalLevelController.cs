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
    public class EducationalLevelController : ControllerBase
    {
        private readonly IEducationalLevelService _educationalLevelService;
        private readonly IMapper _mapper;

        public EducationalLevelController(IEducationalLevelService educationalLevelService, IMapper mapper)
        {
            _educationalLevelService = educationalLevelService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetEducationalLevel()
        {
            IActionResult response = BadRequest(new { message = ErrorMessage.RequestError });
            var educationalLevelDto = await _educationalLevelService.GetAll();

            if (educationalLevelDto.Error == null)
            {
                var educationalLevelResponse = _mapper.Map<ListEducationalLevelViewModel>(educationalLevelDto);
                response = Ok(educationalLevelResponse);
            }

            return response;
        }

    }
}

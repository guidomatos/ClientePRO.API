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
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;

        public StoreController(IStoreService storeService, IMapper mapper)
        {
            _storeService = storeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStore()
        {
            IActionResult response = BadRequest(new { message = ErrorMessage.RequestError });
            var storeDto = await _storeService.GetAll();

            if (storeDto.Error == null)
            {
                var storeResponse = _mapper.Map<ListStoreViewModel>(storeDto);
                response = Ok(storeResponse);
            }

            return response;
        }

    }
}

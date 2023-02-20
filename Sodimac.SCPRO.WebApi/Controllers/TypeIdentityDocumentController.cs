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
    public class TypeIdentityDocumentController : ControllerBase
    {
        private readonly ITypeIdentityDocumentService _typeIdentityDocumentService;
        private readonly IMapper _mapper;

        public TypeIdentityDocumentController(ITypeIdentityDocumentService typeIdentityDocumentService, IMapper mapper)
        {
            _typeIdentityDocumentService = typeIdentityDocumentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTypeIdentityDocument()
        {
            IActionResult response = BadRequest(new { message = ErrorMessage.RequestError });
            var typeIdentityDocumentDto = await _typeIdentityDocumentService.GetAll();

            if (typeIdentityDocumentDto.Error == null)
            {
                var typeIdentityDocumentResponse = _mapper.Map<ListTypeIdentityDocumentViewModel>(typeIdentityDocumentDto);
                response = Ok(typeIdentityDocumentResponse);
            }

            return response;
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sodimac.SCPRO.Common.Helper;
using Sodimac.SCPRO.Common.Resource;
using Sodimac.SCPRO.DomainService.Interface.ClientePRO;
using Sodimac.SCPRO.Model.DataTransferObject.ClientePRO;
using Sodimac.SCPRO.ViewModel.ClientePRO;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public RequestController(IRequestService requestService, IMapper mapper)
        {
            _requestService = requestService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddRequest([FromBody] RequestViewModel requestViewModel)
        {
            IActionResult response = BadRequest("0");

            var requestDto = _mapper.Map<RequestDto>(requestViewModel);
            var addRequest = await _requestService.AddRequest(requestDto);

            if (addRequest.Error == null)
            {
                response = Ok("1");
            }
            else
            {
                response = Ok(addRequest.Error.Code);
            }

            return response;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRequest([FromBody] RequestViewModel requestViewModel)
        {
            IActionResult response = BadRequest("0");

            var requestDto = _mapper.Map<RequestDto>(requestViewModel);
            var updateRequest = await _requestService.UpdateRequest(requestDto);

            if (updateRequest.Error == null)
            {
                response = Ok("1");
            }
            else
            {
                response = Ok(updateRequest.Error.Code);
            }

            return response;
        }

        [HttpGet("getRequest")]
        public async Task<IActionResult> GetRequest([FromQuery] RequestViewModel requestViewModel)
        {
            IActionResult response = BadRequest(new { message = ErrorMessage.RequestError });
            var requestDto = _mapper.Map<RequestDto>(requestViewModel);
            var requestSearchDto = await _requestService.GetRequest(requestDto);

            var requestSearchResponse = _mapper.Map<RequestEditViewModel>(requestSearchDto);

            if (requestSearchDto.Error == null)
            {
                response = Ok(requestSearchResponse);
            }
            return response;
        }

        [HttpGet("getRequestByFilter")]
        public async Task<IActionResult> GetRequestByFilter([FromQuery] RequestFilterViewModel requestFilterViewModel)
        {
            IActionResult response = BadRequest(new { message = ErrorMessage.RequestError });
            var requestFilterDto = _mapper.Map<RequestFilterDto>(requestFilterViewModel);
            var requestSearchDto = await _requestService.GetRequestByFilter(requestFilterDto);

            var requestSearchResponse = _mapper.Map<RequestFilterSearchViewModel>(requestSearchDto);

            if (requestSearchDto.Error == null)
            {
                response = Ok(requestSearchResponse);
            }
            return response;
        }

        [HttpGet("getReportRequestByFilter")]
        public async Task<IActionResult> getReportRequestByFilter([FromQuery] RequestFilterViewModel requestFilterViewModel)
        {
            IActionResult response = BadRequest(new { message = ErrorMessage.RequestError });
            var requestFilterDto = _mapper.Map<RequestFilterDto>(requestFilterViewModel);
            var requestReportResultDto = await _requestService.GetRequestByFilter(requestFilterDto);

            var requestReportResponse = _mapper.Map<RequestFilterReportViewModel>(requestReportResultDto);

            if (requestReportResultDto.Error == null)
            {
                string FileName = "Reporte de Socios.xlsx";
                string TempFilename = Path.Join(Path.GetTempPath(), FileName);
                CreateExcelFile.CreateExcelDocument(requestReportResponse.Requests, TempFilename);

                byte[] rawData = System.IO.File.ReadAllBytes(TempFilename);
                MemoryStream ms = new MemoryStream(rawData);

                FileStreamResult fr = new FileStreamResult(ms, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = FileName
                };

                System.IO.File.Delete(TempFilename);
                return fr;
            }
            return response;
        }

    }
}

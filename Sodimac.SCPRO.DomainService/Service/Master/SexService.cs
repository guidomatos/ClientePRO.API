using AutoMapper;
using Sodimac.SCPRO.Common.Error;
using Sodimac.SCPRO.DomainModel.Interface.Master;
using Sodimac.SCPRO.DomainService.Interface.Master;
using Sodimac.SCPRO.DomainService.Logic.Master;
using Sodimac.SCPRO.Model.DataTransferObject.Master;
using System;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainService.Service.Master
{
    public class SexService: ISexService
    {
        private readonly SexLogic _sexLogic;

        public SexService(ISexRepository sexRepository, IMapper mapper)
        {
            _sexLogic = new SexLogic(sexRepository, mapper);
        }

        public async Task<ListSexDto> GetAll()
        {
            var response = new ListSexDto();
            try
            {
                response.Sexs = await _sexLogic.GetAll();
            }
            catch (Exception e)
            {
                response.Error = new ServiceException(e.Message);
            }
            return response;
        }
    }
}

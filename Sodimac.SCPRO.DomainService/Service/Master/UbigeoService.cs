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
    public class UbigeoService : IUbigeoService
    {
        private readonly UbigeoLogic _ubigeoLogic;

        public UbigeoService(IUbigeoRepository brandRepository,
                            IMapper mapper)
        {
            _ubigeoLogic = new UbigeoLogic(brandRepository, mapper);
        }

        public async Task<ListUbigeoDto> GetAll()
        {
            var response = new ListUbigeoDto();
            try
            {
                response.Ubigeos = await _ubigeoLogic.GetAll();
            }
            catch (Exception e)
            {
                response.Error = new ServiceException(e.Message);
            }
            return response;
        }
    }
}

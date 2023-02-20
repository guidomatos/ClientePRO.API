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
    public class StoreService: IStoreService
    {
        private readonly StoreLogic _storeLogic;

        public StoreService(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeLogic = new StoreLogic(storeRepository, mapper);
        }

        public async Task<ListStoreDto> GetAll()
        {
            var response = new ListStoreDto();
            try
            {
                response.Stores = await _storeLogic.GetAll();
            }
            catch (Exception e)
            {
                response.Error = new ServiceException(e.Message);
            }
            return response;
        }
    }
}

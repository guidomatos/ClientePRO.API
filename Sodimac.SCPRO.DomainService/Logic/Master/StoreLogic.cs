using AutoMapper;
using Sodimac.SCPRO.DomainModel.Interface.Master;
using Sodimac.SCPRO.Model.DataTransferObject.Master;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainService.Logic.Master
{
    public class StoreLogic
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public StoreLogic(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<List<StoreDto>> GetAll()
        {
            var storesDto = new List<StoreDto>();

            var stores = await _storeRepository.ToListAsync(x => x.Activo);
            storesDto.AddRange(from store in stores
                            let StoreDto = _mapper.Map<StoreDto>(store)
                        select StoreDto);
            return storesDto;
        }
    }
}

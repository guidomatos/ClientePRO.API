using AutoMapper;
using Sodimac.SCPRO.DomainModel.Interface.Master;
using Sodimac.SCPRO.Model.DataTransferObject.Master;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainService.Logic.Master
{
    public class SexLogic
    {
        private readonly ISexRepository _sexRepository;
        private readonly IMapper _mapper;

        public SexLogic(ISexRepository sexRepository, IMapper mapper)
        {
            _sexRepository = sexRepository;
            _mapper = mapper;
        }

        public async Task<List<SexDto>> GetAll()
        {
            var sexsDto = new List<SexDto>();

            var sexs = await _sexRepository.ToListAsync(x => x.Activo);
            sexsDto.AddRange(from sex in sexs
                            let SexDto = _mapper.Map<SexDto>(sex)
                        select SexDto);
            return sexsDto;
        }
    }
}

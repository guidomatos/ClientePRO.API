using AutoMapper;
using Sodimac.SCPRO.DomainModel.Interface.Master;
using Sodimac.SCPRO.Model.DataTransferObject.Master;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainService.Logic.Master
{
    public class UbigeoLogic
    {
        private readonly IUbigeoRepository _ubigeoRepository;
        private readonly IMapper _mapper;

        public UbigeoLogic(IUbigeoRepository ubigeoRepository, IMapper mapper)
        {
            _ubigeoRepository = ubigeoRepository;
            _mapper = mapper;
        }

        public async Task<List<UbigeoDto>> GetAll()
        {
            var ubigeosDto = new List<UbigeoDto>();

            var ubigeos = await _ubigeoRepository.ToListAsync(x => x.Activo);
            ubigeosDto.AddRange(from ubigeo in ubigeos
                               let UbigeoDto = _mapper.Map<UbigeoDto>(ubigeo)
                               select UbigeoDto);
            return ubigeosDto;
        }
    }
}

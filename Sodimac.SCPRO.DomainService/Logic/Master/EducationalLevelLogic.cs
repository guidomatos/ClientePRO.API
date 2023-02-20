using AutoMapper;
using Sodimac.SCPRO.DomainModel.Interface.Master;
using Sodimac.SCPRO.Model.DataTransferObject.Master;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainService.Logic.Master
{
    public class EducationalLevelLogic
    {
        private readonly IEducationalLevelRepository _educationalLevelRepository;
        private readonly IMapper _mapper;

        public EducationalLevelLogic(IEducationalLevelRepository educationalLevelRepository, IMapper mapper)
        {
            _educationalLevelRepository = educationalLevelRepository;
            _mapper = mapper;
        }

        public async Task<List<EducationalLevelDto>> GetAll()
        {
            var educationalLevelsDto = new List<EducationalLevelDto>();

            var educationalLevels = await _educationalLevelRepository.ToListAsync(x => x.Activo);
            educationalLevelsDto.AddRange(from educationalLevel in educationalLevels
                                          let EducationLevelDto = _mapper.Map<EducationalLevelDto>(educationalLevel)
                                   select EducationLevelDto);
            return educationalLevelsDto;
        }
    }
}

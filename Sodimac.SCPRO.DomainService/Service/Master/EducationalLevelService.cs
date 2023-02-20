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
    public class EducationalLevelService: IEducationalLevelService
    {
        private readonly EducationalLevelLogic _educationalLevelLogic;

        public EducationalLevelService(IEducationalLevelRepository educationalLevelRepository, IMapper mapper)
        {
            _educationalLevelLogic = new EducationalLevelLogic(educationalLevelRepository, mapper);
        }

        public async Task<ListEducationalLevelDto> GetAll()
        {
            var response = new ListEducationalLevelDto();
            try
            {
                response.EducationalLevels = await _educationalLevelLogic.GetAll();
            }
            catch (Exception e)
            {
                response.Error = new ServiceException(e.Message);
            }
            return response;
        }
    }
}

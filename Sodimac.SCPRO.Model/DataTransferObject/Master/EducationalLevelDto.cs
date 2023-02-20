using Sodimac.SCPRO.Common.Error;
using Sodimac.SCPRO.Model.Master;
using System.Collections.Generic;

namespace Sodimac.SCPRO.Model.DataTransferObject.Master
{
    public class EducationalLevelDto : NivelEducativo
    {
        public string Message { get; set; }
        public ServiceException Error { get; set; }
    }

    public class ListEducationalLevelDto
    {
        public List<EducationalLevelDto> EducationalLevels { get; set; }
        public ServiceException Error { get; set; }
    }
}
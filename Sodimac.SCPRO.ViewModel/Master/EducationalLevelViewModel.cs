using System.Collections.Generic;

namespace Sodimac.SCPRO.ViewModel.Master
{
    public class EducationalLevelViewModel
    {
        public int EducationalLevelId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class ListEducationalLevelViewModel
    {
        public List<EducationalLevelViewModel> EducationLevels { get; set; }
    }
}

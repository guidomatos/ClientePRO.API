using System.Collections.Generic;

namespace Sodimac.SCPRO.ViewModel.Master
{
    public class ReasonDisinscriptionViewModel
    {
        public int ReasonDisinscriptionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class ListReasonDisinscriptionViewModel
    {
        public List<ReasonDisinscriptionViewModel> ReasonDisinscriptions { get; set; }
    }
}

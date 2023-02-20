using System.Collections.Generic;

namespace Sodimac.SCPRO.ViewModel.ClientePRO
{
    public class DisinscriptionViewModel
    {
        public int DisinscriptionId { get; set; }
        public int RequestId { get; set; }
        public int ReasonDisinscriptionId { get; set; }
        public string DisinscriptionDetail { get; set; }
        public string UserProcess { get; set; }
        public List<DisinscriptionEvidenceViewModel> DisinscriptionEvidences { get; set; }
    }
}

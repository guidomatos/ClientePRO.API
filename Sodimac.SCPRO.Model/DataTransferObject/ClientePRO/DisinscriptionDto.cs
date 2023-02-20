using Sodimac.SCPRO.Common.Error;
using Sodimac.SCPRO.Model.ClientePRO;
using System.Collections.Generic;

namespace Sodimac.SCPRO.Model.DataTransferObject.ClientePRO
{
    public class DisinscriptionDto : Desinscripcion
    {
        public string Message { get; set; }
        public ServiceException Error { get; set; }
        public List<DisinscriptionEvidenceDto> DisinscriptionEvidences { get; set; }
    }

}

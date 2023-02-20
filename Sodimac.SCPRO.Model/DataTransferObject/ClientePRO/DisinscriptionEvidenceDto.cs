using Sodimac.SCPRO.Common.Error;
using Sodimac.SCPRO.Model.ClientePRO;

namespace Sodimac.SCPRO.Model.DataTransferObject.ClientePRO
{
    public class DisinscriptionEvidenceDto : DesinscripcionEvidencia
    {
        public string Message { get; set; }
        public ServiceException Error { get; set; }
    }
}

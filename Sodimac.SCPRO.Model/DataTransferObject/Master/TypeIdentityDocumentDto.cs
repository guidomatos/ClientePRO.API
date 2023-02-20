using Sodimac.SCPRO.Common.Error;
using Sodimac.SCPRO.Model.Master;
using System.Collections.Generic;

namespace Sodimac.SCPRO.Model.DataTransferObject.Master
{
    public class TypeIdentityDocumentDto : TipoDocumentoIdentidad
    {
        public string Message { get; set; }
        public ServiceException Error { get; set; }
    }

    public class ListTypeIdentityDocumentDto
    {
        public List<TypeIdentityDocumentDto> TypeIdentityDocuments { get; set; }
        public ServiceException Error { get; set; }
    }
}
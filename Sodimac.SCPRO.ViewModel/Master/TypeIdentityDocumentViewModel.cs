using System.Collections.Generic;

namespace Sodimac.SCPRO.ViewModel.Master
{
    public class TypeIdentityDocumentViewModel
    {
        public int TypeIdentityDocumentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class ListTypeIdentityDocumentViewModel
    {
        public List<TypeIdentityDocumentViewModel> TypeIdentityDocuments { get; set; }
    }
}

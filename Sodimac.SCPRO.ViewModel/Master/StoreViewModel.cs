using System.Collections.Generic;

namespace Sodimac.SCPRO.ViewModel.Master
{
    public class StoreViewModel
    {
        public int StoreId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class ListStoreViewModel
    {
        public List<StoreViewModel> Stores { get; set; }
    }
}

using System.Collections.Generic;

namespace Sodimac.SCPRO.ViewModel.Master
{
    public class SexViewModel
    {
        public int SexId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class ListSexViewModel
    {
        public List<SexViewModel> Sexs { get; set; }
    }
}

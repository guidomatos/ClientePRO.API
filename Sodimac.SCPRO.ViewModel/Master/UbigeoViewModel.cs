using System.Collections.Generic;

namespace Sodimac.SCPRO.ViewModel.Master
{
    public class UbigeoViewModel
    {
        public int UbigeoId { get; set; }
        public string Nombre { get; set; }
        public int Nivel { get; set; }
        public int PadreId { get; set; }
    }
    public class ListUbigeoViewModel
    {
        public List<UbigeoViewModel> Ubigeos { get; set; }
    }
}

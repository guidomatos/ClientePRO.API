using Sodimac.SCPRO.Model.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sodimac.SCPRO.Model.Master
{
    public class Tienda : AuditBase, IGenerateIdentity<Tienda>
    {
        public int TiendaId { get; set; }
        [MaxLength(4)]
        [Required]
        public string Codigo { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        public Func<Tienda> GetKey()
        {
            return () => new Tienda() { TiendaId = TiendaId };
        }
    }
}

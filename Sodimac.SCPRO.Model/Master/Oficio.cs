using Sodimac.SCPRO.Model.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sodimac.SCPRO.Model.Master
{
    public class Oficio : AuditBase, IGenerateIdentity<Oficio>
    {
        public int OficioId { get; set; }
        [MaxLength(4)]
        [Required]
        public string Codigo { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        public Func<Oficio> GetKey()
        {
            return () => new Oficio() { OficioId = OficioId };
        }
    }
}

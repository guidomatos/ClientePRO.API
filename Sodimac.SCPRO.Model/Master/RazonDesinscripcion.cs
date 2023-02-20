using Sodimac.SCPRO.Model.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sodimac.SCPRO.Model.Master
{
    public class RazonDesinscripcion : AuditBase, IGenerateIdentity<RazonDesinscripcion>
    {
        public int RazonDesinscripcionId { get; set; }
        [MaxLength(4)]
        [Required]
        public string Codigo { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        public Func<RazonDesinscripcion> GetKey()
        {
            return () => new RazonDesinscripcion() { RazonDesinscripcionId = RazonDesinscripcionId };
        }
    }
}

using Sodimac.SCPRO.Model.Interface;
using Sodimac.SCPRO.Model.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sodimac.SCPRO.Model.ClientePRO
{
    public class Desinscripcion : AuditBase, IGenerateIdentity<Desinscripcion>
    {
        public int DesinscripcionId { get; set; }
        [Required]
        public int SolicitudId { get; set; }
        public virtual Solicitud Solicitud { get; set; }
        [Required]
        public int RazonDesinscripcionId { get; set; }
        public virtual RazonDesinscripcion RazonDesinscripcion { get; set; }
        [MaxLength(500)]
        [Required]
        public string DesinscripcionDetalle { get; set; }

        public virtual List<DesinscripcionEvidencia> DesinscripcionEvidencias { get; set; }

        public Func<Desinscripcion> GetKey()
        {
            return () => new Desinscripcion { DesinscripcionId = DesinscripcionId };
        }
    }
}

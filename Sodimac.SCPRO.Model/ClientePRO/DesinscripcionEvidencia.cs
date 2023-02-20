using Sodimac.SCPRO.Model.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sodimac.SCPRO.Model.ClientePRO
{
    public class DesinscripcionEvidencia : AuditBase, IGenerateIdentity<DesinscripcionEvidencia>
    {
        public int DesinscripcionEvidenciaId { get; set; }
        [Required]
        public int DesinscripcionId { get; set; }
        public virtual Desinscripcion Desinscripcion { get; set; }

        [NotMapped]
        public byte[] EvidenciaImagen { get; set; }
        [NotMapped]
        public string EvidenciaImagenNombre { get; set; }
        [Required]
        public string EvidenciaImagenUrl { get; set; }


        public Func<DesinscripcionEvidencia> GetKey()
        {
            return () => new DesinscripcionEvidencia { DesinscripcionEvidenciaId = DesinscripcionEvidenciaId };
        }
    }
}

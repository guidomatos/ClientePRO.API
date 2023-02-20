using Sodimac.SCPRO.Model.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sodimac.SCPRO.Model.Master
{
    public class TipoDocumentoIdentidad : AuditBase, IGenerateIdentity<TipoDocumentoIdentidad>
    {
        public int TipoDocumentoIdentidadId { get; set; }
        [MaxLength(4)]
        [Required]
        public string Codigo { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }

        public Func<TipoDocumentoIdentidad> GetKey()
        {
            return () => new TipoDocumentoIdentidad { TipoDocumentoIdentidadId = TipoDocumentoIdentidadId };
        }
    }
}

using Sodimac.SCPRO.Model.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sodimac.SCPRO.Model.Master
{
    public class NivelEducativo : AuditBase, IGenerateIdentity<NivelEducativo>
    {
        public int NivelEducativoId { get; set; }
        [MaxLength(4)]
        [Required]
        public string Codigo { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        public Func<NivelEducativo> GetKey()
        {
            return () => new NivelEducativo() { NivelEducativoId = NivelEducativoId };
        }
    }
}

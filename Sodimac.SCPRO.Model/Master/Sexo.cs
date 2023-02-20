using Sodimac.SCPRO.Model.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sodimac.SCPRO.Model.Master
{
    public class Sexo : AuditBase, IGenerateIdentity<Sexo>
    {
        public int SexoId { get; set; }
        [MaxLength(4)]
        [Required]
        public string Codigo { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        public Func<Sexo> GetKey()
        {
            return () => new Sexo() { SexoId = SexoId };
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Sodimac.SCPRO.Model
{
    public class EntityBase
    {
        [MaxLength(15)]
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
    }
}

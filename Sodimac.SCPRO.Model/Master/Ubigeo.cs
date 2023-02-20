using Sodimac.SCPRO.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sodimac.SCPRO.Model.Master
{
    public class Ubigeo : AuditBase, IGenerateIdentity<Ubigeo>
    {
        public int UbigeoId { get; set; }
        [MaxLength(2)]
        [Required]
        public string Codigo { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        [MaxLength(250)]
        public string NombreCompuesto { get; set; }
        [MaxLength(250)]
        public string Busqueda { get; set; }
        [Required]
        public int Nivel { get; set; }
        public int? PadreId { get; set; }
        public virtual Ubigeo Padre { get; set; }
        public virtual List<Ubigeo> Hijos { get; set; }

        public Func<Ubigeo> GetKey()
        {
            return () => new Ubigeo() { UbigeoId = UbigeoId };
        }
    }
}
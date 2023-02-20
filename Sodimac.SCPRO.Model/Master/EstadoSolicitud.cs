using Sodimac.SCPRO.Model.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sodimac.SCPRO.Model.Master
{
    public class EstadoSolicitud : AuditBase, IGenerateIdentity<EstadoSolicitud>
    {
        public int EstadoSolicitudId { get; set; }
        [MaxLength(4)]
        [Required]
        public string Codigo { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        public Func<EstadoSolicitud> GetKey()
        {
            return () => new EstadoSolicitud() { EstadoSolicitudId = EstadoSolicitudId };
        }
    }
}

using Sodimac.SCPRO.Model.Interface;
using Sodimac.SCPRO.Model.Master;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sodimac.SCPRO.Model.ClientePRO
{
    public class Solicitud : AuditBase, IGenerateIdentity<Solicitud>
    {
        public int SolicitudId { get; set; }
        [Required]
        public int TipoDocumentoIdentidadId { get; set; }
        public virtual TipoDocumentoIdentidad TipoDocumentoIdentidad { get; set; }
        [MaxLength(15)]
        [Required]
        public string NumeroDocCliente { get; set; }
        [MaxLength(100)]
        [Required]
        public string ApellidoCliente { get; set; }
        [MaxLength(100)]
        [Required]
        public string NombreCliente { get; set; }
        public int Edad { get; set; }
        public int SexoId { get; set; }
        public virtual Sexo Sexo { get; set; }
        public int? NivelEducativoId { get; set; }
        public virtual NivelEducativo NivelEducativo { get; set; }
        public int OficioId { get; set; }
        public virtual Oficio Oficio { get; set; }
        public int UbigeoId { get; set; }
        public virtual Ubigeo Ubigeo { get; set; }
        [MaxLength(200)]
        public string Correo { get; set; }
        public int Celular { get; set; }
        public int CanalId { get; set; }
        public virtual Canal Canal { get; set; }
        public int? TiendaId { get; set; }
        public virtual Tienda Tienda { get; set; }
        public int EstadoSolicitudId { get; set; }
        public virtual EstadoSolicitud EstadoSolicitud { get; set; }

        public Func<Solicitud> GetKey()
        {
            return () => new Solicitud { SolicitudId = SolicitudId };
        }
    }
}

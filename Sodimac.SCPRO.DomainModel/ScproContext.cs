using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Sodimac.SCPRO.Common.Resource;
using Sodimac.SCPRO.Model.Master;
using Sodimac.SCPRO.Model.ClientePRO;

namespace Sodimac.SCPRO.DomainModel
{
    public class ScproContext : DbContext
    {
        public ScproContext(DbContextOptions<ScproContext> options) : base(options)
        {

        }
        #region Entities Maestro
        public virtual DbSet<TipoDocumentoIdentidad> TipoDocumentoIdentidad { get; set; }
        public virtual DbSet<Sexo> Sexo { get; set; }
        public virtual DbSet<NivelEducativo> NivelEducativo { get; set; }
        public virtual DbSet<Oficio> Oficio { get; set; }
        public virtual DbSet<Ubigeo> Ubigeo { get; set; }
        public virtual DbSet<Canal> Canal { get; set; }
        public virtual DbSet<Tienda> Tienda { get; set; }
        public virtual DbSet<EstadoSolicitud> EstadoSolicitud { get; set; }
        public virtual DbSet<RazonDesinscripcion> RazonDesinscripcion { get; set; }
        #endregion
        #region Entities ClientePRO
        public virtual DbSet<Solicitud> Solicitud { get; set; }
        public virtual DbSet<Desinscripcion> Desinscripcion { get; set; }
        public virtual DbSet<DesinscripcionEvidencia> DesinscripcionEvidencia { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoDocumentoIdentidad>().ToTable(Table.TipoDocumentoIdentidad, Schema.Maestro);
            modelBuilder.Entity<Sexo>().ToTable(Table.Sexo, Schema.Maestro);
            modelBuilder.Entity<NivelEducativo>().ToTable(Table.NivelEducativo, Schema.Maestro);
            modelBuilder.Entity<Oficio>().ToTable(Table.Oficio, Schema.Maestro);
            modelBuilder.Entity<Ubigeo>().ToTable(Table.Ubigeo, Schema.Maestro);
            modelBuilder.Entity<Ubigeo>().HasMany(x => x.Hijos).WithOne(x => x.Padre).HasForeignKey(x => x.PadreId);
            modelBuilder.Entity<Solicitud>().ToTable(Table.Solicitud, Schema.ClientePro);
            modelBuilder.Entity<Canal>().ToTable(Table.Canal, Schema.Maestro);
            modelBuilder.Entity<Tienda>().ToTable(Table.Tienda, Schema.Maestro);
            modelBuilder.Entity<EstadoSolicitud>().ToTable(Table.EstadoSolicitud, Schema.Maestro);
            modelBuilder.Entity<RazonDesinscripcion>().ToTable(Table.RazonDesinscripcion, Schema.Maestro);
            modelBuilder.Entity<Desinscripcion>().ToTable(Table.Desinscripcion, Schema.ClientePro);
            modelBuilder.Entity<DesinscripcionEvidencia>().ToTable(Table.DesinscripcionEvidencia, Schema.ClientePro);
        }
    }
}

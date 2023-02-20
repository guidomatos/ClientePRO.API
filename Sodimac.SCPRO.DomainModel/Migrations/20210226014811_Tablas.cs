using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sodimac.SCPRO.DomainModel.Migrations
{
    public partial class Tablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ClientePro");

            migrationBuilder.EnsureSchema(
                name: "Maestro");

            migrationBuilder.CreateTable(
                name: "Canal",
                schema: "Maestro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioRegistra = table.Column<string>(maxLength: 15, nullable: true),
                    FechaRegistra = table.Column<DateTime>(nullable: false),
                    UsuarioModifica = table.Column<string>(maxLength: 15, nullable: true),
                    FechaModifica = table.Column<DateTime>(nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoSolicitud",
                schema: "Maestro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioRegistra = table.Column<string>(maxLength: 15, nullable: true),
                    FechaRegistra = table.Column<DateTime>(nullable: false),
                    UsuarioModifica = table.Column<string>(maxLength: 15, nullable: true),
                    FechaModifica = table.Column<DateTime>(nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoSolicitud", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NivelEducativo",
                schema: "Maestro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioRegistra = table.Column<string>(maxLength: 15, nullable: true),
                    FechaRegistra = table.Column<DateTime>(nullable: false),
                    UsuarioModifica = table.Column<string>(maxLength: 15, nullable: true),
                    FechaModifica = table.Column<DateTime>(nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelEducativo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oficio",
                schema: "Maestro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioRegistra = table.Column<string>(maxLength: 15, nullable: true),
                    FechaRegistra = table.Column<DateTime>(nullable: false),
                    UsuarioModifica = table.Column<string>(maxLength: 15, nullable: true),
                    FechaModifica = table.Column<DateTime>(nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oficio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sexo",
                schema: "Maestro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioRegistra = table.Column<string>(maxLength: 15, nullable: true),
                    FechaRegistra = table.Column<DateTime>(nullable: false),
                    UsuarioModifica = table.Column<string>(maxLength: 15, nullable: true),
                    FechaModifica = table.Column<DateTime>(nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tienda",
                schema: "Maestro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioRegistra = table.Column<string>(maxLength: 15, nullable: true),
                    FechaRegistra = table.Column<DateTime>(nullable: false),
                    UsuarioModifica = table.Column<string>(maxLength: 15, nullable: true),
                    FechaModifica = table.Column<DateTime>(nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tienda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumentoIdentidad",
                schema: "Maestro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioRegistra = table.Column<string>(maxLength: 15, nullable: true),
                    FechaRegistra = table.Column<DateTime>(nullable: false),
                    UsuarioModifica = table.Column<string>(maxLength: 15, nullable: true),
                    FechaModifica = table.Column<DateTime>(nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumentoIdentidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ubigeo",
                schema: "Maestro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioRegistra = table.Column<string>(maxLength: 15, nullable: true),
                    FechaRegistra = table.Column<DateTime>(nullable: false),
                    UsuarioModifica = table.Column<string>(maxLength: 15, nullable: true),
                    FechaModifica = table.Column<DateTime>(nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    Codigo = table.Column<string>(maxLength: 2, nullable: true),
                    Nombre = table.Column<string>(maxLength: 50, nullable: true),
                    NombreCompuesto = table.Column<string>(maxLength: 250, nullable: true),
                    Busqueda = table.Column<string>(maxLength: 250, nullable: true),
                    Nivel = table.Column<int>(nullable: false),
                    PadreId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubigeo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ubigeo_Ubigeo_PadreId",
                        column: x => x.PadreId,
                        principalSchema: "Maestro",
                        principalTable: "Ubigeo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Solicitud",
                schema: "ClientePro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioRegistra = table.Column<string>(maxLength: 15, nullable: true),
                    FechaRegistra = table.Column<DateTime>(nullable: false),
                    UsuarioModifica = table.Column<string>(maxLength: 15, nullable: true),
                    FechaModifica = table.Column<DateTime>(nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    TipoDocumentoIdentidadId = table.Column<int>(nullable: false),
                    NumeroDocCliente = table.Column<string>(maxLength: 15, nullable: true),
                    ApellidoCliente = table.Column<string>(maxLength: 100, nullable: true),
                    NombreCliente = table.Column<string>(maxLength: 100, nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    SexoId = table.Column<int>(nullable: false),
                    NivelEducativoId = table.Column<int>(nullable: false),
                    OficioId = table.Column<int>(nullable: false),
                    UbigeoId = table.Column<int>(nullable: false),
                    Correo = table.Column<string>(maxLength: 200, nullable: true),
                    Celular = table.Column<int>(nullable: false),
                    CanalId = table.Column<int>(nullable: true),
                    TiendaId = table.Column<int>(nullable: true),
                    EstadoSolicitudId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitud_Canal_CanalId",
                        column: x => x.CanalId,
                        principalSchema: "Maestro",
                        principalTable: "Canal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Solicitud_EstadoSolicitud_EstadoSolicitudId",
                        column: x => x.EstadoSolicitudId,
                        principalSchema: "Maestro",
                        principalTable: "EstadoSolicitud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Solicitud_NivelEducativo_NivelEducativoId",
                        column: x => x.NivelEducativoId,
                        principalSchema: "Maestro",
                        principalTable: "NivelEducativo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitud_Oficio_OficioId",
                        column: x => x.OficioId,
                        principalSchema: "Maestro",
                        principalTable: "Oficio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitud_Sexo_SexoId",
                        column: x => x.SexoId,
                        principalSchema: "Maestro",
                        principalTable: "Sexo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitud_Tienda_TiendaId",
                        column: x => x.TiendaId,
                        principalSchema: "Maestro",
                        principalTable: "Tienda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Solicitud_TipoDocumentoIdentidad_TipoDocumentoIdentidadId",
                        column: x => x.TipoDocumentoIdentidadId,
                        principalSchema: "Maestro",
                        principalTable: "TipoDocumentoIdentidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitud_Ubigeo_UbigeoId",
                        column: x => x.UbigeoId,
                        principalSchema: "Maestro",
                        principalTable: "Ubigeo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_CanalId",
                schema: "ClientePro",
                table: "Solicitud",
                column: "CanalId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_EstadoSolicitudId",
                schema: "ClientePro",
                table: "Solicitud",
                column: "EstadoSolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_NivelEducativoId",
                schema: "ClientePro",
                table: "Solicitud",
                column: "NivelEducativoId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_OficioId",
                schema: "ClientePro",
                table: "Solicitud",
                column: "OficioId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_SexoId",
                schema: "ClientePro",
                table: "Solicitud",
                column: "SexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_TiendaId",
                schema: "ClientePro",
                table: "Solicitud",
                column: "TiendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_TipoDocumentoIdentidadId",
                schema: "ClientePro",
                table: "Solicitud",
                column: "TipoDocumentoIdentidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_UbigeoId",
                schema: "ClientePro",
                table: "Solicitud",
                column: "UbigeoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ubigeo_PadreId",
                schema: "Maestro",
                table: "Ubigeo",
                column: "PadreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitud",
                schema: "ClientePro");

            migrationBuilder.DropTable(
                name: "Canal",
                schema: "Maestro");

            migrationBuilder.DropTable(
                name: "EstadoSolicitud",
                schema: "Maestro");

            migrationBuilder.DropTable(
                name: "NivelEducativo",
                schema: "Maestro");

            migrationBuilder.DropTable(
                name: "Oficio",
                schema: "Maestro");

            migrationBuilder.DropTable(
                name: "Sexo",
                schema: "Maestro");

            migrationBuilder.DropTable(
                name: "Tienda",
                schema: "Maestro");

            migrationBuilder.DropTable(
                name: "TipoDocumentoIdentidad",
                schema: "Maestro");

            migrationBuilder.DropTable(
                name: "Ubigeo",
                schema: "Maestro");
        }
    }
}

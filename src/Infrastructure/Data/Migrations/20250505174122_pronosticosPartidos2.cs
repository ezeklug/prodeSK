using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstadisticasIndependiente.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class pronosticosPartidos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estadio_Equipo_EquipoId",
                table: "Estadio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estadio",
                table: "Estadio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipo",
                table: "Equipo");

            migrationBuilder.RenameTable(
                name: "Estadio",
                newName: "Estadios");

            migrationBuilder.RenameTable(
                name: "Equipo",
                newName: "Equipos");

            migrationBuilder.RenameIndex(
                name: "IX_Estadio_EquipoId",
                table: "Estadios",
                newName: "IX_Estadios_EquipoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estadios",
                table: "Estadios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipos",
                table: "Equipos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipoLocal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EquipoVisitante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Iteracion = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pronosticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartidoId = table.Column<int>(type: "int", nullable: false),
                    Resultado = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pronosticos", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Estadios_Equipos_EquipoId",
                table: "Estadios",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estadios_Equipos_EquipoId",
                table: "Estadios");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "Pronosticos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estadios",
                table: "Estadios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipos",
                table: "Equipos");

            migrationBuilder.RenameTable(
                name: "Estadios",
                newName: "Estadio");

            migrationBuilder.RenameTable(
                name: "Equipos",
                newName: "Equipo");

            migrationBuilder.RenameIndex(
                name: "IX_Estadios_EquipoId",
                table: "Estadio",
                newName: "IX_Estadio_EquipoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estadio",
                table: "Estadio",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipo",
                table: "Equipo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estadio_Equipo_EquipoId",
                table: "Estadio",
                column: "EquipoId",
                principalTable: "Equipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

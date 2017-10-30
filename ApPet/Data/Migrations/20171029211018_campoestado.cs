using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ApPet.Data.Migrations
{
    public partial class campoestado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "tblVeterinaries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEstado",
                table: "tblVeterinaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEstado",
                table: "tblUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tblPaises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaisISO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPaises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblEstados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdPais = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEstados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEstados_tblPaises_IdPais",
                        column: x => x.IdPais,
                        principalTable: "tblPaises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCiudades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCiudades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCiudades_tblEstados_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "tblEstados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblVeterinaries_EstadoId",
                table: "tblVeterinaries",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_IdEstado",
                table: "tblUser",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_tblCiudades_IdEstado",
                table: "tblCiudades",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_tblEstados_IdPais",
                table: "tblEstados",
                column: "IdPais");

            migrationBuilder.AddForeignKey(
                name: "FK_tblUser_tblEstados_IdEstado",
                table: "tblUser",
                column: "IdEstado",
                principalTable: "tblEstados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblVeterinaries_tblEstados_EstadoId",
                table: "tblVeterinaries",
                column: "EstadoId",
                principalTable: "tblEstados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUser_tblEstados_IdEstado",
                table: "tblUser");

            migrationBuilder.DropForeignKey(
                name: "FK_tblVeterinaries_tblEstados_EstadoId",
                table: "tblVeterinaries");

            migrationBuilder.DropTable(
                name: "tblCiudades");

            migrationBuilder.DropTable(
                name: "tblEstados");

            migrationBuilder.DropTable(
                name: "tblPaises");

            migrationBuilder.DropIndex(
                name: "IX_tblVeterinaries_EstadoId",
                table: "tblVeterinaries");

            migrationBuilder.DropIndex(
                name: "IX_tblUser_IdEstado",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "tblVeterinaries");

            migrationBuilder.DropColumn(
                name: "IdEstado",
                table: "tblVeterinaries");

            migrationBuilder.DropColumn(
                name: "IdEstado",
                table: "tblUser");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ApPet.Data.Migrations
{
    public partial class modificacionmodelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblVeterinaryVetServices");

            migrationBuilder.AddColumn<int>(
                name: "IdVeterinary",
                table: "tblVetServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblVetServices_IdVeterinary",
                table: "tblVetServices",
                column: "IdVeterinary");

            migrationBuilder.AddForeignKey(
                name: "FK_tblVetServices_tblVeterinaries_IdVeterinary",
                table: "tblVetServices",
                column: "IdVeterinary",
                principalTable: "tblVeterinaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblVetServices_tblVeterinaries_IdVeterinary",
                table: "tblVetServices");

            migrationBuilder.DropIndex(
                name: "IX_tblVetServices_IdVeterinary",
                table: "tblVetServices");

            migrationBuilder.DropColumn(
                name: "IdVeterinary",
                table: "tblVetServices");

            migrationBuilder.CreateTable(
                name: "tblVeterinaryVetServices",
                columns: table => new
                {
                    VeterinaryId = table.Column<int>(nullable: false),
                    VetServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVeterinaryVetServices", x => new { x.VeterinaryId, x.VetServiceId });
                    table.ForeignKey(
                        name: "FK_tblVeterinaryVetServices_tblVetServices_VetServiceId",
                        column: x => x.VetServiceId,
                        principalTable: "tblVetServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblVeterinaryVetServices_tblVeterinaries_VeterinaryId",
                        column: x => x.VeterinaryId,
                        principalTable: "tblVeterinaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblVeterinaryVetServices_VetServiceId",
                table: "tblVeterinaryVetServices",
                column: "VetServiceId");
        }
    }
}

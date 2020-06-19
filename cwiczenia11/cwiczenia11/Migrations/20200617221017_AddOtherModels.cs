﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace cwiczenia11.Migrations
{
    public partial class AddOtherModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(

                name: "Medicament",
                columns: table => new
                {

                    IdMedicament = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },

                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicament", x => x.IdMedicament);

                });

            migrationBuilder.CreateTable(

                name: "Prescription_Medicament",
                columns: table => new
                {

                    IdMedicament = table.Column<int>(nullable: false),
                    IdPrescription = table.Column<int>(nullable: false),
                    Dose = table.Column<int>(nullable: true),
                    Details = table.Column<string>(maxLength: 100, nullable: false)
                },

                constraints: table =>
                {

                    table.PrimaryKey("PK_Prescription_Medicament", x => new { x.IdMedicament, x.IdPrescription });

                    table.ForeignKey(

                        name: "FK_Prescription_Medicament_Medicament_IdMedicament",
                        column: x => x.IdMedicament,
                        principalTable: "Medicament",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(

                        name: "FK_Prescription_Medicament_Prescription_IdPrescription",
                        column: x => x.IdPrescription,
                        principalTable: "Prescription",
                        principalColumn: "IdPrescription",
                        onDelete: ReferentialAction.Cascade);

                });

            migrationBuilder.CreateIndex(

                name: "IX_Prescription_Medicament_IdPrescription",
                table: "Prescription_Medicament",
                column: "IdPrescription");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(

                name: "Prescription_Medicament");

            migrationBuilder.DropTable(

                name: "Medicament");
        }
    }

}

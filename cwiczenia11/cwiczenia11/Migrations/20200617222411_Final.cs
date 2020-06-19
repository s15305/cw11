using Microsoft.EntityFrameworkCore.Migrations;

namespace cwiczenia11.Migrations
{
    public partial class Final : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)

        {

            migrationBuilder.DropForeignKey(

                name: "FK_Prescription_Medicament_Medicament_IdMedicament",
                table: "Prescription_Medicament");

            migrationBuilder.DropForeignKey(

                name: "FK_Prescription_Medicament_Prescription_IdPrescription",
                table: "Prescription_Medicament");

            migrationBuilder.DropPrimaryKey(

                name: "PK_Prescription_Medicament",
                table: "Prescription_Medicament");

            migrationBuilder.DropPrimaryKey(

                name: "PK_Medicament",
                table: "Medicament");

            migrationBuilder.RenameTable(

                name: "Prescription_Medicament",
                newName: "Prescription_Medicaments");

            migrationBuilder.RenameTable(

                name: "Prescription",
                newName: "Prescriptions");

            migrationBuilder.RenameTable(

                name: "Patient",
                newName: "Patients");

            migrationBuilder.RenameTable(

                name: "Medicament",
                newName: "Medicaments");

            migrationBuilder.RenameTable(

                name: "Doctor",
                newName: "Doctors");

            migrationBuilder.RenameIndex(

                name: "IX_Prescription_Medicament_IdPrescription",
                table: "Prescription_Medicaments",
                newName: "IX_Prescription_Medicaments_IdPrescription");

            migrationBuilder.RenameIndex(

                name: "IX_Prescription_IdPatient",
                table: "Prescriptions",
                newName: "IX_Prescriptions_IdPatient");

            migrationBuilder.RenameIndex(

                name: "IX_Prescription_IdDoctor",
                table: "Prescriptions",
                newName: "IX_Prescriptions_IdDoctor");

            migrationBuilder.AddPrimaryKey(

                name: "PK_Prescription_Medicaments",
                table: "Prescription_Medicaments",
                columns: new[] { "IdMedicament", "IdPrescription" });

            migrationBuilder.AddPrimaryKey(

                name: "PK_Medicaments",
                table: "Medicaments",
                column: "IdMedicament");

            migrationBuilder.AddForeignKey(

                name: "FK_Prescription_Medicaments_Medicaments_IdMedicament",
                table: "Prescription_Medicaments",
                column: "IdMedicament",
                principalTable: "Medicaments",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(

                name: "FK_Prescription_Medicaments_Prescriptions_IdPrescription",
                table: "Prescription_Medicaments",
                column: "IdPrescription",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)

        {

            migrationBuilder.DropForeignKey(

                name: "FK_Prescription_Medicaments_Medicaments_IdMedicament",
                table: "Prescription_Medicaments");

            migrationBuilder.DropForeignKey(

                name: "FK_Prescription_Medicaments_Prescriptions_IdPrescription",
                table: "Prescription_Medicaments");

            migrationBuilder.DropPrimaryKey(

                name: "PK_Prescription_Medicaments",
                table: "Prescription_Medicaments");

            migrationBuilder.DropPrimaryKey(

                name: "PK_Medicaments",
                table: "Medicaments");

            migrationBuilder.RenameTable(

                name: "Prescriptions",
                newName: "Prescription");

            migrationBuilder.RenameTable(

                name: "Prescription_Medicaments",
                newName: "Prescription_Medicament");

            migrationBuilder.RenameTable(

                name: "Patients",
                newName: "Patient");

            migrationBuilder.RenameTable(

                name: "Medicaments",
                newName: "Medicament");

            migrationBuilder.RenameTable(

                name: "Doctors",
                newName: "Doctor");

            migrationBuilder.RenameIndex(

                name: "IX_Prescriptions_IdPatient",
                table: "Prescription",
                newName: "IX_Prescription_IdPatient");

            migrationBuilder.RenameIndex(

                name: "IX_Prescriptions_IdDoctor",
                table: "Prescription",
                newName: "IX_Prescription_IdDoctor");

            migrationBuilder.RenameIndex(

                name: "IX_Prescription_Medicaments_IdPrescription",
                table: "Prescription_Medicament",
                newName: "IX_Prescription_Medicament_IdPrescription");

            migrationBuilder.AddPrimaryKey(

                name: "PK_Prescription_Medicament",
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription" });

            migrationBuilder.AddPrimaryKey(

                name: "PK_Medicament",
                table: "Medicament",
                column: "IdMedicament");

            migrationBuilder.AddForeignKey(

                name: "FK_Prescription_Medicament_Medicament_IdMedicament",
                table: "Prescription_Medicament",
                column: "IdMedicament",
                principalTable: "Medicament",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(

                name: "FK_Prescription_Medicament_Prescription_IdPrescription",
                table: "Prescription_Medicament",
                column: "IdPrescription",
                principalTable: "Prescription",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

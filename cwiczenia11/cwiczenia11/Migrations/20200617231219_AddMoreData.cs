using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cwiczenia11.Migrations
{
    public partial class AddMoreData : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(

                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 0);

            migrationBuilder.InsertData(

                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {

                    { 1, "jan@kowalski.pl", "Jan", "Kowalski" },
                    { 2, "jan@nowak.pl", "Jan", "Nowak" }

                });

            migrationBuilder.InsertData(

                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {

                    { 1, "Majonez", "Winiary", "Do salatek" },
                    { 2, "aaaaa", "bbbbb", "ccccc" }

                });

            migrationBuilder.InsertData(

                table: "Patients",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]

                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan", "Kowalski" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan", "Nowak" }
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(

                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(

                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(

                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(

                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(

                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(

                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.InsertData(

                table: "Patients",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[] { 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan", "Kowalski" });

        }

    }
}

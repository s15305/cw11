using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cwiczenia11.Migrations
{
    public partial class AddFirstPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)

        {

            migrationBuilder.InsertData(

                table: "Patients",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[] { 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan", "Kowalski" });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(

                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 0);

        }

    }
}

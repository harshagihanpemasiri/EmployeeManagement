using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeManagement.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DOB", "Email", "FirstName", "Gender", "LastName", "Phone", "Position", "Province", "Salary" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "harshagihan@gmail.com", "Harsha", "male", "Gihan", "0772565498", "Intern", "West", 10000m },
                    { 2, new DateTime(1999, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "isurulakshan@gmail.com", "Isuru", "male", "Lakshan", "0779685478", "Intern", "North", 10000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);
        }
    }
}

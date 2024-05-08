using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreDataToTheUpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DOB", "Email", "FirstName", "Gender", "LastName", "Phone", "Position", "ProfilePicName", "Province", "Salary" },
                values: new object[] { 3, new DateTime(1999, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "isuri123@gmail.com", "Isuri", "female", "Dilrukshi", "0779865478", "Intern", "", "North", 10000m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);
        }
    }
}

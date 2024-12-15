using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagamentSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f198f3f-1b40-4fd8-b869-d89b0d86d6d7", null, "Supervisor", "SUPERVISOR" },
                    { "edccd9cd-806c-4aa4-82f3-c75b93151891", null, "Administrator", "ADMINISTRATOR" },
                    { "f52dedb1-29de-48d0-8091-798e3c52fef4", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5baca6bf-8b5b-4451-8be2-a81837b5dd92", 0, "9abdcf10-acf7-4b26-b563-5ec61e40c230", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEMA7igW0gGfFwWpJ2RNuCY9oderj4PpyrEieKY5RJtSDU7+ezzMNJPytjPBx7scXzQ==", null, false, "e658d51e-308a-4270-b835-f3780dcbbbce", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "edccd9cd-806c-4aa4-82f3-c75b93151891", "5baca6bf-8b5b-4451-8be2-a81837b5dd92" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f198f3f-1b40-4fd8-b869-d89b0d86d6d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f52dedb1-29de-48d0-8091-798e3c52fef4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "edccd9cd-806c-4aa4-82f3-c75b93151891", "5baca6bf-8b5b-4451-8be2-a81837b5dd92" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edccd9cd-806c-4aa4-82f3-c75b93151891");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5baca6bf-8b5b-4451-8be2-a81837b5dd92");
        }
    }
}

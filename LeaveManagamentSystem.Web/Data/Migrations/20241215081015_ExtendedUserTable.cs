using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagamentSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5baca6bf-8b5b-4451-8be2-a81837b5dd92",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65c339e1-5eb2-4676-82dc-f5d6996a8e7a", new DateOnly(1950, 12, 1), "Default", "Admin", "AQAAAAIAAYagAAAAELk1kP8OQ7TSwrPzAIrf2+Az+kz8MyRJ8ydmliJhaVh4cEnaqr7PFYieGGEU5yO30Q==", "78ae7f70-b6e9-456a-9972-bda81bafdf10" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");


            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5baca6bf-8b5b-4451-8be2-a81837b5dd92",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9abdcf10-acf7-4b26-b563-5ec61e40c230", "AQAAAAIAAYagAAAAEMA7igW0gGfFwWpJ2RNuCY9oderj4PpyrEieKY5RJtSDU7+ezzMNJPytjPBx7scXzQ==", "e658d51e-308a-4270-b835-f3780dcbbbce" });
        }
    }
}

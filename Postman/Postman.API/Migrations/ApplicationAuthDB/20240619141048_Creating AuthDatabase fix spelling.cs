using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Postman.API.Migrations.ApplicationAuthDB
{
    /// <inheritdoc />
    public partial class CreatingAuthDatabasefixspelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44cf8410-26df-4328-85e9-3577d0b69eed",
                column: "Name",
                value: "Writer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44cf8410-26df-4328-85e9-3577d0b69eed",
                column: "Name",
                value: "writer");
        }
    }
}

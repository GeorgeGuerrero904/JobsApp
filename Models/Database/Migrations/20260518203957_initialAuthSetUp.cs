using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobsApp.Models.Database.Migrations
{
    /// <inheritdoc />
    public partial class initialAuthSetUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$LIObUQLwXqTc6BZQRbuUQuuQZpJVIgcrhzHfziGf75npjMSS4UNkO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "password",
                value: "");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigrationOnUserAndGroupId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "__Identity_Role",
                keyColumn: "Id",
                keyValue: new Guid("9a77dcba-4c90-49c0-aace-358d3418bd7a"));

            migrationBuilder.InsertData(
                table: "__Identity_Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("88071f9d-4fa7-4618-9d04-6d430e121e73"), null, "ROLE_ADMIN", "ROLE_ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "__Identity_Role",
                keyColumn: "Id",
                keyValue: new Guid("88071f9d-4fa7-4618-9d04-6d430e121e73"));

            migrationBuilder.InsertData(
                table: "__Identity_Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("9a77dcba-4c90-49c0-aace-358d3418bd7a"), null, "ROLE_ADMIN", "ROLE_ADMIN" });
        }
    }
}

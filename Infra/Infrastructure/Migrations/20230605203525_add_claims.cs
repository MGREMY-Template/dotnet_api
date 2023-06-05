using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_claims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "__Identity_UserClaim",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 22, "CLAIM_IDENTITY_APPFILE:GETALL", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 23, "CLAIM_IDENTITY_APPFILE:GETBYID", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 24, "CLAIM_IDENTITY_APPFILE:GETLIST", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 24);
        }
    }
}

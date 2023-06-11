using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_claims_APPFILE_POST : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 22,
                column: "ClaimType",
                value: "CLAIM_APPFILE:GETALL");

            migrationBuilder.UpdateData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 23,
                column: "ClaimType",
                value: "CLAIM_APPFILE:GETBYID");

            migrationBuilder.UpdateData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 24,
                column: "ClaimType",
                value: "CLAIM_APPFILE:GETLIST");

            migrationBuilder.InsertData(
                table: "__Identity_UserClaim",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 25, "CLAIM_APPFILE:POST_APPFILE", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.UpdateData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 22,
                column: "ClaimType",
                value: "CLAIM_IDENTITY_APPFILE:GETALL");

            migrationBuilder.UpdateData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 23,
                column: "ClaimType",
                value: "CLAIM_IDENTITY_APPFILE:GETBYID");

            migrationBuilder.UpdateData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 24,
                column: "ClaimType",
                value: "CLAIM_IDENTITY_APPFILE:GETLIST");
        }
    }
}

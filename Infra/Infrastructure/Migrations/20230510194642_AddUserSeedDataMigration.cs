using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSeedDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__App_AppSetting");

            migrationBuilder.InsertData(
                table: "__Identity_User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd"), 0, "1de48a50-9fa2-4e0a-a0bb-f317e17ce8f2", "admin@admin.admin", true, false, null, "ADMIN@ADMIN.ADMIN", "ADMIN", "AQAAAAIAAYagAAAAEDxk5EthOl3tW2BdXKdmAoxUUAvai68jo1xp7mb1Id0qfBcFB1N+vvHisZ8/TIs9Cw==", null, false, null, false, "admin" });

            migrationBuilder.InsertData(
                table: "__Identity_UserClaim",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "CLAIM_IDENTITY_USER:GETALL", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 2, "CLAIM_IDENTITY_USER:GETBYID", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 3, "CLAIM_IDENTITY_USER:GETLIST", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 4, "CLAIM_IDENTITY_ROLE:GETALL", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 5, "CLAIM_IDENTITY_ROLE:GETBYID", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 6, "CLAIM_IDENTITY_ROLE:GETLIST", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 7, "CLAIM_IDENTITY_ROLECLAIM:GETALL", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 8, "CLAIM_IDENTITY_ROLECLAIM:GETBYID", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 9, "CLAIM_IDENTITY_ROLECLAIM:GETLIST", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 10, "CLAIM_IDENTITY_USERCLAIM:GETALL", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 11, "CLAIM_IDENTITY_USERCLAIM:GETBYID", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 12, "CLAIM_IDENTITY_USERCLAIM:GETLIST", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 13, "CLAIM_IDENTITY_USERLOGIN:GETALL", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 14, "CLAIM_IDENTITY_USERLOGIN:GETBYID", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 15, "CLAIM_IDENTITY_USERLOGIN:GETLIST", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 16, "CLAIM_IDENTITY_USERROLE:GETALL", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 17, "CLAIM_IDENTITY_USERROLE:GETBYID", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 18, "CLAIM_IDENTITY_USERROLE:GETLIST", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 19, "CLAIM_IDENTITY_USERTOKEN:GETALL", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 20, "CLAIM_IDENTITY_USERTOKEN:GETBYID", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") },
                    { 21, "CLAIM_IDENTITY_USERTOKEN:GETLIST", "1", new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") }
                });

            migrationBuilder.InsertData(
                table: "__Identity_UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("88071f9d-4fa7-4618-9d04-6d430e121e73"), new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "__Identity_UserClaim",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "__Identity_UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("88071f9d-4fa7-4618-9d04-6d430e121e73"), new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd") });

            migrationBuilder.DeleteData(
                table: "__Identity_User",
                keyColumn: "Id",
                keyValue: new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd"));

            migrationBuilder.CreateTable(
                name: "__App_AppSetting",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___App_AppSetting", x => x.Name);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "__App_AppSetting",
                columns: new[] { "Name", "Value" },
                values: new object[] { "IS_INITIALIZED", "0" });
        }
    }
}

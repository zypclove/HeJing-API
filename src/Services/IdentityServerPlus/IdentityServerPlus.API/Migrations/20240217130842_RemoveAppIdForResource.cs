using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServerPlus.API.Migrations
{
    public partial class RemoveAppIdForResource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppResource_Apps_AppId",
                table: "AppResource");

            migrationBuilder.DropIndex(
                name: "IX_AppResource_AppId",
                table: "AppResource");

            migrationBuilder.DropColumn(
                name: "AppId",
                table: "AppResource");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "OrganRole",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "编号");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "OrganRole");

            migrationBuilder.AddColumn<Guid>(
                name: "AppId",
                table: "AppResource",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "应用标识");

            migrationBuilder.CreateIndex(
                name: "IX_AppResource_AppId",
                table: "AppResource",
                column: "AppId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppResource_Apps_AppId",
                table: "AppResource",
                column: "AppId",
                principalTable: "Apps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServerPlus.API.Migrations
{
    public partial class UpdateUserIdIsNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "OrganEmployee",
                type: "uniqueidentifier",
                nullable: true,
                comment: "用户标识",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "用户标识");

            migrationBuilder.CreateIndex(
                name: "IX_OrganEmployee_UserId",
                table: "OrganEmployee",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganEmployee_OrganUser_UserId",
                table: "OrganEmployee",
                column: "UserId",
                principalTable: "OrganUser",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganEmployee_OrganUser_UserId",
                table: "OrganEmployee");

            migrationBuilder.DropIndex(
                name: "IX_OrganEmployee_UserId",
                table: "OrganEmployee");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "OrganEmployee",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "用户标识",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "用户标识");
        }
    }
}

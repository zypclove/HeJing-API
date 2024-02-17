using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServerPlus.API.Migrations
{
    public partial class UpdateDepartmentTreeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppResource_OrganDepartment_OrganDepartmentId",
                table: "AppResource");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganDepartment_AppResource_ParentId",
                table: "OrganDepartment");

            migrationBuilder.DropIndex(
                name: "IX_AppResource_OrganDepartmentId",
                table: "AppResource");

            migrationBuilder.DropColumn(
                name: "OrganDepartmentId",
                table: "AppResource");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganDepartment_OrganDepartment_ParentId",
                table: "OrganDepartment",
                column: "ParentId",
                principalTable: "OrganDepartment",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganDepartment_OrganDepartment_ParentId",
                table: "OrganDepartment");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganDepartmentId",
                table: "AppResource",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppResource_OrganDepartmentId",
                table: "AppResource",
                column: "OrganDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppResource_OrganDepartment_OrganDepartmentId",
                table: "AppResource",
                column: "OrganDepartmentId",
                principalTable: "OrganDepartment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganDepartment_AppResource_ParentId",
                table: "OrganDepartment",
                column: "ParentId",
                principalTable: "AppResource",
                principalColumn: "Id");
        }
    }
}

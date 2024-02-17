using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServerPlus.API.Migrations
{
    public partial class AddMenuTree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "OrganDepartment",
                type: "uniqueidentifier",
                nullable: true,
                comment: "父级标识");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentNodeId",
                table: "OrganDepartment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrganDepartmentId",
                table: "AppMenu",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "AppMenu",
                type: "uniqueidentifier",
                nullable: true,
                comment: "父级标识");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentNodeId",
                table: "AppMenu",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganDepartment_ParentNodeId",
                table: "OrganDepartment",
                column: "ParentNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMenu_OrganDepartmentId",
                table: "AppMenu",
                column: "OrganDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMenu_ParentNodeId",
                table: "AppMenu",
                column: "ParentNodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppMenu_AppMenu_ParentNodeId",
                table: "AppMenu",
                column: "ParentNodeId",
                principalTable: "AppMenu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppMenu_OrganDepartment_OrganDepartmentId",
                table: "AppMenu",
                column: "OrganDepartmentId",
                principalTable: "OrganDepartment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganDepartment_AppMenu_ParentNodeId",
                table: "OrganDepartment",
                column: "ParentNodeId",
                principalTable: "AppMenu",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppMenu_AppMenu_ParentNodeId",
                table: "AppMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_AppMenu_OrganDepartment_OrganDepartmentId",
                table: "AppMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganDepartment_AppMenu_ParentNodeId",
                table: "OrganDepartment");

            migrationBuilder.DropIndex(
                name: "IX_OrganDepartment_ParentNodeId",
                table: "OrganDepartment");

            migrationBuilder.DropIndex(
                name: "IX_AppMenu_OrganDepartmentId",
                table: "AppMenu");

            migrationBuilder.DropIndex(
                name: "IX_AppMenu_ParentNodeId",
                table: "AppMenu");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "OrganDepartment");

            migrationBuilder.DropColumn(
                name: "ParentNodeId",
                table: "OrganDepartment");

            migrationBuilder.DropColumn(
                name: "OrganDepartmentId",
                table: "AppMenu");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "AppMenu");

            migrationBuilder.DropColumn(
                name: "ParentNodeId",
                table: "AppMenu");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServerPlus.API.Migrations
{
    public partial class UpdateTreeEntityForSecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppResource_AppResource_ParentNodeId",
                table: "AppResource");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganDepartment_AppResource_ParentNodeId",
                table: "OrganDepartment");

            migrationBuilder.DropIndex(
                name: "IX_OrganDepartment_ParentNodeId",
                table: "OrganDepartment");

            migrationBuilder.DropIndex(
                name: "IX_AppResource_ParentNodeId",
                table: "AppResource");

            migrationBuilder.DropColumn(
                name: "ParentNodeId",
                table: "OrganDepartment");

            migrationBuilder.DropColumn(
                name: "ParentNodeId",
                table: "AppResource");

            migrationBuilder.CreateIndex(
                name: "IX_OrganDepartment_ParentId",
                table: "OrganDepartment",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppResource_ParentId",
                table: "AppResource",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppResource_AppResource_ParentId",
                table: "AppResource",
                column: "ParentId",
                principalTable: "AppResource",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganDepartment_AppResource_ParentId",
                table: "OrganDepartment",
                column: "ParentId",
                principalTable: "AppResource",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppResource_AppResource_ParentId",
                table: "AppResource");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganDepartment_AppResource_ParentId",
                table: "OrganDepartment");

            migrationBuilder.DropIndex(
                name: "IX_OrganDepartment_ParentId",
                table: "OrganDepartment");

            migrationBuilder.DropIndex(
                name: "IX_AppResource_ParentId",
                table: "AppResource");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentNodeId",
                table: "OrganDepartment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentNodeId",
                table: "AppResource",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganDepartment_ParentNodeId",
                table: "OrganDepartment",
                column: "ParentNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppResource_ParentNodeId",
                table: "AppResource",
                column: "ParentNodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppResource_AppResource_ParentNodeId",
                table: "AppResource",
                column: "ParentNodeId",
                principalTable: "AppResource",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganDepartment_AppResource_ParentNodeId",
                table: "OrganDepartment",
                column: "ParentNodeId",
                principalTable: "AppResource",
                principalColumn: "Id");
        }
    }
}

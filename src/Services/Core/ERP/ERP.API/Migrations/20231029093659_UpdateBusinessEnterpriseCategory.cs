using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.API.Migrations
{
    public partial class UpdateBusinessEnterpriseCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessEnterprise_SupplierCategory_CategoryId",
                table: "BusinessEnterprise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierCategory",
                table: "SupplierCategory");

            migrationBuilder.RenameTable(
                name: "SupplierCategory",
                newName: "BusinessEnterpriseCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessEnterpriseCategory",
                table: "BusinessEnterpriseCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessEnterprise_BusinessEnterpriseCategory_CategoryId",
                table: "BusinessEnterprise",
                column: "CategoryId",
                principalTable: "BusinessEnterpriseCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessEnterprise_BusinessEnterpriseCategory_CategoryId",
                table: "BusinessEnterprise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessEnterpriseCategory",
                table: "BusinessEnterpriseCategory");

            migrationBuilder.RenameTable(
                name: "BusinessEnterpriseCategory",
                newName: "SupplierCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierCategory",
                table: "SupplierCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessEnterprise_SupplierCategory_CategoryId",
                table: "BusinessEnterprise",
                column: "CategoryId",
                principalTable: "SupplierCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

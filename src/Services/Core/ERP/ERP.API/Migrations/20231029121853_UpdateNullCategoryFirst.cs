using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.API.Migrations
{
    public partial class UpdateNullCategoryFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessEnterprise_BusinessEnterpriseCategory_CategoryId",
                table: "BusinessEnterprise");

            migrationBuilder.DropForeignKey(
                name: "FK_Goods_GoodsCategory_CategoryId",
                table: "Goods");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Goods",
                type: "uniqueidentifier",
                nullable: true,
                comment: "物品类别标识",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "物品类别标识");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "BusinessEnterprise",
                type: "uniqueidentifier",
                nullable: true,
                comment: "企业类别标识",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "企业类别标识");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessEnterprise_BusinessEnterpriseCategory_CategoryId",
                table: "BusinessEnterprise",
                column: "CategoryId",
                principalTable: "BusinessEnterpriseCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_GoodsCategory_CategoryId",
                table: "Goods",
                column: "CategoryId",
                principalTable: "GoodsCategory",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessEnterprise_BusinessEnterpriseCategory_CategoryId",
                table: "BusinessEnterprise");

            migrationBuilder.DropForeignKey(
                name: "FK_Goods_GoodsCategory_CategoryId",
                table: "Goods");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Goods",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "物品类别标识",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "物品类别标识");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "BusinessEnterprise",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "企业类别标识",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "企业类别标识");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessEnterprise_BusinessEnterpriseCategory_CategoryId",
                table: "BusinessEnterprise",
                column: "CategoryId",
                principalTable: "BusinessEnterpriseCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_GoodsCategory_CategoryId",
                table: "Goods",
                column: "CategoryId",
                principalTable: "GoodsCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.API.Migrations
{
    public partial class AddContractAndOther : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.CreateTable(
                name: "SupplierCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "类别编号"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "类别名称"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierCategory", x => x.Id);
                },
                comment: "供应商类别");

            migrationBuilder.CreateTable(
                name: "BusinessEnterprise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    EnterpriseType = table.Column<int>(type: "int", nullable: false, comment: "企业类型"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "企业全称"),
                    ShortName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "企业简称"),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "企业类别标识"),
                    ContactPerson = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "联系人"),
                    ContactTel = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "联系电话"),
                    ContactAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "联系地址"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessEnterprise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessEnterprise_SupplierCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SupplierCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "业务企业");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEnterprise_CategoryId",
                table: "BusinessEnterprise",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessEnterprise");

            migrationBuilder.DropTable(
                name: "SupplierCategory");

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    Address = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "地址"),
                    ContactPerson = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "联系人"),
                    ContactTel = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "联系电话"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "电子邮件"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "名称")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                },
                comment: "供应商");
        }
    }
}

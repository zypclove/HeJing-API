using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.API.Migrations
{
    public partial class AddSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "名称"),
                    Address = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "地址"),
                    ContactPerson = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "联系人"),
                    ContactTel = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "联系电话"),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "电子邮件"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                },
                comment: "供应商");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}

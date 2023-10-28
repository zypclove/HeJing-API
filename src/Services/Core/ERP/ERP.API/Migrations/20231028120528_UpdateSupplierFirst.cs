using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.API.Migrations
{
    public partial class UpdateSupplierFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastModifyTime",
                table: "Supplier",
                type: "datetimeoffset",
                nullable: false,
                comment: "最后更新时间",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreateTime",
                table: "Supplier",
                type: "datetimeoffset",
                nullable: false,
                comment: "创建时间",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Supplier",
                type: "uniqueidentifier",
                nullable: false,
                comment: "标识",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastModifyTime",
                table: "Supplier",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldComment: "最后更新时间");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreateTime",
                table: "Supplier",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldComment: "创建时间");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Supplier",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "标识");
        }
    }
}

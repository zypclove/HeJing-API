using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.API.Migrations
{
    public partial class UpdateContractSecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PartyA",
                table: "Contract",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                comment: "甲方");

            migrationBuilder.AddColumn<string>(
                name: "PartyB",
                table: "Contract",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                comment: "乙方");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartyA",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "PartyB",
                table: "Contract");
        }
    }
}

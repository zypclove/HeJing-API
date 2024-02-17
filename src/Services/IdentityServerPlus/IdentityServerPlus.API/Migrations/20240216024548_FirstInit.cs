using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServerPlus.API.Migrations
{
    public partial class FirstInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "编号"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "名称"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    EnabledFlag = table.Column<bool>(type: "bit", nullable: false, comment: "是否启用"),
                    SortNo = table.Column<int>(type: "int", nullable: false, comment: "排序号"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps", x => x.Id);
                },
                comment: "应用");

            migrationBuilder.CreateTable(
                name: "Organs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "编号"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "名称"),
                    ShortName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "简称"),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "联系地址"),
                    ZipCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "邮政编码"),
                    Tel = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "联系电话"),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "电子邮箱"),
                    ContactPerson = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "联系人"),
                    ContactPersonTel = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "联系人电话"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    EnabledFlag = table.Column<bool>(type: "bit", nullable: false, comment: "是否启用"),
                    SortNo = table.Column<int>(type: "int", nullable: false, comment: "排序号"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organs", x => x.Id);
                },
                comment: "机构");

            migrationBuilder.CreateTable(
                name: "AppMenu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "应用标识"),
                    Path = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "路径"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "名称"),
                    Component = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "组件"),
                    Icon = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "图标"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "标题"),
                    IsLink = table.Column<bool>(type: "bit", nullable: true, comment: "是否外链"),
                    IsHide = table.Column<bool>(type: "bit", nullable: true, comment: "是否隐藏"),
                    IsFull = table.Column<bool>(type: "bit", nullable: true, comment: "是否全屏"),
                    IsAffix = table.Column<bool>(type: "bit", nullable: true, comment: "是否固定"),
                    IsKeepAlive = table.Column<bool>(type: "bit", nullable: true, comment: "是否缓存"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    SortNo = table.Column<int>(type: "int", nullable: false, comment: "排序号"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppMenu_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "菜单");

            migrationBuilder.CreateTable(
                name: "OrganDepartment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    OrganId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "机构标识"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "编号"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "名称"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    EnabledFlag = table.Column<bool>(type: "bit", nullable: false, comment: "是否启用"),
                    SortNo = table.Column<int>(type: "int", nullable: false, comment: "排序号"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganDepartment_Organs_OrganId",
                        column: x => x.OrganId,
                        principalTable: "Organs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "部门");

            migrationBuilder.CreateTable(
                name: "RoleMenu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    RoleId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "角色标识"),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "菜单标识"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleMenu_AppMenu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "AppMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "角色菜单");

            migrationBuilder.CreateTable(
                name: "OrganStaff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "部门标识"),
                    UserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "用户标识"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "编号"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "姓名"),
                    NickName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "昵称"),
                    Tel = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "联系电话"),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "电子邮箱"),
                    Gender = table.Column<int>(type: "int", maxLength: 200, nullable: false, comment: "性别"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    EnabledFlag = table.Column<bool>(type: "bit", nullable: false, comment: "是否启用"),
                    SortNo = table.Column<int>(type: "int", nullable: false, comment: "排序号"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganStaff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganStaff_OrganDepartment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "OrganDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "职员");

            migrationBuilder.CreateIndex(
                name: "IX_AppMenu_AppId",
                table: "AppMenu",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganDepartment_OrganId",
                table: "OrganDepartment",
                column: "OrganId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganStaff_DepartmentId",
                table: "OrganStaff",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenu_MenuId",
                table: "RoleMenu",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganStaff");

            migrationBuilder.DropTable(
                name: "RoleMenu");

            migrationBuilder.DropTable(
                name: "OrganDepartment");

            migrationBuilder.DropTable(
                name: "AppMenu");

            migrationBuilder.DropTable(
                name: "Organs");

            migrationBuilder.DropTable(
                name: "Apps");
        }
    }
}

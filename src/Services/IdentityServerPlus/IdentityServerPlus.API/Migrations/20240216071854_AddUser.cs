using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServerPlus.API.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganDepartment_AppMenu_ParentNodeId",
                table: "OrganDepartment");

            migrationBuilder.DropTable(
                name: "OrganStaff");

            migrationBuilder.DropTable(
                name: "RoleMenu");

            migrationBuilder.DropTable(
                name: "AppMenu");

            migrationBuilder.CreateTable(
                name: "AppAuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    Event = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "事件"),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "来源"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "分类"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "用户标识"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "用户名称"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAuditLog", x => x.Id);
                },
                comment: "审计日志");

            migrationBuilder.CreateTable(
                name: "AppData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "编号"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "名称"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    SortNo = table.Column<int>(type: "int", nullable: false, comment: "排序号"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppData", x => x.Id);
                },
                comment: "数据");

            migrationBuilder.CreateTable(
                name: "AppFunction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "编号"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "名称"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    SortNo = table.Column<int>(type: "int", nullable: false, comment: "排序号"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFunction", x => x.Id);
                },
                comment: "功能");

            migrationBuilder.CreateTable(
                name: "AppOperationLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    Event = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "事件"),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "来源"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "分类"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "用户标识"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "用户名称"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOperationLog", x => x.Id);
                },
                comment: "操作日志");

            migrationBuilder.CreateTable(
                name: "AppResource",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "应用标识"),
                    ResourceType = table.Column<int>(type: "int", nullable: false, comment: "资源类型"),
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
                    OrganDepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间"),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "父级标识"),
                    ParentNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppResource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppResource_AppResource_ParentNodeId",
                        column: x => x.ParentNodeId,
                        principalTable: "AppResource",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppResource_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppResource_OrganDepartment_OrganDepartmentId",
                        column: x => x.OrganDepartmentId,
                        principalTable: "OrganDepartment",
                        principalColumn: "Id");
                },
                comment: "资源");

            migrationBuilder.CreateTable(
                name: "OrganEmployee",
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
                    table.PrimaryKey("PK_OrganEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganEmployee_OrganDepartment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "OrganDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "员工");

            migrationBuilder.CreateTable(
                name: "OrganRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "名称"),
                    SortNo = table.Column<int>(type: "int", nullable: false, comment: "排序号"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganRole", x => x.Id);
                },
                comment: "角色");

            migrationBuilder.CreateTable(
                name: "OrganUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "用户名称"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "邮箱"),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false, comment: "邮箱已确认"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "手机"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false, comment: "手机已确认"),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false, comment: "锁定已启用"),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "最后锁定时间"),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false, comment: "双因素启用"),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false, comment: "访问失败计数"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganUser", x => x.Id);
                },
                comment: "用户");

            migrationBuilder.CreateTable(
                name: "OrganRoleData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false, comment: "角色标识"),
                    DataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "数据标识"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganRoleData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganRoleData_AppData_DataId",
                        column: x => x.DataId,
                        principalTable: "AppData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganRoleData_OrganRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OrganRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "角色数据");

            migrationBuilder.CreateTable(
                name: "OrganRoleFunction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false, comment: "角色标识"),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "资源标识"),
                    FunctionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "功能标识"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganRoleFunction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganRoleFunction_AppFunction_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "AppFunction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganRoleFunction_AppResource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "AppResource",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganRoleFunction_OrganRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OrganRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "角色功能");

            migrationBuilder.CreateTable(
                name: "OrganRoleResource",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false, comment: "角色标识"),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "资源标识"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganRoleResource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganRoleResource_AppResource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "AppResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganRoleResource_OrganRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OrganRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "角色资源");

            migrationBuilder.CreateTable(
                name: "OrganUserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "用户标识"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false, comment: "角色标识"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganUserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganUserRole_OrganRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OrganRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganUserRole_OrganUser_UserId",
                        column: x => x.UserId,
                        principalTable: "OrganUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "用户角色");

            migrationBuilder.CreateIndex(
                name: "IX_AppResource_AppId",
                table: "AppResource",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_AppResource_OrganDepartmentId",
                table: "AppResource",
                column: "OrganDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppResource_ParentNodeId",
                table: "AppResource",
                column: "ParentNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganEmployee_DepartmentId",
                table: "OrganEmployee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganRoleData_DataId",
                table: "OrganRoleData",
                column: "DataId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganRoleData_RoleId",
                table: "OrganRoleData",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganRoleFunction_FunctionId",
                table: "OrganRoleFunction",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganRoleFunction_ResourceId",
                table: "OrganRoleFunction",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganRoleFunction_RoleId",
                table: "OrganRoleFunction",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganRoleResource_ResourceId",
                table: "OrganRoleResource",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganRoleResource_RoleId",
                table: "OrganRoleResource",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganUserRole_RoleId",
                table: "OrganUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganUserRole_UserId",
                table: "OrganUserRole",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganDepartment_AppResource_ParentNodeId",
                table: "OrganDepartment",
                column: "ParentNodeId",
                principalTable: "AppResource",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganDepartment_AppResource_ParentNodeId",
                table: "OrganDepartment");

            migrationBuilder.DropTable(
                name: "AppAuditLog");

            migrationBuilder.DropTable(
                name: "AppOperationLog");

            migrationBuilder.DropTable(
                name: "OrganEmployee");

            migrationBuilder.DropTable(
                name: "OrganRoleData");

            migrationBuilder.DropTable(
                name: "OrganRoleFunction");

            migrationBuilder.DropTable(
                name: "OrganRoleResource");

            migrationBuilder.DropTable(
                name: "OrganUserRole");

            migrationBuilder.DropTable(
                name: "AppData");

            migrationBuilder.DropTable(
                name: "AppFunction");

            migrationBuilder.DropTable(
                name: "AppResource");

            migrationBuilder.DropTable(
                name: "OrganRole");

            migrationBuilder.DropTable(
                name: "OrganUser");

            migrationBuilder.CreateTable(
                name: "AppMenu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "应用标识"),
                    ParentNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Component = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "组件"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    Icon = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "图标"),
                    IsAffix = table.Column<bool>(type: "bit", nullable: true, comment: "是否固定"),
                    IsFull = table.Column<bool>(type: "bit", nullable: true, comment: "是否全屏"),
                    IsHide = table.Column<bool>(type: "bit", nullable: true, comment: "是否隐藏"),
                    IsKeepAlive = table.Column<bool>(type: "bit", nullable: true, comment: "是否缓存"),
                    IsLink = table.Column<bool>(type: "bit", nullable: true, comment: "是否外链"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "名称"),
                    OrganDepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "父级标识"),
                    Path = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "路径"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    SortNo = table.Column<int>(type: "int", nullable: false, comment: "排序号"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "标题")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppMenu_AppMenu_ParentNodeId",
                        column: x => x.ParentNodeId,
                        principalTable: "AppMenu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppMenu_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppMenu_OrganDepartment_OrganDepartmentId",
                        column: x => x.OrganDepartmentId,
                        principalTable: "OrganDepartment",
                        principalColumn: "Id");
                },
                comment: "菜单");

            migrationBuilder.CreateTable(
                name: "OrganStaff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "部门标识"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "编号"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "电子邮箱"),
                    EnabledFlag = table.Column<bool>(type: "bit", nullable: false, comment: "是否启用"),
                    Gender = table.Column<int>(type: "int", maxLength: 200, nullable: false, comment: "性别"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "姓名"),
                    NickName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "昵称"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    SortNo = table.Column<int>(type: "int", nullable: false, comment: "排序号"),
                    Tel = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "联系电话"),
                    UserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "用户标识")
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

            migrationBuilder.CreateTable(
                name: "RoleMenu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "菜单标识"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间"),
                    RoleId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "角色标识")
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

            migrationBuilder.CreateIndex(
                name: "IX_AppMenu_AppId",
                table: "AppMenu",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMenu_OrganDepartmentId",
                table: "AppMenu",
                column: "OrganDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMenu_ParentNodeId",
                table: "AppMenu",
                column: "ParentNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganStaff_DepartmentId",
                table: "OrganStaff",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenu_MenuId",
                table: "RoleMenu",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganDepartment_AppMenu_ParentNodeId",
                table: "OrganDepartment",
                column: "ParentNodeId",
                principalTable: "AppMenu",
                principalColumn: "Id");
        }
    }
}

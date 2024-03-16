using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommonServer.API.Migrations
{
    /// <inheritdoc />
    public partial class FirstInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间"),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "父级标识")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppResource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppResource_AppResource_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AppResource",
                        principalColumn: "Id");
                },
                comment: "资源");

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
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间"),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "父级标识")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganDepartment_OrganDepartment_ParentId",
                        column: x => x.ParentId,
                        principalTable: "OrganDepartment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganDepartment_Organs_OrganId",
                        column: x => x.OrganId,
                        principalTable: "Organs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "部门");

            migrationBuilder.CreateTable(
                name: "OrganRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    OrganId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "机构标识"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "编号"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "名称"),
                    SortNo = table.Column<int>(type: "int", nullable: false, comment: "排序号"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganRole_Organs_OrganId",
                        column: x => x.OrganId,
                        principalTable: "Organs",
                        principalColumn: "Id");
                },
                comment: "角色");

            migrationBuilder.CreateTable(
                name: "OrganEmployee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "部门标识"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true, comment: "用户标识"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "姓名"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "编号"),
                    Gender = table.Column<int>(type: "int", maxLength: 200, nullable: false, comment: "性别"),
                    NickName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "昵称"),
                    Tel = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "联系电话"),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "电子邮箱"),
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
                name: "OrganEmployeeRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "用户标识"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false, comment: "角色标识"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganEmployeeRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganEmployeeRole_OrganEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "OrganEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganEmployeeRole_OrganRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OrganRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "员工角色");

            migrationBuilder.CreateIndex(
                name: "IX_AppResource_ParentId",
                table: "AppResource",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganDepartment_OrganId",
                table: "OrganDepartment",
                column: "OrganId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganDepartment_ParentId",
                table: "OrganDepartment",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganEmployee_DepartmentId",
                table: "OrganEmployee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganEmployeeRole_EmployeeId",
                table: "OrganEmployeeRole",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganEmployeeRole_RoleId",
                table: "OrganEmployeeRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganRole_OrganId",
                table: "OrganRole",
                column: "OrganId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppOperationLog");

            migrationBuilder.DropTable(
                name: "Apps");

            migrationBuilder.DropTable(
                name: "OrganEmployeeRole");

            migrationBuilder.DropTable(
                name: "OrganRoleData");

            migrationBuilder.DropTable(
                name: "OrganRoleFunction");

            migrationBuilder.DropTable(
                name: "OrganRoleResource");

            migrationBuilder.DropTable(
                name: "OrganEmployee");

            migrationBuilder.DropTable(
                name: "AppData");

            migrationBuilder.DropTable(
                name: "AppFunction");

            migrationBuilder.DropTable(
                name: "AppResource");

            migrationBuilder.DropTable(
                name: "OrganRole");

            migrationBuilder.DropTable(
                name: "OrganDepartment");

            migrationBuilder.DropTable(
                name: "Organs");
        }
    }
}

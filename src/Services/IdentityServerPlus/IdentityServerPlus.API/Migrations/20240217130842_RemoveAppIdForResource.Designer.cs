﻿// <auto-generated />
using System;
using IdentityServerPlus.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IdentityServerPlus.API.Migrations
{
    [DbContext(typeof(IdentityServerPlusDbContext))]
    [Migration("20240217130842_RemoveAppIdForResource")]
    partial class RemoveAppIdForResource
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.AppAuditLog", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("分类");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Event")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("事件");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("来源");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("用户标识");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("用户名称");

                    b.HasKey("Id");

                    b.ToTable("AppAuditLog");

                    b.HasComment("审计日志");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.AppData", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("编号");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("名称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<int>("SortNo")
                        .HasColumnType("int")
                        .HasComment("排序号");

                    b.HasKey("Id");

                    b.ToTable("AppData");

                    b.HasComment("数据");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.AppFunction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("编号");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("名称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<int>("SortNo")
                        .HasColumnType("int")
                        .HasComment("排序号");

                    b.HasKey("Id");

                    b.ToTable("AppFunction");

                    b.HasComment("功能");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.AppOperationLog", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("分类");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Event")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("事件");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("来源");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("用户标识");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("用户名称");

                    b.HasKey("Id");

                    b.ToTable("AppOperationLog");

                    b.HasComment("操作日志");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.AppResource", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Component")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("组件");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<string>("Icon")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("图标");

                    b.Property<bool?>("IsAffix")
                        .HasColumnType("bit")
                        .HasComment("是否固定");

                    b.Property<bool?>("IsFull")
                        .HasColumnType("bit")
                        .HasComment("是否全屏");

                    b.Property<bool?>("IsHide")
                        .HasColumnType("bit")
                        .HasComment("是否隐藏");

                    b.Property<bool?>("IsKeepAlive")
                        .HasColumnType("bit")
                        .HasComment("是否缓存");

                    b.Property<bool?>("IsLink")
                        .HasColumnType("bit")
                        .HasComment("是否外链");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("名称");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("父级标识");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("路径");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<int>("ResourceType")
                        .HasColumnType("int")
                        .HasComment("资源类型");

                    b.Property<int>("SortNo")
                        .HasColumnType("int")
                        .HasComment("排序号");

                    b.Property<string>("Title")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("AppResource");

                    b.HasComment("资源");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.Apps", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("编号");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<bool>("EnabledFlag")
                        .HasColumnType("bit")
                        .HasComment("是否启用");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("名称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<int>("SortNo")
                        .HasColumnType("int")
                        .HasComment("排序号");

                    b.HasKey("Id");

                    b.ToTable("Apps");

                    b.HasComment("应用");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.OrganDepartment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("编号");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<bool>("EnabledFlag")
                        .HasColumnType("bit")
                        .HasComment("是否启用");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("名称");

                    b.Property<Guid>("OrganId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("机构标识");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("父级标识");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<int>("SortNo")
                        .HasColumnType("int")
                        .HasComment("排序号");

                    b.HasKey("Id");

                    b.HasIndex("OrganId");

                    b.HasIndex("ParentId");

                    b.ToTable("OrganDepartment");

                    b.HasComment("部门");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.OrganEmployee", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("编号");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("部门标识");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("电子邮箱");

                    b.Property<bool>("EnabledFlag")
                        .HasColumnType("bit")
                        .HasComment("是否启用");

                    b.Property<int>("Gender")
                        .HasMaxLength(200)
                        .HasColumnType("int")
                        .HasComment("性别");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("姓名");

                    b.Property<string>("NickName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("昵称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<int>("SortNo")
                        .HasColumnType("int")
                        .HasComment("排序号");

                    b.Property<string>("Tel")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("联系电话");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("用户标识");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("OrganEmployee");

                    b.HasComment("员工");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.OrganRole", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("编号");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("名称");

                    b.Property<int>("SortNo")
                        .HasColumnType("int")
                        .HasComment("排序号");

                    b.HasKey("Id");

                    b.ToTable("OrganRole");

                    b.HasComment("角色");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.OrganRoleData", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<Guid?>("DataId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("数据标识");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<Guid>("RoleId")
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier")
                        .HasComment("角色标识");

                    b.HasKey("Id");

                    b.HasIndex("DataId");

                    b.HasIndex("RoleId");

                    b.ToTable("OrganRoleData");

                    b.HasComment("角色数据");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.OrganRoleFunction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<Guid>("FunctionId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("功能标识");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<Guid?>("ResourceId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("资源标识");

                    b.Property<Guid>("RoleId")
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier")
                        .HasComment("角色标识");

                    b.HasKey("Id");

                    b.HasIndex("FunctionId");

                    b.HasIndex("ResourceId");

                    b.HasIndex("RoleId");

                    b.ToTable("OrganRoleFunction");

                    b.HasComment("角色功能");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.OrganRoleResource", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("资源标识");

                    b.Property<Guid>("RoleId")
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier")
                        .HasComment("角色标识");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.HasIndex("RoleId");

                    b.ToTable("OrganRoleResource");

                    b.HasComment("角色资源");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.Organs", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("联系地址");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("编号");

                    b.Property<string>("ContactPerson")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("联系人");

                    b.Property<string>("ContactPersonTel")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("联系人电话");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("电子邮箱");

                    b.Property<bool>("EnabledFlag")
                        .HasColumnType("bit")
                        .HasComment("是否启用");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("名称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<string>("ShortName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("简称");

                    b.Property<int>("SortNo")
                        .HasColumnType("int")
                        .HasComment("排序号");

                    b.Property<string>("Tel")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("联系电话");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("邮政编码");

                    b.HasKey("Id");

                    b.ToTable("Organs");

                    b.HasComment("机构");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.OrganUser", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int")
                        .HasComment("访问失败计数");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("邮箱");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit")
                        .HasComment("邮箱已确认");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit")
                        .HasComment("锁定已启用");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后锁定时间");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("手机");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit")
                        .HasComment("手机已确认");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit")
                        .HasComment("双因素启用");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("用户名称");

                    b.HasKey("Id");

                    b.ToTable("OrganUser");

                    b.HasComment("用户");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.OrganUserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<Guid>("RoleId")
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier")
                        .HasComment("角色标识");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("用户标识");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("OrganUserRole");

                    b.HasComment("用户角色");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.AppResource", b =>
                {
                    b.HasOne("IdentityServerPlus.Domain.Model.AppResource", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.OrganDepartment", b =>
                {
                    b.HasOne("IdentityServerPlus.Domain.Model.Organs", "Organ")
                        .WithMany()
                        .HasForeignKey("OrganId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IdentityServerPlus.Domain.Model.OrganDepartment", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Organ");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.OrganEmployee", b =>
                {
                    b.HasOne("IdentityServerPlus.Domain.Model.OrganDepartment", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IdentityServerPlus.Domain.Model.OrganUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.OrganRoleData", b =>
                {
                    b.HasOne("IdentityServerPlus.Domain.Model.AppData", "Data")
                        .WithMany()
                        .HasForeignKey("DataId");

                    b.HasOne("IdentityServerPlus.Domain.Model.OrganRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Data");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.OrganRoleFunction", b =>
                {
                    b.HasOne("IdentityServerPlus.Domain.Model.AppFunction", "Function")
                        .WithMany()
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IdentityServerPlus.Domain.Model.AppResource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId");

                    b.HasOne("IdentityServerPlus.Domain.Model.OrganRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Function");

                    b.Navigation("Resource");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.OrganRoleResource", b =>
                {
                    b.HasOne("IdentityServerPlus.Domain.Model.AppResource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IdentityServerPlus.Domain.Model.OrganRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.OrganUserRole", b =>
                {
                    b.HasOne("IdentityServerPlus.Domain.Model.OrganRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IdentityServerPlus.Domain.Model.OrganUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.AppResource", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("IdentityServerPlus.Domain.Model.OrganDepartment", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}

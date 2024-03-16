using CommonServer.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using static MassTransit.MessageHeaders;

namespace CommonServer.Infrastructure;

public partial class CommonServerDbContext : DbContext
{
    public CommonServerDbContext(DbContextOptions<CommonServerDbContext> options)
        : base(options)
    {
    }

    #region 实体
    public virtual DbSet<Apps> Appses { get; set; } = null!;
    public virtual DbSet<AppResource> AppResources { get; set; } = null!;
    public virtual DbSet<AppFunction> AppFunctions { get; set; } = null!;
    public virtual DbSet<AppData> AppDatas { get; set; } = null!;
    public virtual DbSet<AppOperationLog> AppOperationLogs { get; set; } = null!;
    public virtual DbSet<Organs> Organses { get; set; } = null!;
    public virtual DbSet<OrganRole> OrganRoles { get; set; } = null!;
    public virtual DbSet<OrganRoleResource> OrganRoleResources { get; set; } = null!;
    public virtual DbSet<OrganRoleFunction> OrganRoleFunctions { get; set; } = null!;
    public virtual DbSet<OrganRoleData> OrganRoleDatas { get; set; } = null!;
    public virtual DbSet<OrganDepartment> OrganDepartments { get; set; } = null!;
    public virtual DbSet<OrganEmployee> OrganEmployees { get; set; } = null!;
    public virtual DbSet<OrganEmployeeRole> OrganEmployeeRoles { get; set; } = null!;
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrganRole>()
            .HasOne(e => e.Organ)
            .WithMany(e => e.Roles)
            .HasForeignKey(e => e.OrganId)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}
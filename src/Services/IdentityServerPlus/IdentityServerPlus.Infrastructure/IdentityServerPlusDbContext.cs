using IdentityServerPlus.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace IdentityServerPlus.Infrastructure;

public partial class IdentityServerPlusDbContext : DbContext
{
    public IdentityServerPlusDbContext(DbContextOptions<IdentityServerPlusDbContext> options)
        : base(options)
    {
    }

    #region 实体
    public virtual DbSet<Apps> Appses { get; set; } = null!;
    public virtual DbSet<AppResource> AppResources { get; set; } = null!;
    public virtual DbSet<AppFunction> AppFunctions { get; set; } = null!;
    public virtual DbSet<AppData> AppDatas { get; set; } = null!;
    public virtual DbSet<AppAuditLog> AppAuditLogs { get; set; } = null!;
    public virtual DbSet<AppOperationLog> AppOperationLogs { get; set; } = null!;
    public virtual DbSet<Organs> Organses { get; set; } = null!;
    public virtual DbSet<OrganUser> OrganUsers { get; set; } = null!;
    public virtual DbSet<OrganUserRole> OrganUserRoles { get; set; } = null!;
    public virtual DbSet<OrganRole> OrganRoles { get; set; } = null!;
    public virtual DbSet<OrganRoleResource> OrganRoleResources { get; set; } = null!;
    public virtual DbSet<OrganRoleFunction> OrganRoleFunctions { get; set; } = null!;
    public virtual DbSet<OrganRoleData> OrganRoleDatas { get; set; } = null!;
    public virtual DbSet<OrganDepartment> OrganDepartments { get; set; } = null!;
    public virtual DbSet<OrganEmployee> OrganEmployees { get; set; } = null!;
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
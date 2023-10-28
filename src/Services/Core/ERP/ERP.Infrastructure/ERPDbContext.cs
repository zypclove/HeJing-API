using ERP.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure;

public partial class ERPDbContext : DbContext
{
    public ERPDbContext(DbContextOptions<ERPDbContext> options)
        : base(options)
    {
    }

    #region 实体
    public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
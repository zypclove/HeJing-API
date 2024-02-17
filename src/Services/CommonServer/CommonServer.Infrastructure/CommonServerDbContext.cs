using Microsoft.EntityFrameworkCore;

namespace CommonServer.Infrastructure;

public partial class CommonServerDbContext : DbContext
{
    public CommonServerDbContext(DbContextOptions<CommonServerDbContext> options)
        : base(options)
    {
    }

    #region 实体
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
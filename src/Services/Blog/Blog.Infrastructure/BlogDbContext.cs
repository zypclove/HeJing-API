using Blog.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure;

public partial class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> options)
        : base(options)
    {
    }

    #region 实体
    public virtual DbSet<Article> Articles { get; set; } = null!;
    public virtual DbSet<ArticleCollection> ArticleCollections { get; set; } = null!;
    public virtual DbSet<ArticleTag> ArticleTags { get; set; } = null!;
    public virtual DbSet<Category> Categories { get; set; } = null!;
    public virtual DbSet<Comment> Comments { get; set; } = null!;
    public virtual DbSet<Role> Roles { get; set; } = null!;
    public virtual DbSet<Tag> Tags { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
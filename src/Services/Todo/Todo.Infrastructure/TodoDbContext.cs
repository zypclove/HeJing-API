using Microsoft.EntityFrameworkCore;
using Todo.Domain.Model;

namespace Todo.Infrastructure;

public partial class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options)
        : base(options)
    {
    }

    #region Book
    public virtual DbSet<TodoItem> TodoItems { get; set; } = null!;
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
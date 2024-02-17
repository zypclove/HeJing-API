using Microsoft.EntityFrameworkCore;

namespace CommonMormon.Infrastructure.Domain.SeedWork;

public abstract class TreeEntity<T> : Entity where T : TreeEntity<T>
{
    /// <summary>
    /// 父级标识
    /// </summary>
    [Comment("父级标识")]
    public Guid? ParentId { get; set; }
    public T? Parent { get; set; }
    /// <summary>
    /// 子集合
    /// </summary>
    [Comment("子集合")]
    public List<T>? Children { get; set; }
}
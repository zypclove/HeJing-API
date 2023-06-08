using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonMormon.Infrastructure.Domain.SeedWork;

public abstract class Entity
{
    /// <summary>
    /// 标识码
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTimeOffset CreateTime { get; set; } = DateTimeOffset.Now;
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public DateTimeOffset LastModifyTime { get; set; } = DateTimeOffset.Now;
}
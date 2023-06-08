using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.Model;

/// <summary>
/// 待办事项
/// </summary>
public partial class TodoItem : Entity
{
    public TodoItem()
    {
    }
    /// <summary>
    /// 名称
    /// </summary>
    [StringLength(50)]
    public string Name { get; set; } = null!;
    /// <summary>
    /// 说明
    /// </summary>
    [Unicode(false)]
    public string? Notes { get; set; }
    /// <summary>
    /// 已完成
    /// </summary>
    public bool Done { get; set; }
}
using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain.Model;

/// <summary>
/// 角色
/// </summary>
[Table("Role")]
public partial class Role : Entity
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = null!;
}
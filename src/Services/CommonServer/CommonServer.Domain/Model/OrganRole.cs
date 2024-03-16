using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonServer.Domain.Model;

/// <summary>
/// 角色
/// </summary>
[Table("OrganRole")]
[Comment("角色")]
public partial class OrganRole : Entity
{
    /// <summary>
    /// 编号
    /// </summary>
    [StringLength(50)]
    [Comment("编号")]
    public string Code { get; set; } = null!;
    /// <summary>
    /// 名称
    /// </summary>
    [StringLength(200)]
    [Comment("名称")]
    public string Name { get; set; } = null!;
    /// <summary>
    /// 排序号
    /// </summary>
    [Comment("排序号")]
    public int SortNo { get; set; }
}
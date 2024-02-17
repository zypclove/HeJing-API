using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServerPlus.Domain.Model;

/// <summary>
/// 用户
/// </summary>
[Table("OrganUser")]
[Comment("用户")]
public partial class OrganUser : Entity
{
    /// <summary>
    /// 用户名称
    /// </summary>
    [StringLength(50)]
    [Comment("用户名称")]
    public string UserName { get; set; } = null!;
    /// <summary>
    /// 邮箱
    /// </summary>
    [Comment("邮箱")]
    public string? Email { get; set; }
    /// <summary>
    /// 邮箱已确认
    /// </summary>
    [Comment("邮箱已确认")]
    public bool EmailConfirmed { get; set; }
    /// <summary>
    /// 手机
    /// </summary>
    [Comment("手机")]
    public string? PhoneNumber { get; set; }
    /// <summary>
    /// 手机已确认
    /// </summary>
    [Comment("手机已确认")]
    public bool PhoneNumberConfirmed { get; set; }
    /// <summary>
    /// 锁定已启用
    /// </summary>
    [Comment("锁定已启用")]
    public bool LockoutEnabled { get; set; }
    /// <summary>
    /// 最后锁定时间
    /// </summary>
    [Comment("最后锁定时间")]
    public DateTimeOffset? LockoutEnd { get; set; }
    /// <summary>
    /// 双因素启用
    /// </summary>
    [Comment("双因素启用")]
    public bool TwoFactorEnabled { get; set; }
    /// <summary>
    /// 访问失败计数
    /// </summary>
    [Comment("访问失败计数")]
    public int AccessFailedCount { get; set; }
}
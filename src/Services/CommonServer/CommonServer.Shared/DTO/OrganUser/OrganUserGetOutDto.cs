namespace CommonServer.Shared.DTO.OrganUser;

/// <summary>
/// 用户
/// </summary>
public class OrganUserGetOutDto : DtoBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 用户名称
    /// </summary>
    public string UserName { get; set; } = null!;
    /// <summary>
    /// 邮箱
    /// </summary>
    public string? Email { get; set; }
    /// <summary>
    /// 邮箱已确认
    /// </summary>
    public bool EmailConfirmed { get; set; }
    /// <summary>
    /// 手机
    /// </summary>
    public string? PhoneNumber { get; set; }
    /// <summary>
    /// 手机已确认
    /// </summary>
    public bool PhoneNumberConfirmed { get; set; }
    /// <summary>
    /// 锁定已启用
    /// </summary>
    public bool LockoutEnabled { get; set; }
    /// <summary>
    /// 最后锁定时间
    /// </summary>
    public System.DateTimeOffset? LockoutEnd { get; set; }
    /// <summary>
    /// 双因素启用
    /// </summary>
    public bool TwoFactorEnabled { get; set; }
    /// <summary>
    /// 访问失败计数
    /// </summary>
    public int AccessFailedCount { get; set; }
}


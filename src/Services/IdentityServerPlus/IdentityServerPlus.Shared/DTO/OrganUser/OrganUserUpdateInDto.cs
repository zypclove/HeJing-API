namespace IdentityServerPlus.Shared.DTO.OrganUser;

/// <summary>
/// 用户
/// </summary>
public class OrganUserUpdateInDto : DtoBase
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
    /// 手机
    /// </summary>
    public string? PhoneNumber { get; set; }
}


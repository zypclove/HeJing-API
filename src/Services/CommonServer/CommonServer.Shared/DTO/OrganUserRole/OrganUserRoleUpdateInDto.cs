namespace CommonServer.Shared.DTO.OrganUserRole;

/// <summary>
/// 用户角色
/// </summary>
public class OrganUserRoleUpdateInDto : DtoBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 用户标识
    /// </summary>
    public Guid UserId { get; set; }
    /// <summary>
    /// 角色标识
    /// </summary>
    public Guid RoleId { get; set; }
}


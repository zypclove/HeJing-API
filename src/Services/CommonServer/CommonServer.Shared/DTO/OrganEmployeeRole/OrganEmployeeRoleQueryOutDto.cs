namespace CommonServer.Shared.DTO.OrganEmployeeRole;

/// <summary>
/// 用户角色
/// </summary>
public class OrganEmployeeRoleQueryOutDto
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
    /// <summary>
    /// 创建时间
    /// </summary>
    public System.DateTimeOffset CreateTime { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public System.DateTimeOffset LastModifyTime { get; set; }
}


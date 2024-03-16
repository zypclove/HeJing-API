namespace CommonServer.Shared.DTO.OrganRoleResource;

/// <summary>
/// 角色资源
/// </summary>
public class OrganRoleResourceQueryOutDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 角色标识
    /// </summary>
    public Guid RoleId { get; set; }
    /// <summary>
    /// 资源标识
    /// </summary>
    public Guid ResourceId { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public System.DateTimeOffset CreateTime { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public System.DateTimeOffset LastModifyTime { get; set; }
}


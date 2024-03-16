namespace CommonServer.Shared.DTO.OrganRoleResource;

/// <summary>
/// 角色资源
/// </summary>
public class OrganRoleResourceUpdateInDto : DtoBase
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
}


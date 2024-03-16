namespace CommonServer.Shared.DTO.OrganRoleResource;

/// <summary>
/// 角色资源
/// </summary>
public class OrganRoleResourceBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


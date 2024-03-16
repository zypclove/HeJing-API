namespace CommonServer.Shared.DTO.OrganUserRole;

/// <summary>
/// 用户角色
/// </summary>
public class OrganUserRoleBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


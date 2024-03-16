namespace CommonServer.Shared.DTO.OrganRole;

/// <summary>
/// 角色
/// </summary>
public class OrganRoleBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


namespace CommonServer.Shared.DTO.OrganEmployeeRole;

/// <summary>
/// 用户角色
/// </summary>
public class OrganEmployeeRoleBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


namespace CommonServer.Shared.DTO.OrganRoleFunction;

/// <summary>
/// 角色功能
/// </summary>
public class OrganRoleFunctionBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


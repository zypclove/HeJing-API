namespace CommonServer.Shared.DTO.OrganRoleData;

/// <summary>
/// 角色数据
/// </summary>
public class OrganRoleDataBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


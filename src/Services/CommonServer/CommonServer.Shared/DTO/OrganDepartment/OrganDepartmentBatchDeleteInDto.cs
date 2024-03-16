namespace CommonServer.Shared.DTO.OrganDepartment;

/// <summary>
/// 部门
/// </summary>
public class OrganDepartmentBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


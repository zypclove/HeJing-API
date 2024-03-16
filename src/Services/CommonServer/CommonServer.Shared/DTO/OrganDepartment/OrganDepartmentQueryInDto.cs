namespace CommonServer.Shared.DTO.OrganDepartment;

/// <summary>
/// 部门
/// </summary>
public class OrganDepartmentQueryInDto : PagingInBase
{
    /// <summary>
    /// 机构标识
    /// </summary>
    public Guid OrganId { get; set; }
    /// <summary>
    /// 父节点
    /// </summary>
    public Guid? ParentId { get; set; }
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = string.Empty;
}


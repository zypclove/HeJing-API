namespace CommonServer.Shared.DTO.OrganDepartment;

/// <summary>
/// 部门
/// </summary>
public class OrganDepartmentGetOutDto : DtoBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 机构标识
    /// </summary>
    public Guid OrganId { get; set; }
    /// <summary>
    /// 编号
    /// </summary>
    public string Code { get; set; } = null!;
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }
    /// <summary>
    /// 是否启用
    /// </summary>
    public bool EnabledFlag { get; set; }
    /// <summary>
    /// 排序号
    /// </summary>
    public int SortNo { get; set; }
    /// <summary>
    /// 父级标识
    /// </summary>
    public Guid? ParentId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Guid? ParentNodeId { get; set; }
}


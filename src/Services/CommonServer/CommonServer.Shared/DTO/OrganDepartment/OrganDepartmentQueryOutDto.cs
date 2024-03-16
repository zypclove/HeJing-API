namespace CommonServer.Shared.DTO.OrganDepartment;

/// <summary>
/// 部门
/// </summary>
public class OrganDepartmentQueryOutDto
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
    /// 创建时间
    /// </summary>
    public System.DateTimeOffset CreateTime { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public System.DateTimeOffset LastModifyTime { get; set; }
    /// <summary>
    /// 父级标识
    /// </summary>
    public Guid? ParentId { get; set; }
    /// <summary>
    /// 子集合
    /// </summary>
    public IList<OrganDepartmentQueryOutDto>? Children { get; set; }
}


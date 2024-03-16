namespace CommonServer.Shared.DTO.OrganRole;

/// <summary>
/// 角色
/// </summary>
public class OrganRoleQueryOutDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 编号
    /// </summary>
    public string Code { get; set; } = null!;
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = null!;
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
}


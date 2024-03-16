namespace CommonServer.Shared.DTO.OrganRole;

/// <summary>
/// 角色
/// </summary>
public class OrganRoleGetOutDto : DtoBase
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
}


namespace CommonServer.Shared.DTO.OrganEmployee;

/// <summary>
/// 员工
/// </summary>
public class OrganEmployeeQueryInDto : PagingInBase
{
    /// <summary>
    /// 机构标识
    /// </summary>
    public Guid OrganId { get; set; }
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = string.Empty;
}


namespace CommonServer.Shared.DTO.Organs;

/// <summary>
/// 机构
/// </summary>
public class OrgansQueryInDto : PagingInBase
{
    /// <summary>
    /// 名称
    /// </summary>
    public string? Name { get; set; }
}


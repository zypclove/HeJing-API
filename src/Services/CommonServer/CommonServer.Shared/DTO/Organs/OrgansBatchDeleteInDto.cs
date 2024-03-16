namespace CommonServer.Shared.DTO.Organs;

/// <summary>
/// 机构
/// </summary>
public class OrgansBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


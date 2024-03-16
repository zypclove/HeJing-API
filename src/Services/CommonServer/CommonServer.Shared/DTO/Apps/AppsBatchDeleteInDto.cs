namespace CommonServer.Shared.DTO.Apps;

/// <summary>
/// 应用
/// </summary>
public class AppsBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


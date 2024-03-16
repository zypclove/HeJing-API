namespace CommonServer.Shared.DTO.AppData;

/// <summary>
/// 数据
/// </summary>
public class AppDataBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


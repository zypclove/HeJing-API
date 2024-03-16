namespace CommonServer.Shared.DTO.AppOperationLog;

/// <summary>
/// 操作日志
/// </summary>
public class AppOperationLogBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


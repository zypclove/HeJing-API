namespace CommonServer.Shared.DTO.AppFunction;

/// <summary>
/// 功能
/// </summary>
public class AppFunctionBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


namespace CommonMormon.Infrastructure.Shared.DTO;

/// <summary>
/// 分页参数基类
/// </summary>
public class PagingInBase
{
    /// <summary>
    /// 页码
    /// </summary>
    public int PageIndex { get; set; } = 1;
    /// <summary>
    /// 页码长度
    /// </summary>
    public int PageSize { get; set; } = 100;
}
namespace CommonMormon.Infrastructure.Shared.DTO;

/// <summary>
/// 分页结果类
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class PagingOut<TEntity> where TEntity : class
{
    /// <summary>
    /// 总记录数
    /// </summary>
    public int Total { get; private set; }

    /// <summary>
    /// 记录集合
    /// </summary>
    public IEnumerable<TEntity> Items { get; private set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="total">总记录数</param>
    /// <param name="items">记录集合</param>
    public PagingOut(int total, IEnumerable<TEntity> items)
    {
        Total = total;
        Items = items;
    }
}
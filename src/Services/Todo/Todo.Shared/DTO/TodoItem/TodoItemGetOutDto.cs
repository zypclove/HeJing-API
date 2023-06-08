namespace Todo.Shared.DTO.TodoItem;

/// <summary>
/// 获取详情
/// </summary>
public class TodoItemGetOutDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 说明
    /// </summary>
    public string? Notes { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public DateTimeOffset LastModifyTime { get; set; }
}
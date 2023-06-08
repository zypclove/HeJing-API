using MediatR;

namespace Todo.Shared.Commands.TodoItem;

/// <summary>
/// 更新
/// </summary>
public class UpdateTodoItemCommand : IRequest<bool>
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid? Id { get; set; }
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 说明
    /// </summary>
    public string? Notes { get; set; }
}
using MediatR;

namespace Todo.Shared.Commands.TodoItem;

/// <summary>
/// 删除
/// </summary>
public class DeleteTodoItemCommand : IRequest<bool>
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid? Id { get; set; }
}
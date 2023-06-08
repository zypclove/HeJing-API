using CommonMormon.Infrastructure.Shared.DTO;

namespace Todo.Shared.DTO.TodoItem;

/// <summary>
/// 获取清单
/// </summary>
public class TodoItemQueryInDto : PagingInBase
{
    /// <summary>
    /// 名称
    /// </summary>
    public string? Name { get; set; }
}
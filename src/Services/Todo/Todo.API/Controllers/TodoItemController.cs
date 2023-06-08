using CommonMormon.Infrastructure.API.Controllers;
using CommonMormon.Infrastructure.Shared.DTO;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Todo.API.Queries;
using Todo.Shared.Commands.TodoItem;
using Todo.Shared.DTO.TodoItem;

namespace Todo.API.Controllers;

/// <summary>
/// 待办事项
/// </summary>
[Area("Todo")]
public class TodoItemController : AppControllerBase
{
    private readonly TodoItemQueries _queries;

    public TodoItemController(TodoItemQueries queries, IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _queries = queries ?? throw new ArgumentNullException(nameof(queries));
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<PagingOut<TodoItemQueryOutDto>>> Query([FromQuery] TodoItemQueryInDto input)
    {
        var data = await _queries.Query(input);
        return Success(data);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<TodoItemGetOutDto>> Get([FromQuery] TodoItemGetInDto input)
    {
        var data = await _queries.Get(input);
        return Success(data);
    }

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<Guid>> Create(CreateTodoItemCommand command)
    {
        command.Id = NewId.NextGuid();

        var commandResult = await Mediator.Send(command);

        return commandResult
            ? Success(command.Id.Value)
            : Failure<Guid>();
    }



    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult> Update(UpdateTodoItemCommand command)
    {
        var commandResult = await Mediator.Send(command);

        return commandResult
            ? Success()
            : Failure();
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult> Delete(DeleteTodoItemCommand command)
    {
        var commandResult = await Mediator.Send(command);

        return commandResult
            ? Success()
            : Failure();
    }
}
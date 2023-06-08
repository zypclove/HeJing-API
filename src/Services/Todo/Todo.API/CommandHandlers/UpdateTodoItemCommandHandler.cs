using CommonMormon.Infrastructure.API.CommandHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Infrastructure;
using Todo.Shared.Commands.TodoItem;

namespace Todo.API.CommandHandlers;

/// <summary>
/// 更新
/// </summary>
public class UpdateTodoItemCommandHandler : CommandHandlerBase, IRequestHandler<UpdateTodoItemCommand, bool>
{
    private readonly TodoDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public UpdateTodoItemCommandHandler(TodoDbContext dbContext, IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <summary>
    /// 处理请求
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> Handle(UpdateTodoItemCommand command, CancellationToken cancellationToken)
    {
        var model = await _dbContext.TodoItems.SingleAsync(x => x.Id.Equals(command.Id));

        Mapper.Map(command, model);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}
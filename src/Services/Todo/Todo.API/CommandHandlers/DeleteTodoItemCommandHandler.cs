using CommonMormon.Infrastructure.API.CommandHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Infrastructure;
using Todo.Shared.Commands.TodoItem;

namespace Todo.API.CommandHandlers;

/// <summary>
/// 删除
/// </summary>
public class DeleteTodoItemCommandHandler : CommandHandlerBase, IRequestHandler<DeleteTodoItemCommand, bool>
{
    private readonly TodoDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public DeleteTodoItemCommandHandler(TodoDbContext dbContext, IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <summary>
    /// 处理请求
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> Handle(DeleteTodoItemCommand command, CancellationToken cancellationToken)
    {
        var model = await _dbContext.TodoItems.SingleAsync(x => x.Id.Equals(command.Id));

        _dbContext.TodoItems.Remove(model);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}
using AutoMapper;
using CommonMormon.Infrastructure.API.CommandHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Model;
using Todo.Infrastructure;
using Todo.Shared.Commands.TodoItem;

namespace Todo.API.CommandHandlers;

/// <summary>
/// 创建
/// </summary>
public class CreateTodoItemCommandHandler : CommandHandlerBase, IRequestHandler<CreateTodoItemCommand, bool>
{
    private readonly TodoDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public CreateTodoItemCommandHandler(TodoDbContext dbContext, IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <summary>
    /// 处理请求
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> Handle(CreateTodoItemCommand command, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<TodoItem>(command);

        _dbContext.TodoItems.Add(model);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}
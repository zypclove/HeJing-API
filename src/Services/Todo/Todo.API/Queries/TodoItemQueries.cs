using CommonMormon.Infrastructure.API.Queries;
using CommonMormon.Infrastructure.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using Todo.Infrastructure;
using Todo.Shared.DTO.TodoItem;

namespace Todo.API.Queries;

/// <summary>
/// 待办事项
/// </summary>
public class TodoItemQueries : QueriesBase
{
    private readonly TodoDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public TodoItemQueries(TodoDbContext dbContext, IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<TodoItemQueryOutDto>> Query(TodoItemQueryInDto input)
    {
        var query = from a in _dbContext.TodoItems.AsNoTracking()
                    select a;

        #region filter
        if (!string.IsNullOrWhiteSpace(input.Name))
        {
            query = query.Where(w => w.Name!.Contains(input.Name));
        }
        #endregion

        var total = await query.CountAsync();

        var items = await query.OrderByDescending(x => x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<TodoItemQueryOutDto>>(items);

        return new PagingOut<TodoItemQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<TodoItemGetOutDto> Get(TodoItemGetInDto input)
    {
        var item = await (from a in _dbContext.TodoItems.AsNoTracking()
                             where a.Id == input.Id
                             select a).SingleAsync();

        var itemDto = Mapper.Map<TodoItemGetOutDto>(item);

        return itemDto;
    }
}
using Blog.Domain.Model;
using Blog.Infrastructure;
using Blog.Shared.DTO.Comment;

namespace Blog.HostApp.Areas.Blog.Services;

/// <summary>
/// 
/// </summary>
public class CommentService : ServiceBase
{
    private BlogDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public CommentService(BlogDbContext dbContext, IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<CommentCreateOutDto> Create(CommentCreateInDto input)
    {
        var model = Mapper.Map<Comment>(input);

        await _dbContext.Comments.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return new CommentCreateOutDto { };
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<CommentUpdateOutDto> Update(CommentUpdateInDto input)
    {
        var model = await _dbContext.Comments.SingleAsync(x => x.Id.Equals(input.Id));

        Mapper.Map(input, model);

        await _dbContext.SaveChangesAsync();

        return new CommentUpdateOutDto { };
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<CommentDeleteOutDto> Delete(CommentDeleteInDto input)
    {
        var model = await _dbContext.Comments.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.Comments.Remove(model);

        await _dbContext.SaveChangesAsync();

        return new CommentDeleteOutDto { };
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<CommentQueryOutDto>> Query(CommentQueryInDto input)
    {
        var query = from a in _dbContext.Comments.AsNoTracking()
                    orderby a.Id
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<CommentQueryOutDto>>(items);

        return new PagingOut<CommentQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<CommentGetOutDto> Get(CommentGetInDto input)
    {
        var query = from a in _dbContext.Comments.AsNoTracking()
                    orderby a.Id
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<CommentGetOutDto>(items);
    }
}

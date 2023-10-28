using Blog.Domain.Model;
using Blog.Infrastructure;
using Blog.Shared.DTO.Tag;

namespace Blog.HostApp.Areas.Blog.Services;

/// <summary>
/// 
/// </summary>
public class TagService : ServiceBase
{
    private BlogDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public TagService(BlogDbContext dbContext, IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<TagCreateOutDto> Create(TagCreateInDto input)
    {
        var model = Mapper.Map<Tag>(input);

        await _dbContext.Tags.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return new TagCreateOutDto { };
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<TagUpdateOutDto> Update(TagUpdateInDto input)
    {
        var model = await _dbContext.Tags.SingleAsync(x => x.Id.Equals(input.Id));

        Mapper.Map(input, model);

        await _dbContext.SaveChangesAsync();

        return new TagUpdateOutDto { };
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<TagDeleteOutDto> Delete(TagDeleteInDto input)
    {
        var model = await _dbContext.Tags.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.Tags.Remove(model);

        await _dbContext.SaveChangesAsync();

        return new TagDeleteOutDto { };
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<TagQueryOutDto>> Query(TagQueryInDto input)
    {
        var query = from a in _dbContext.Tags.AsNoTracking()
                    orderby a.Id
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<TagQueryOutDto>>(items);

        return new PagingOut<TagQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<TagGetOutDto> Get(TagGetInDto input)
    {
        var query = from a in _dbContext.Tags.AsNoTracking()
                    orderby a.Id
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<TagGetOutDto>(items);
    }
}

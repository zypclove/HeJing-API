using Blog.Domain.Model;
using Blog.Infrastructure;
using Blog.Shared.DTO.ArticleTag;

namespace Blog.HostApp.Areas.Blog.Services;

/// <summary>
/// 
/// </summary>
public class ArticleTagService : ServiceBase
{
    private BlogDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public ArticleTagService(BlogDbContext dbContext, IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ArticleTagCreateOutDto> Create(ArticleTagCreateInDto input)
    {
        var model = Mapper.Map<ArticleTag>(input);

        await _dbContext.ArticleTags.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return new ArticleTagCreateOutDto { };
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ArticleTagUpdateOutDto> Update(ArticleTagUpdateInDto input)
    {
        var model = await _dbContext.ArticleTags.SingleAsync(x => x.Id.Equals(input.Id));

        Mapper.Map(input, model);

        await _dbContext.SaveChangesAsync();

        return new ArticleTagUpdateOutDto { };
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ArticleTagDeleteOutDto> Delete(ArticleTagDeleteInDto input)
    {
        var model = await _dbContext.ArticleTags.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.ArticleTags.Remove(model);

        await _dbContext.SaveChangesAsync();

        return new ArticleTagDeleteOutDto { };
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<ArticleTagQueryOutDto>> Query(ArticleTagQueryInDto input)
    {
        var query = from a in _dbContext.ArticleTags.AsNoTracking()
                    orderby a.Id
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<ArticleTagQueryOutDto>>(items);

        return new PagingOut<ArticleTagQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ArticleTagGetOutDto> Get(ArticleTagGetInDto input)
    {
        var query = from a in _dbContext.ArticleTags.AsNoTracking()
                    orderby a.Id
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<ArticleTagGetOutDto>(items);
    }
}

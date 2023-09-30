using Blog.Domain.Model;
using Blog.Infrastructure;
using Blog.Shared.DTO.Article;

namespace Blog.HostApp.Areas.Blog.Services;

/// <summary>
/// 
/// </summary>
public class ArticleService : ServiceBase
{
    private BlogDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public ArticleService(BlogDbContext dbContext, IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ArticleCreateOutDto> Create(ArticleCreateInDto input)
    {
        var model = Mapper.Map<Article>(input);

        await _dbContext.Articles.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return new ArticleCreateOutDto { };
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ArticleUpdateOutDto> Update(ArticleUpdateInDto input)
    {
        var model = await _dbContext.Articles.SingleAsync(x => x.Id.Equals(input.Id));

        Mapper.Map(input, model);

        await _dbContext.SaveChangesAsync();

        return new ArticleUpdateOutDto { };
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ArticleDeleteOutDto> Delete(ArticleDeleteInDto input)
    {
        var model = await _dbContext.Articles.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.Articles.Remove(model);

        await _dbContext.SaveChangesAsync();

        return new ArticleDeleteOutDto { };
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<IList<ArticleQueryOutDto>> QuerySearch(string keyword)
    {
        var query = from a in _dbContext.Articles.AsNoTracking()
                    where a.Title.Contains(keyword) || a.Content.Contains(keyword)
                    orderby a.PublishDate
                    select a;

        var items = await query
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<ArticleQueryOutDto>>(items);

        return itemDtos;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<ArticleQueryOutDto>> Query(ArticleQueryInDto input)
    {
        var query = from a in _dbContext.Articles.AsNoTracking()
                    orderby a.Id
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<ArticleQueryOutDto>>(items);

        return new PagingOut<ArticleQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ArticleGetOutDto> Get(ArticleGetInDto input)
    {
        var query = from a in _dbContext.Articles.AsNoTracking()
                    orderby a.Id
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<ArticleGetOutDto>(items);
    }
}

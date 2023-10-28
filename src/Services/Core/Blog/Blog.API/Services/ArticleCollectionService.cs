using Blog.Domain.Model;
using Blog.Infrastructure;
using Blog.Shared.DTO.ArticleCollection;

namespace Blog.HostApp.Areas.Blog.Services;

/// <summary>
/// 
/// </summary>
public class ArticleCollectionService : ServiceBase
{
    private BlogDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public ArticleCollectionService(BlogDbContext dbContext, IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ArticleCollectionCreateOutDto> Create(ArticleCollectionCreateInDto input)
    {
        var model = Mapper.Map<ArticleCollection>(input);

        await _dbContext.ArticleCollections.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return new ArticleCollectionCreateOutDto { };
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ArticleCollectionUpdateOutDto> Update(ArticleCollectionUpdateInDto input)
    {
        var model = await _dbContext.ArticleCollections.SingleAsync(x => x.Id.Equals(input.Id));

        Mapper.Map(input, model);

        await _dbContext.SaveChangesAsync();

        return new ArticleCollectionUpdateOutDto { };
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ArticleCollectionDeleteOutDto> Delete(ArticleCollectionDeleteInDto input)
    {
        var model = await _dbContext.ArticleCollections.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.ArticleCollections.Remove(model);

        await _dbContext.SaveChangesAsync();

        return new ArticleCollectionDeleteOutDto { };
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<ArticleCollectionQueryOutDto>> Query(ArticleCollectionQueryInDto input)
    {
        var query = from a in _dbContext.ArticleCollections.AsNoTracking()
                    orderby a.Id
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<ArticleCollectionQueryOutDto>>(items);

        return new PagingOut<ArticleCollectionQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ArticleCollectionGetOutDto> Get(ArticleCollectionGetInDto input)
    {
        var query = from a in _dbContext.ArticleCollections.AsNoTracking()
                    orderby a.Id
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<ArticleCollectionGetOutDto>(items);
    }
}

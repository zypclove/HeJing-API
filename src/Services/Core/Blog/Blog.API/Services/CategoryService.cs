using Blog.Domain.Model;
using Blog.Infrastructure;
using Blog.Shared.DTO.Category;

namespace Blog.HostApp.Areas.Blog.Services;

/// <summary>
/// 
/// </summary>
public class CategoryService : ServiceBase
{
    private BlogDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public CategoryService(BlogDbContext dbContext, IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<CategoryCreateOutDto> Create(CategoryCreateInDto input)
    {
        var model = Mapper.Map<Category>(input);

        await _dbContext.Categories.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return new CategoryCreateOutDto { };
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<CategoryUpdateOutDto> Update(CategoryUpdateInDto input)
    {
        var model = await _dbContext.Categories.SingleAsync(x => x.Id.Equals(input.Id));

        Mapper.Map(input, model);

        await _dbContext.SaveChangesAsync();

        return new CategoryUpdateOutDto { };
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<CategoryDeleteOutDto> Delete(CategoryDeleteInDto input)
    {
        var model = await _dbContext.Categories.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.Categories.Remove(model);

        await _dbContext.SaveChangesAsync();

        return new CategoryDeleteOutDto { };
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<CategoryQueryOutDto>> Query(CategoryQueryInDto input)
    {
        var query = from a in _dbContext.Categories.AsNoTracking()
                    orderby a.Id
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<CategoryQueryOutDto>>(items);

        return new PagingOut<CategoryQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<CategoryGetOutDto> Get(CategoryGetInDto input)
    {
        var query = from a in _dbContext.Categories.AsNoTracking()
                    orderby a.Id
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<CategoryGetOutDto>(items);
    }
}

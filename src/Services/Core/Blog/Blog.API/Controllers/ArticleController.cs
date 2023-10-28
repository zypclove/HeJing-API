using Blog.Domain.Model;
using Blog.HostApp.Areas.Blog.Services;
using Blog.Infrastructure;
using Blog.Shared.DTO.Article;

namespace Blog.HostApp.Areas.Blog.Controllers;

/// <summary>
/// 
/// </summary>
[Area("Blog")]
public class ArticleController : AppControllerBase
{
    private readonly ArticleService _service;
    private BlogDbContext _dbContext;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="dbContext"></param>
    /// <param name="service"></param>
    public ArticleController(IServiceProvider serviceProvider, BlogDbContext dbContext, ArticleService service) :
        base(serviceProvider)
    {
        _dbContext = dbContext;
        _service = service;
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
[HttpPost]
public async Task<ApiResult> Create(ArticleCreateInDto input)
{
    if (ModelState.IsValid)
    {
        // 获取富文本编辑器的HTML内容
        var content = input.Content!;

        // 进行处理和存储操作
        // ...

        var model = new Article
        {
            CategoryId = new Guid("01890000-385c-84a9-c29b-08dbbb117319"),
            Id = NewId.NextGuid(),
            Title = input.Title!,
            Content = content,
            PublishDate = DateTime.Now
        };

        await _dbContext.Articles.AddAsync(model);
        await _dbContext.SaveChangesAsync();

        return Success();
    }
    return Failure();
}


    /// <summary>
    /// 点赞
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult> Like(Guid id)
    {
        var model = await _dbContext.Articles.SingleAsync(x => x.Id.Equals(id));
        model.Likes++;
        await _dbContext.SaveChangesAsync();
        return Success();
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<ArticleUpdateOutDto>> Update(ArticleUpdateInDto input)
    {
        var result = await _service.Update(input);
        return Success(result);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<ArticleDeleteOutDto>> Delete(ArticleDeleteInDto input)
    {
        var result = await _service.Delete(input);
        return Success(result);
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<IList<ArticleQueryOutDto>>> QueryAll()
    {
        var query = from a in _dbContext.Articles.AsNoTracking()
                    orderby a.PublishDate
                    select a;

        var items = await query
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<ArticleQueryOutDto>>(items);

        return Success(itemDtos);
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
[HttpGet]
public async Task<ApiResult<IList<ArticleQueryOutDto>>> QuerySearch(string keyword)
{
    var result = await _service.QuerySearch(keyword);
    return Success(result);
}

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<PagingOut<ArticleQueryOutDto>>> QueryPage(int? page)
    {
        var pageNumber = page ?? 1;
        var pageSize = 10; // 每页显示的博客数量

        var query = from a in _dbContext.Articles.AsNoTracking()
                    orderby a.PublishDate
                    select a;

        var total = await query.CountAsync();

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<ArticleQueryOutDto>>(items);

        return Success(new PagingOut<ArticleQueryOutDto>(total, itemDtos));
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<ArticleGetOutDto>> GetDetail(Guid id)
    {
        var query = from a in _dbContext.Articles.Include(x=>x.Comments).AsNoTracking()
                    orderby a.Id
                    where a.Id == id
                    select a;

        var items = await query.FirstOrDefaultAsync();

        if (items == null)
        {
            return Failure<ArticleGetOutDto>("该博客不存在！");
        }

        var result = Mapper.Map<ArticleGetOutDto>(items);

        return Success(result);
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<PagingOut<ArticleQueryOutDto>>> Query([FromQuery] ArticleQueryInDto input)
    {
        var result = await _service.Query(input);
        return Success(result);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<ArticleGetOutDto>> Get([FromQuery] ArticleGetInDto input)
    {
        var result = await _service.Get(input);
        return Success(result);
    }
}
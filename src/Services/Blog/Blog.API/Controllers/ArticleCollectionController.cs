using Blog.HostApp.Areas.Blog.Services;
using Blog.Shared.DTO.ArticleCollection;

namespace Blog.HostApp.Areas.Blog.Controllers;

/// <summary>
/// 
/// </summary>
[Area("Blog")]
public class ArticleCollectionController : AppControllerBase
{
    private readonly ArticleCollectionService _service;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="service"></param>
    public ArticleCollectionController(IServiceProvider serviceProvider, ArticleCollectionService service) :
        base(serviceProvider)
    {
        _service = service;
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<ArticleCollectionCreateOutDto>> Create(ArticleCollectionCreateInDto input)
    {
        input.Id = NewId.NextGuid();
        var result = await _service.Create(input);
        return Success(result);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<ArticleCollectionUpdateOutDto>> Update(ArticleCollectionUpdateInDto input)
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
    public async Task<ApiResult<ArticleCollectionDeleteOutDto>> Delete(ArticleCollectionDeleteInDto input)
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
    public async Task<ApiResult<PagingOut<ArticleCollectionQueryOutDto>>> Query([FromQuery] ArticleCollectionQueryInDto input)
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
    public async Task<ApiResult<ArticleCollectionGetOutDto>> Get([FromQuery] ArticleCollectionGetInDto input)
    {
        var result = await _service.Get(input);
        return Success(result);
    }
}
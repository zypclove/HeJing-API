using Blog.HostApp.Areas.Blog.Services;
using Blog.Shared.DTO.ArticleTag;

namespace Blog.HostApp.Areas.Blog.Controllers;

/// <summary>
/// 
/// </summary>
[Area("Blog")]
public class ArticleTagController : AppControllerBase
{
    private readonly ArticleTagService _service;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="service"></param>
    public ArticleTagController(IServiceProvider serviceProvider, ArticleTagService service) :
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
    public async Task<ApiResult<ArticleTagCreateOutDto>> Create(ArticleTagCreateInDto input)
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
    public async Task<ApiResult<ArticleTagUpdateOutDto>> Update(ArticleTagUpdateInDto input)
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
    public async Task<ApiResult<ArticleTagDeleteOutDto>> Delete(ArticleTagDeleteInDto input)
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
    public async Task<ApiResult<PagingOut<ArticleTagQueryOutDto>>> Query([FromQuery] ArticleTagQueryInDto input)
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
    public async Task<ApiResult<ArticleTagGetOutDto>> Get([FromQuery] ArticleTagGetInDto input)
    {
        var result = await _service.Get(input);
        return Success(result);
    }
}
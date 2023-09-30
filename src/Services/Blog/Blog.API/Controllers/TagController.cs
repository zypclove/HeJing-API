using Blog.HostApp.Areas.Blog.Services;
using Blog.Shared.DTO.Tag;

namespace Blog.HostApp.Areas.Blog.Controllers;

/// <summary>
/// 
/// </summary>
[Area("Blog")]
public class TagController : AppControllerBase
{
    private readonly TagService _service;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="service"></param>
    public TagController(IServiceProvider serviceProvider, TagService service) :
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
public async Task<ApiResult<TagCreateOutDto>> Create(TagCreateInDto input)
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
public async Task<ApiResult<TagUpdateOutDto>> Update(TagUpdateInDto input)
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
public async Task<ApiResult<TagDeleteOutDto>> Delete(TagDeleteInDto input)
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
public async Task<ApiResult<PagingOut<TagQueryOutDto>>> Query([FromQuery] TagQueryInDto input)
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
    public async Task<ApiResult<TagGetOutDto>> Get([FromQuery] TagGetInDto input)
    {
        var result = await _service.Get(input);
        return Success(result);
    }
}
using Blog.HostApp.Areas.Blog.Services;
using Blog.Shared.DTO.Category;

namespace Blog.HostApp.Areas.Blog.Controllers;

/// <summary>
/// 
/// </summary>
[Area("Blog")]
public class CategoryController : AppControllerBase
{
    private readonly CategoryService _service;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="service"></param>
    public CategoryController(IServiceProvider serviceProvider, CategoryService service) :
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
public async Task<ApiResult<CategoryCreateOutDto>> Create(CategoryCreateInDto input)
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
public async Task<ApiResult<CategoryUpdateOutDto>> Update(CategoryUpdateInDto input)
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
public async Task<ApiResult<CategoryDeleteOutDto>> Delete(CategoryDeleteInDto input)
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
public async Task<ApiResult<PagingOut<CategoryQueryOutDto>>> Query([FromQuery] CategoryQueryInDto input)
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
public async Task<ApiResult<CategoryGetOutDto>> Get([FromQuery] CategoryGetInDto input)
{
    var result = await _service.Get(input);
    return Success(result);
}
}
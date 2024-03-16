using CommonServer.HostApp.Services;
using CommonServer.Shared.DTO.AppResource;
using CommonServer.Shared.DTO.OrganDepartment;

namespace CommonServer.HostApp.Controllers;

/// <summary>
/// 资源
/// </summary>
[Area("common")]
public class AppResourceController : AppControllerBase
{
    private readonly AppResourceService _service;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="service"></param>
    public AppResourceController(IServiceProvider serviceProvider, AppResourceService service) :
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
    public async Task<ApiResult<Guid>> Create(AppResourceCreateInDto input)
    {
        var result = await _service.Create(input);
        return Success(result);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<bool>> Update(AppResourceUpdateInDto input)
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
    public async Task<ApiResult<bool>> Delete(AppResourceDeleteInDto input)
    {
        var result = await _service.Delete(input);
        return Success(result);
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<bool>> BatchDelete(AppResourceBatchDeleteInDto input)
    {
        var result = await _service.BatchDelete(input);
        return Success(result);
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<PagingOut<AppResourceQueryOutDto>>> Query([FromQuery] AppResourceQueryInDto input)
    {
        var result = await _service.Query(input);
        return Success(result);
    }

    /// <summary>
    /// 获取树下拉框清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<IList<AppResourceQueryTreeSelectOutDto>>> QueryTreeSelect([FromQuery] AppResourceQueryInDto input)
    {
        var data = await _service.QueryTreeSelect(input);
        return Success(data);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<AppResourceGetOutDto>> Get([FromQuery] AppResourceGetInDto input)
    {
        var result = await _service.Get(input);
        return Success(result);
    }
}
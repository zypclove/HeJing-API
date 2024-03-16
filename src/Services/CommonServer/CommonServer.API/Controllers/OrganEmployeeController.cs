using CommonServer.HostApp.Services;
using CommonServer.Shared.DTO.OrganEmployee;

namespace CommonServer.HostApp.Controllers;

/// <summary>
/// 员工
/// </summary>
[Area("common")]
public class OrganEmployeeController : AppControllerBase
{
    private readonly OrganEmployeeService _service;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="service"></param>
    public OrganEmployeeController(IServiceProvider serviceProvider, OrganEmployeeService service) :
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
    public async Task<ApiResult<Guid>> Create(OrganEmployeeCreateInDto input)
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
    public async Task<ApiResult<bool>> Update(OrganEmployeeUpdateInDto input)
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
    public async Task<ApiResult<bool>> Delete(OrganEmployeeDeleteInDto input)
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
    public async Task<ApiResult<bool>> BatchDelete(OrganEmployeeBatchDeleteInDto input)
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
    public async Task<ApiResult<PagingOut<OrganEmployeeQueryOutDto>>> Query([FromQuery] OrganEmployeeQueryInDto input)
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
    public async Task<ApiResult<OrganEmployeeGetOutDto>> Get([FromQuery] OrganEmployeeGetInDto input)
    {
        var result = await _service.Get(input);
        return Success(result);
    }
}
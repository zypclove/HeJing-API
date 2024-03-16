using CommonServer.HostApp.Services;
using CommonServer.Shared.DTO.OrganDepartment;

namespace CommonServer.HostApp.Controllers;

/// <summary>
/// 部门
/// </summary>
[Area("common")]
public class OrganDepartmentController : AppControllerBase
{
    private readonly OrganDepartmentService _service;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="service"></param>
    public OrganDepartmentController(IServiceProvider serviceProvider, OrganDepartmentService service) :
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
    public async Task<ApiResult<Guid>> Create(OrganDepartmentCreateInDto input)
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
    public async Task<ApiResult<bool>> Update(OrganDepartmentUpdateInDto input)
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
    public async Task<ApiResult<bool>> Delete(OrganDepartmentDeleteInDto input)
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
    public async Task<ApiResult<bool>> BatchDelete(OrganDepartmentBatchDeleteInDto input)
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
    public async Task<ApiResult<PagingOut<OrganDepartmentQueryOutDto>>> Query([FromQuery] OrganDepartmentQueryInDto input)
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
    public async Task<ApiResult<IList<OrganDepartmentQueryTreeSelectOutDto>>> QueryTreeSelect([FromQuery] OrganDepartmentQueryInDto input)
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
    public async Task<ApiResult<OrganDepartmentGetOutDto>> Get([FromQuery] OrganDepartmentGetInDto input)
    {
        var result = await _service.Get(input);
        return Success(result);
    }
}
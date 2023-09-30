using Blog.HostApp.Areas.Blog.Services;
using Blog.Shared.DTO.User;
using MassTransit;

namespace Blog.HostApp.Areas.Blog.Controllers;

/// <summary>
/// 
/// </summary>
[Area("Blog")]
public class UserController : AppControllerBase
{
    private readonly UserService _service;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="service"></param>
    public UserController(IServiceProvider serviceProvider, UserService service) :
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
    public async Task<ApiResult<UserCreateOutDto>> Create(UserCreateInDto input)
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
    public async Task<ApiResult<UserUpdateOutDto>> Update(UserUpdateInDto input)
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
    public async Task<ApiResult<UserDeleteOutDto>> Delete(UserDeleteInDto input)
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
    public async Task<ApiResult<PagingOut<UserQueryOutDto>>> Query([FromQuery] UserQueryInDto input)
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
    public async Task<ApiResult<UserGetOutDto>> Get([FromQuery] UserGetInDto input)
    {
        var result = await _service.Get(input);
        return Success(result);
    }

    /// <summary>
    /// 用户注册
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult> Register(UserRegisterInDto input)
    {
        if (ModelState.IsValid)
        {
            input.Id = NewId.NextGuid();
            var result = await _service.Register(input);

            if (!result)
            {
                return Failure("用户注册失败！");
            }
        }
        return Success();
    }

    /// <summary>
    /// 用户登录
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult> Login(UserLoginInDto input)
    {
        if (ModelState.IsValid)
        {
            var result = await _service.Login(input);

            if (!result)
            {
                return Failure("用户登录失败！");
            }
        }
        return Success();
    }
}
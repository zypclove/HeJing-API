using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CommonMormon.Infrastructure.API.Controllers;

/// <summary>
/// 
/// </summary>
[Route("api/[area]/[controller]/[action]")]
[ApiController]
public abstract class AppControllerBase : Controller
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    protected AppControllerBase(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        Logger = _serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger(GetType());
        Mediator = _serviceProvider.GetRequiredService<IMediator>();
    }

    /// <summary>
    /// 日志
    /// </summary>
    protected ILogger Logger { get; }

    /// <summary>
    /// 中介者
    /// </summary>
    protected IMediator Mediator { get; }

    /// <summary>
    /// 成功
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    protected static ApiResult<T> Success<T>(T data)
    {
        return new ApiResult<T>
        {
            Code = 0,
            Data = data
        };
    }

    /// <summary>
    /// 成功
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    protected static ApiResult Success()
    {
        return new ApiResult
        {
            Code = 0
        };
    }

    /// <summary>
    /// 失败
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    protected static ApiResult<T> Failure<T>()
    {
        return new ApiResult<T>
        {
            Code = 1,
            Message = "未知错误"
        };
    }

    /// <summary>
    /// 失败
    /// </summary>
    /// <returns></returns>
    protected static ApiResult Failure()
    {
        return new ApiResult
        {
            Code = 1,
            Message = "未知错误"
        };
    }
}
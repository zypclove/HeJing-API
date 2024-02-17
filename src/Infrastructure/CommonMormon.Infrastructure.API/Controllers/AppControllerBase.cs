using AutoMapper;
using CommonMormon.Infrastructure.Core.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

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
        Mapper = _serviceProvider.GetRequiredService<IMapper>();
        Configuration = _serviceProvider.GetRequiredService<IConfiguration>();
    }

    /// <summary>
    /// 日志
    /// </summary>
    protected ILogger Logger { get; }

    /// <summary>
    /// 对象映射
    /// </summary>
    protected IMapper Mapper { get; }

    /// <summary>
    /// 配置
    /// </summary>
    protected IConfiguration Configuration { get; }

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
    protected static ApiResult<T> Failure<T>(string message= "未知错误")
    {
        return new ApiResult<T>
        {
            Code = 1,
            Message = message
        };
    }

    /// <summary>
    /// 失败
    /// </summary>
    /// <returns></returns>
    protected static ApiResult Failure(string message = "未知错误")
    {
        return new ApiResult
        {
            Code = 1,
            Message = message
        };
    }
}
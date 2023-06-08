namespace CommonMormon.Infrastructure.API.Controllers;

/// <summary>
/// 不带数据的API调用结果类
/// </summary>
public class ApiResult
{
    /// <summary>
    /// 状态
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// 错误信息
    /// </summary>
    public string? Message { get; set; }
}

/// <summary>
/// API调用结果类
/// </summary>
/// <typeparam name="T"></typeparam>
public class ApiResult<T> : ApiResult
{
    /// <summary>
    /// 数据
    /// </summary>
    public T? Data { get; set; }
}
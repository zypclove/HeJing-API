using AutoMapper;

namespace CommonMormon.Infrastructure.API.Queries;

/// <summary>
/// 查询基类
/// </summary>
public class QueriesBase
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public QueriesBase(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        Logger = _serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger(GetType());
        Mapper = _serviceProvider.GetRequiredService<IMapper>();
    }

    /// <summary>
    /// 日志
    /// </summary>
    protected ILogger Logger { get; }

    /// <summary>
    /// 对象映射
    /// </summary>
    protected IMapper Mapper { get; }
}
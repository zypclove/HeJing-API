using AutoMapper;

namespace CommonMormon.Infrastructure.API.CommandHandlers;

/// <summary>
/// 命令处理基类
/// </summary>
public class CommandHandlerBase
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public CommandHandlerBase(IServiceProvider serviceProvider)
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
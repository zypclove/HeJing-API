using CommonServer.Shared.DTO.AppOperationLog;

namespace CommonServer.HostApp.Services;

/// <summary>
/// 操作日志
/// </summary>
public class AppOperationLogService : ServiceBase
{
    private readonly CommonServerDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public AppOperationLogService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<CommonServerDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(AppOperationLogCreateInDto input)
    {
        var model = Mapper.Map<AppOperationLog>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.AppOperationLogs.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(AppOperationLogUpdateInDto input)
    {
        var model = await _dbContext.AppOperationLogs.SingleAsync(x => x.Id.Equals(input.Id));

        Mapper.Map(input, model);

        model.LastModifyTime = DateTimeOffset.Now;

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Delete(AppOperationLogDeleteInDto input)
    {
        var model = await _dbContext.AppOperationLogs.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.AppOperationLogs.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(AppOperationLogBatchDeleteInDto input)
    {
        var model = await _dbContext.AppOperationLogs.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.AppOperationLogs.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<AppOperationLogQueryOutDto>> Query(AppOperationLogQueryInDto input)
    {
        var query = from a in _dbContext.AppOperationLogs.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<AppOperationLogQueryOutDto>>(items);

        return new PagingOut<AppOperationLogQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<AppOperationLogGetOutDto> Get(AppOperationLogGetInDto input)
    {
        var query = from a in _dbContext.AppOperationLogs.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<AppOperationLogGetOutDto>(items);
    }
}

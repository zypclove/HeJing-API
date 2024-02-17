using IdentityServerPlus.Shared.DTO.AppAuditLog;

namespace IdentityServerPlus.HostApp.Services;

/// <summary>
/// 审计日志
/// </summary>
public class AppAuditLogService : ServiceBase
{
    private readonly IdentityServerPlusDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public AppAuditLogService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<IdentityServerPlusDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(AppAuditLogCreateInDto input)
    {
        var model = Mapper.Map<AppAuditLog>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.AppAuditLogs.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(AppAuditLogUpdateInDto input)
    {
        var model = await _dbContext.AppAuditLogs.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(AppAuditLogDeleteInDto input)
    {
        var model = await _dbContext.AppAuditLogs.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.AppAuditLogs.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(AppAuditLogBatchDeleteInDto input)
    {
        var model = await _dbContext.AppAuditLogs.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.AppAuditLogs.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<AppAuditLogQueryOutDto>> Query(AppAuditLogQueryInDto input)
    {
        var query = from a in _dbContext.AppAuditLogs.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<AppAuditLogQueryOutDto>>(items);

        return new PagingOut<AppAuditLogQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<AppAuditLogGetOutDto> Get(AppAuditLogGetInDto input)
    {
        var query = from a in _dbContext.AppAuditLogs.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<AppAuditLogGetOutDto>(items);
    }
}

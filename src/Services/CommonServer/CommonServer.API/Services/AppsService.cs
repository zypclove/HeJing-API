using CommonServer.Shared.DTO.Apps;

namespace CommonServer.HostApp.Services;

/// <summary>
/// 应用
/// </summary>
public class AppsService : ServiceBase
{
    private readonly CommonServerDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public AppsService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<CommonServerDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(AppsCreateInDto input)
    {
        var model = Mapper.Map<Apps>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.Appses.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(AppsUpdateInDto input)
    {
        var model = await _dbContext.Appses.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(AppsDeleteInDto input)
    {
        var model = await _dbContext.Appses.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.Appses.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(AppsBatchDeleteInDto input)
    {
        var model = await _dbContext.Appses.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.Appses.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<AppsQueryOutDto>> Query(AppsQueryInDto input)
    {
        var query = from a in _dbContext.Appses.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<AppsQueryOutDto>>(items);

        return new PagingOut<AppsQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<AppsGetOutDto> Get(AppsGetInDto input)
    {
        var query = from a in _dbContext.Appses.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<AppsGetOutDto>(items);
    }
}

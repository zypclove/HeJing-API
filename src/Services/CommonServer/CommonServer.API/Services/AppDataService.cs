using CommonServer.Shared.DTO.AppData;

namespace CommonServer.HostApp.Services;

/// <summary>
/// 数据
/// </summary>
public class AppDataService : ServiceBase
{
    private readonly CommonServerDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public AppDataService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<CommonServerDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(AppsDataCreateInDto input)
    {
        var model = Mapper.Map<AppData>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.AppDatas.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(AppDataUpdateInDto input)
    {
        var model = await _dbContext.AppDatas.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(AppDataDeleteInDto input)
    {
        var model = await _dbContext.AppDatas.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.AppDatas.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(AppDataBatchDeleteInDto input)
    {
        var model = await _dbContext.AppDatas.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.AppDatas.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<AppDataQueryOutDto>> Query(AppDataQueryInDto input)
    {
        var query = from a in _dbContext.AppDatas.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<AppDataQueryOutDto>>(items);

        return new PagingOut<AppDataQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<AppDataGetOutDto> Get(AppDataGetInDto input)
    {
        var query = from a in _dbContext.AppDatas.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<AppDataGetOutDto>(items);
    }
}

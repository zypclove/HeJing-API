using CommonServer.Shared.DTO.AppFunction;

namespace CommonServer.HostApp.Services;

/// <summary>
/// 功能
/// </summary>
public class AppFunctionService : ServiceBase
{
    private readonly CommonServerDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public AppFunctionService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<CommonServerDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(AppFunctionCreateInDto input)
    {
        var model = Mapper.Map<AppFunction>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.AppFunctions.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(AppFunctionUpdateInDto input)
    {
        var model = await _dbContext.AppFunctions.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(AppFunctionDeleteInDto input)
    {
        var model = await _dbContext.AppFunctions.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.AppFunctions.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(AppFunctionBatchDeleteInDto input)
    {
        var model = await _dbContext.AppFunctions.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.AppFunctions.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<AppFunctionQueryOutDto>> Query(AppFunctionQueryInDto input)
    {
        var query = from a in _dbContext.AppFunctions.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderBy(x=>x.SortNo)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<AppFunctionQueryOutDto>>(items);

        return new PagingOut<AppFunctionQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<AppFunctionGetOutDto> Get(AppFunctionGetInDto input)
    {
        var query = from a in _dbContext.AppFunctions.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<AppFunctionGetOutDto>(items);
    }
}

using ERP.Shared.DTO.Stock;

namespace ERP.HostApp.Services;

/// <summary>
/// 库存
/// </summary>
public class StockService : ServiceBase
{
    private readonly ERPDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public StockService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<ERPDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(StockCreateInDto input)
    {
        var model = Mapper.Map<Stock>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.Stocks.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(StockUpdateInDto input)
    {
        var model = await _dbContext.Stocks.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(StockDeleteInDto input)
    {
        var model = await _dbContext.Stocks.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.Stocks.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(StockBatchDeleteInDto input)
    {
        var model = await _dbContext.Stocks.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.Stocks.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<StockQueryOutDto>> Query(StockQueryInDto input)
    {
        var query = from a in _dbContext.Stocks.AsNoTracking()
                    orderby a.Id
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<StockQueryOutDto>>(items);

        return new PagingOut<StockQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<StockGetOutDto> Get(StockGetInDto input)
    {
        var query = from a in _dbContext.Stocks.AsNoTracking()
                    orderby a.Id
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<StockGetOutDto>(items);
    }
}

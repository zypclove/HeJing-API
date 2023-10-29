using ERP.Shared.DTO.ReturnGoods;

namespace ERP.HostApp.Services;

/// <summary>
/// 退货
/// </summary>
public class ReturnGoodsService : ServiceBase
{
    private readonly ERPDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public ReturnGoodsService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<ERPDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(ReturnGoodsCreateInDto input)
    {
        var model = Mapper.Map<ReturnGoods>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.ReturnGoods.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(ReturnGoodsUpdateInDto input)
    {
        var model = await _dbContext.ReturnGoods.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(ReturnGoodsDeleteInDto input)
    {
        var model = await _dbContext.ReturnGoods.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.ReturnGoods.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(ReturnGoodsBatchDeleteInDto input)
    {
        var model = await _dbContext.ReturnGoods.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.ReturnGoods.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<ReturnGoodsQueryOutDto>> Query(ReturnGoodsQueryInDto input)
    {
        var query = from a in _dbContext.ReturnGoods.AsNoTracking()
                    orderby a.Id
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<ReturnGoodsQueryOutDto>>(items);

        return new PagingOut<ReturnGoodsQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ReturnGoodsGetOutDto> Get(ReturnGoodsGetInDto input)
    {
        var query = from a in _dbContext.ReturnGoods.AsNoTracking()
                    orderby a.Id
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<ReturnGoodsGetOutDto>(items);
    }
}

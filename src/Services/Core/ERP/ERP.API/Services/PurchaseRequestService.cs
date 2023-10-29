using ERP.Shared.DTO.PurchaseRequest;

namespace ERP.HostApp.Services;

/// <summary>
/// 采购需求
/// </summary>
public class PurchaseRequestService : ServiceBase
{
    private readonly ERPDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public PurchaseRequestService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<ERPDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(PurchaseRequestCreateInDto input)
    {
        var model = Mapper.Map<PurchaseRequest>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.PurchaseRequests.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(PurchaseRequestUpdateInDto input)
    {
        var model = await _dbContext.PurchaseRequests.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(PurchaseRequestDeleteInDto input)
    {
        var model = await _dbContext.PurchaseRequests.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.PurchaseRequests.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(PurchaseRequestBatchDeleteInDto input)
    {
        var model = await _dbContext.PurchaseRequests.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.PurchaseRequests.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<PurchaseRequestQueryOutDto>> Query(PurchaseRequestQueryInDto input)
    {
        var query = from a in _dbContext.PurchaseRequests.AsNoTracking()
                    orderby a.Id
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<PurchaseRequestQueryOutDto>>(items);

        return new PagingOut<PurchaseRequestQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PurchaseRequestGetOutDto> Get(PurchaseRequestGetInDto input)
    {
        var query = from a in _dbContext.PurchaseRequests.AsNoTracking()
                    orderby a.Id
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<PurchaseRequestGetOutDto>(items);
    }
}

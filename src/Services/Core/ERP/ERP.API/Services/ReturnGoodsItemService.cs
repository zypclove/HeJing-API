﻿using ERP.Shared.DTO.ReturnGoodsItem;

namespace ERP.HostApp.Services;

/// <summary>
/// 退货清单
/// </summary>
public class ReturnGoodsItemService : ServiceBase
{
    private readonly ERPDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public ReturnGoodsItemService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<ERPDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(ReturnGoodsItemCreateInDto input)
    {
        var model = Mapper.Map<ReturnGoodsItem>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.ReturnGoodsItems.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(ReturnGoodsItemUpdateInDto input)
    {
        var model = await _dbContext.ReturnGoodsItems.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(ReturnGoodsItemDeleteInDto input)
    {
        var model = await _dbContext.ReturnGoodsItems.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.ReturnGoodsItems.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(ReturnGoodsItemBatchDeleteInDto input)
    {
        var model = await _dbContext.ReturnGoodsItems.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.ReturnGoodsItems.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<ReturnGoodsItemQueryOutDto>> Query(ReturnGoodsItemQueryInDto input)
    {
        var query = from a in _dbContext.ReturnGoodsItems.AsNoTracking()
                    orderby a.Id
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<ReturnGoodsItemQueryOutDto>>(items);

        return new PagingOut<ReturnGoodsItemQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ReturnGoodsItemGetOutDto> Get(ReturnGoodsItemGetInDto input)
    {
        var query = from a in _dbContext.ReturnGoodsItems.AsNoTracking()
                    orderby a.Id
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<ReturnGoodsItemGetOutDto>(items);
    }
}

using ERP.Shared.DTO.Contract;

namespace ERP.HostApp.Services;

/// <summary>
/// 合同
/// </summary>
public class ContractService : ServiceBase
{
    private readonly ERPDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public ContractService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<ERPDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(ContractCreateInDto input)
    {
        var model = Mapper.Map<Contract>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.Contracts.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(ContractUpdateInDto input)
    {
        var model = await _dbContext.Contracts.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(ContractDeleteInDto input)
    {
        var model = await _dbContext.Contracts.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.Contracts.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(ContractBatchDeleteInDto input)
    {
        var model = await _dbContext.Contracts.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.Contracts.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<ContractQueryOutDto>> Query(ContractQueryInDto input)
    {
        var query = from a in _dbContext.Contracts.AsNoTracking()
                    orderby a.Id
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<ContractQueryOutDto>>(items);

        return new PagingOut<ContractQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ContractGetOutDto> Get(ContractGetInDto input)
    {
        var query = from a in _dbContext.Contracts.AsNoTracking()
                    orderby a.Id
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<ContractGetOutDto>(items);
    }
}

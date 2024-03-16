using CommonServer.Shared.DTO.OrganRoleFunction;

namespace CommonServer.HostApp.Services;

/// <summary>
/// 角色功能
/// </summary>
public class OrganRoleFunctionService : ServiceBase
{
    private readonly CommonServerDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public OrganRoleFunctionService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<CommonServerDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(OrganRoleFunctionCreateInDto input)
    {
        var model = Mapper.Map<OrganRoleFunction>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.OrganRoleFunctions.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(OrganRoleFunctionUpdateInDto input)
    {
        var model = await _dbContext.OrganRoleFunctions.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(OrganRoleFunctionDeleteInDto input)
    {
        var model = await _dbContext.OrganRoleFunctions.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.OrganRoleFunctions.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(OrganRoleFunctionBatchDeleteInDto input)
    {
        var model = await _dbContext.OrganRoleFunctions.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.OrganRoleFunctions.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<OrganRoleFunctionQueryOutDto>> Query(OrganRoleFunctionQueryInDto input)
    {
        var query = from a in _dbContext.OrganRoleFunctions.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<OrganRoleFunctionQueryOutDto>>(items);

        return new PagingOut<OrganRoleFunctionQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<OrganRoleFunctionGetOutDto> Get(OrganRoleFunctionGetInDto input)
    {
        var query = from a in _dbContext.OrganRoleFunctions.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<OrganRoleFunctionGetOutDto>(items);
    }
}

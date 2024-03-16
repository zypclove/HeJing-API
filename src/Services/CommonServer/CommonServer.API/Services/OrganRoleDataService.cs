using CommonServer.Shared.DTO.OrganRoleData;

namespace CommonServer.HostApp.Services;

/// <summary>
/// 角色数据
/// </summary>
public class OrganRoleDataService : ServiceBase
{
    private readonly CommonServerDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public OrganRoleDataService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<CommonServerDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(OrganRoleDataCreateInDto input)
    {
        var model = Mapper.Map<OrganRoleData>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.OrganRoleDatas.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(OrganRoleDataUpdateInDto input)
    {
        var model = await _dbContext.OrganRoleDatas.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(OrganRoleDataDeleteInDto input)
    {
        var model = await _dbContext.OrganRoleDatas.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.OrganRoleDatas.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(OrganRoleDataBatchDeleteInDto input)
    {
        var model = await _dbContext.OrganRoleDatas.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.OrganRoleDatas.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<OrganRoleDataQueryOutDto>> Query(OrganRoleDataQueryInDto input)
    {
        var query = from a in _dbContext.OrganRoleDatas.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<OrganRoleDataQueryOutDto>>(items);

        return new PagingOut<OrganRoleDataQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<OrganRoleDataGetOutDto> Get(OrganRoleDataGetInDto input)
    {
        var query = from a in _dbContext.OrganRoleDatas.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<OrganRoleDataGetOutDto>(items);
    }
}

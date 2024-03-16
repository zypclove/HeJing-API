using CommonServer.Shared.DTO.OrganUser;

namespace CommonServer.HostApp.Services;

/// <summary>
/// 用户
/// </summary>
public class OrganUserService : ServiceBase
{
    private readonly CommonServerDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public OrganUserService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<CommonServerDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(OrganUserCreateInDto input)
    {
        var model = Mapper.Map<OrganUser>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.OrganUsers.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(OrganUserUpdateInDto input)
    {
        var model = await _dbContext.OrganUsers.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(OrganUserDeleteInDto input)
    {
        var model = await _dbContext.OrganUsers.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.OrganUsers.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(OrganUserBatchDeleteInDto input)
    {
        var model = await _dbContext.OrganUsers.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.OrganUsers.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<OrganUserQueryOutDto>> Query(OrganUserQueryInDto input)
    {
        var query = from a in _dbContext.OrganUsers.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<OrganUserQueryOutDto>>(items);

        return new PagingOut<OrganUserQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<OrganUserGetOutDto> Get(OrganUserGetInDto input)
    {
        var query = from a in _dbContext.OrganUsers.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<OrganUserGetOutDto>(items);
    }
}

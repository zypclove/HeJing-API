using CommonServer.Shared.DTO.OrganRole;

namespace CommonServer.HostApp.Services;

/// <summary>
/// 角色
/// </summary>
public class OrganRoleService : ServiceBase
{
    private readonly CommonServerDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public OrganRoleService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<CommonServerDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(OrganRoleCreateInDto input)
    {
        var model = Mapper.Map<OrganRole>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.OrganRoles.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(OrganRoleUpdateInDto input)
    {
        var model = await _dbContext.OrganRoles.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(OrganRoleDeleteInDto input)
    {
        var model = await _dbContext.OrganRoles.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.OrganRoles.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(OrganRoleBatchDeleteInDto input)
    {
        var model = await _dbContext.OrganRoles.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.OrganRoles.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<OrganRoleQueryOutDto>> Query(OrganRoleQueryInDto input)
    {
        var query = from a in _dbContext.OrganRoles.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<OrganRoleQueryOutDto>>(items);

        return new PagingOut<OrganRoleQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<OrganRoleGetOutDto> Get(OrganRoleGetInDto input)
    {
        var query = from a in _dbContext.OrganRoles.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<OrganRoleGetOutDto>(items);
    }
}

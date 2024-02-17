using IdentityServerPlus.Shared.DTO.OrganUserRole;

namespace IdentityServerPlus.HostApp.Services;

/// <summary>
/// 用户角色
/// </summary>
public class OrganUserRoleService : ServiceBase
{
    private readonly IdentityServerPlusDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public OrganUserRoleService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<IdentityServerPlusDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(OrganUserRoleCreateInDto input)
    {
        var model = Mapper.Map<OrganUserRole>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.OrganUserRoles.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(OrganUserRoleUpdateInDto input)
    {
        var model = await _dbContext.OrganUserRoles.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(OrganUserRoleDeleteInDto input)
    {
        var model = await _dbContext.OrganUserRoles.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.OrganUserRoles.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(OrganUserRoleBatchDeleteInDto input)
    {
        var model = await _dbContext.OrganUserRoles.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.OrganUserRoles.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<OrganUserRoleQueryOutDto>> Query(OrganUserRoleQueryInDto input)
    {
        var query = from a in _dbContext.OrganUserRoles.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<OrganUserRoleQueryOutDto>>(items);

        return new PagingOut<OrganUserRoleQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<OrganUserRoleGetOutDto> Get(OrganUserRoleGetInDto input)
    {
        var query = from a in _dbContext.OrganUserRoles.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<OrganUserRoleGetOutDto>(items);
    }
}

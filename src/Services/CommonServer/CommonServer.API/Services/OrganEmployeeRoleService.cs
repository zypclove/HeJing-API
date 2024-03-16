using CommonServer.Shared.DTO.OrganEmployeeRole;

namespace CommonServer.HostApp.Services;

/// <summary>
/// 用户角色
/// </summary>
public class OrganEmployeeRoleService : ServiceBase
{
    private readonly CommonServerDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public OrganEmployeeRoleService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<CommonServerDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(OrganEmployeeRoleCreateInDto input)
    {
        var model = Mapper.Map<OrganEmployeeRole>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.OrganEmployeeRoles.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(OrganEmployeeRoleUpdateInDto input)
    {
        var model = await _dbContext.OrganEmployeeRoles.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(OrganEmployeeRoleDeleteInDto input)
    {
        var model = await _dbContext.OrganEmployeeRoles.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.OrganEmployeeRoles.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(OrganEmployeeRoleBatchDeleteInDto input)
    {
        var model = await _dbContext.OrganEmployeeRoles.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.OrganEmployeeRoles.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<OrganEmployeeRoleQueryOutDto>> Query(OrganEmployeeRoleQueryInDto input)
    {
        var query = from a in _dbContext.OrganEmployeeRoles.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<OrganEmployeeRoleQueryOutDto>>(items);

        return new PagingOut<OrganEmployeeRoleQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<OrganEmployeeRoleGetOutDto> Get(OrganEmployeeRoleGetInDto input)
    {
        var query = from a in _dbContext.OrganEmployeeRoles.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<OrganEmployeeRoleGetOutDto>(items);
    }
}

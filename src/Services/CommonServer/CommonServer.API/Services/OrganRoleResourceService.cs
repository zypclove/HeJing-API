using CommonServer.Shared.DTO.OrganRoleResource;

namespace CommonServer.HostApp.Services;

/// <summary>
/// 角色资源
/// </summary>
public class OrganRoleResourceService : ServiceBase
{
    private readonly CommonServerDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public OrganRoleResourceService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<CommonServerDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(OrganRoleResourceCreateInDto input)
    {
        var model = Mapper.Map<OrganRoleResource>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.OrganRoleResources.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(OrganRoleResourceUpdateInDto input)
    {
        var model = await _dbContext.OrganRoleResources.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(OrganRoleResourceDeleteInDto input)
    {
        var model = await _dbContext.OrganRoleResources.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.OrganRoleResources.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(OrganRoleResourceBatchDeleteInDto input)
    {
        var model = await _dbContext.OrganRoleResources.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.OrganRoleResources.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<OrganRoleResourceQueryOutDto>> Query(OrganRoleResourceQueryInDto input)
    {
        var query = from a in _dbContext.OrganRoleResources.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<OrganRoleResourceQueryOutDto>>(items);

        return new PagingOut<OrganRoleResourceQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<OrganRoleResourceGetOutDto> Get(OrganRoleResourceGetInDto input)
    {
        var query = from a in _dbContext.OrganRoleResources.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<OrganRoleResourceGetOutDto>(items);
    }
}

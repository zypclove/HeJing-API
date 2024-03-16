using CommonServer.Shared.DTO.Organs;

namespace CommonServer.HostApp.Services;

/// <summary>
/// 机构
/// </summary>
public class OrgansService : ServiceBase
{
    private readonly CommonServerDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public OrgansService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<CommonServerDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(OrgansCreateInDto input)
    {
        var model = Mapper.Map<Organs>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.Organses.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(OrgansUpdateInDto input)
    {
        var model = await _dbContext.Organses.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(OrgansDeleteInDto input)
    {
        var model = await _dbContext.Organses.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.Organses.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(OrgansBatchDeleteInDto input)
    {
        var model = await _dbContext.Organses.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.Organses.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<OrgansQueryOutDto>> Query(OrgansQueryInDto input)
    {
        var query = from a in _dbContext.Organses.AsNoTracking()
                    select a;

        #region filter
        query = query.WhereIf(!string.IsNullOrEmpty(input.Name), x => x.Name.Contains(input.Name!) || x.ShortName.Contains(input.Name!));
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderBy(x=>x.SortNo)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<OrgansQueryOutDto>>(items);

        return new PagingOut<OrgansQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<OrgansGetOutDto> Get(OrgansGetInDto input)
    {
        var query = from a in _dbContext.Organses.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<OrgansGetOutDto>(items);
    }
}

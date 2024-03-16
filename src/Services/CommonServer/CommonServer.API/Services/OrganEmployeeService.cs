using CommonServer.Shared.DTO.OrganEmployee;

namespace CommonServer.HostApp.Services;

/// <summary>
/// 员工
/// </summary>
public class OrganEmployeeService : ServiceBase
{
    private readonly CommonServerDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public OrganEmployeeService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<CommonServerDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(OrganEmployeeCreateInDto input)
    {
        var model = Mapper.Map<OrganEmployee>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.OrganEmployees.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(OrganEmployeeUpdateInDto input)
    {
        var model = await _dbContext.OrganEmployees.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(OrganEmployeeDeleteInDto input)
    {
        var model = await _dbContext.OrganEmployees.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.OrganEmployees.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(OrganEmployeeBatchDeleteInDto input)
    {
        var model = await _dbContext.OrganEmployees.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.OrganEmployees.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<OrganEmployeeQueryOutDto>> Query(OrganEmployeeQueryInDto input)
    {
        var query = from a in _dbContext.OrganEmployees.Include(x=>x.Department).AsNoTracking()
                    where a.Department.OrganId == input.OrganId
                    select a;

        #region filter
        query = query.WhereIf(!string.IsNullOrEmpty(input.Name), x => x.Name.Contains(input.Name!));
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<OrganEmployeeQueryOutDto>>(items);

        return new PagingOut<OrganEmployeeQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<OrganEmployeeGetOutDto> Get(OrganEmployeeGetInDto input)
    {
        var query = from a in _dbContext.OrganEmployees.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<OrganEmployeeGetOutDto>(items);
    }
}

using CommonServer.Shared.DTO.OrganDepartment;

namespace CommonServer.HostApp.Services;

/// <summary>
/// 部门
/// </summary>
public class OrganDepartmentService : ServiceBase
{
    private readonly CommonServerDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public OrganDepartmentService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<CommonServerDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(OrganDepartmentCreateInDto input)
    {
        var model = Mapper.Map<OrganDepartment>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.OrganDepartments.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(OrganDepartmentUpdateInDto input)
    {
        var model = await _dbContext.OrganDepartments.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(OrganDepartmentDeleteInDto input)
    {
        var model = await _dbContext.OrganDepartments.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.OrganDepartments.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(OrganDepartmentBatchDeleteInDto input)
    {
        var model = await _dbContext.OrganDepartments.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.OrganDepartments.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<OrganDepartmentQueryOutDto>> Query(OrganDepartmentQueryInDto input)
    {
        var query = from a in _dbContext.OrganDepartments.AsNoTracking()
                    where a.OrganId == input.OrganId
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

        var treeItems = items.ToTree<OrganDepartment>(
            (r, c) =>
            {
                return c.ParentId == null;
            },
            (r, c) =>
            {
                return r.Id == c.ParentId;
            },
            (r, dataList) =>
            {
                r.Children ??= new List<OrganDepartment>();
                r.Children.AddRange(dataList);
            });

        var itemDtos = Mapper.Map<IList<OrganDepartmentQueryOutDto>>(treeItems);

        return new PagingOut<OrganDepartmentQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取树清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<IList<OrganDepartmentQueryTreeSelectOutDto>> QueryTreeSelect(OrganDepartmentQueryInDto input)
    {
        var query = from a in _dbContext.OrganDepartments.AsNoTracking()
                    where a.OrganId == input.OrganId
                    select a;

        #region filter
        #endregion

        var items = await query
            .OrderByDescending(x => x.LastModifyTime)
            .ToListAsync();

        var treeItems = items.ToTree<OrganDepartment>(
            (r, c) =>
            {
                return c.ParentId == null;
            },
            (r, c) =>
            {
                return r.Id == c.ParentId;
            },
            (r, dataList) =>
            {
                r.Children ??= new List<OrganDepartment>();
                r.Children.AddRange(dataList);
            });

        var itemDtos = Mapper.Map<IList<OrganDepartmentQueryTreeSelectOutDto>>(treeItems);

        return itemDtos;
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<OrganDepartmentGetOutDto> Get(OrganDepartmentGetInDto input)
    {
        var query = from a in _dbContext.OrganDepartments.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<OrganDepartmentGetOutDto>(items);
    }
}

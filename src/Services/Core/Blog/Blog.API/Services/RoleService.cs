using Blog.Domain.Model;
using Blog.Infrastructure;
using Blog.Shared.DTO.Role;

namespace Blog.HostApp.Areas.Blog.Services;

/// <summary>
/// 
/// </summary>
public class RoleService : ServiceBase
{
    private BlogDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public RoleService(BlogDbContext dbContext, IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<RoleCreateOutDto> Create(RoleCreateInDto input)
    {
        var model = Mapper.Map<Role>(input);

        await _dbContext.Roles.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return new RoleCreateOutDto { };
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<RoleUpdateOutDto> Update(RoleUpdateInDto input)
    {
        var model = await _dbContext.Roles.SingleAsync(x => x.Id.Equals(input.Id));

        Mapper.Map(input, model);

        await _dbContext.SaveChangesAsync();

        return new RoleUpdateOutDto { };
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<RoleDeleteOutDto> Delete(RoleDeleteInDto input)
    {
        var model = await _dbContext.Roles.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.Roles.Remove(model);

        await _dbContext.SaveChangesAsync();

        return new RoleDeleteOutDto { };
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<RoleQueryOutDto>> Query(RoleQueryInDto input)
    {
        var query = from a in _dbContext.Roles.AsNoTracking()
                    orderby a.Id
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<RoleQueryOutDto>>(items);

        return new PagingOut<RoleQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<RoleGetOutDto> Get(RoleGetInDto input)
    {
        var query = from a in _dbContext.Roles.AsNoTracking()
                    orderby a.Id
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<RoleGetOutDto>(items);
    }
}

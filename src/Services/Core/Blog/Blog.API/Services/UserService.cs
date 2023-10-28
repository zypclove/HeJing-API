using Blog.Domain.Model;
using Blog.Infrastructure;
using Blog.Shared.DTO.User;

namespace Blog.HostApp.Areas.Blog.Services;

/// <summary>
/// 
/// </summary>
public class UserService : ServiceBase
{
    private BlogDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public UserService(BlogDbContext dbContext, IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<UserCreateOutDto> Create(UserCreateInDto input)
    {
        var model = Mapper.Map<User>(input);

        await _dbContext.Users.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return new UserCreateOutDto { };
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<UserUpdateOutDto> Update(UserUpdateInDto input)
    {
        var model = await _dbContext.Users.SingleAsync(x => x.Id.Equals(input.Id));

        Mapper.Map(input, model);

        await _dbContext.SaveChangesAsync();

        return new UserUpdateOutDto { };
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<UserDeleteOutDto> Delete(UserDeleteInDto input)
    {
        var model = await _dbContext.Users.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.Users.Remove(model);

        await _dbContext.SaveChangesAsync();

        return new UserDeleteOutDto { };
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<UserQueryOutDto>> Query(UserQueryInDto input)
    {
        var query = from a in _dbContext.Users.AsNoTracking()
                    orderby a.Id
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<UserQueryOutDto>>(items);

        return new PagingOut<UserQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<UserGetOutDto> Get(UserGetInDto input)
    {
        var query = from a in _dbContext.Users.AsNoTracking()
                    orderby a.Id
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<UserGetOutDto>(items);
    }

    /// <summary>
    /// 注册
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Register(UserRegisterInDto input)
    {
        var model = Mapper.Map<User>(input);

        await _dbContext.Users.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 用户登录
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Login(UserLoginInDto input)
    {
        var model = await _dbContext.Users.AnyAsync(x => x.UserName.Equals(input.UserName) && x.Password.Equals(input.Password));
        return model;
    }
}

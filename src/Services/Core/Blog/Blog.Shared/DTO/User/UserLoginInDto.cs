using System.ComponentModel.DataAnnotations;

namespace Blog.Shared.DTO.User;

/// <summary>
/// 用户登录
/// </summary>
public class UserLoginInDto
{
    /// <summary>
    /// 用户名称
    /// </summary>
    public string UserName { get; set; } = null!;

    /// <summary>
    /// 用户密码
    /// </summary>
    public string Password { get; set; } = null!;
}
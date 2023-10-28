using System.ComponentModel.DataAnnotations;

namespace Blog.Shared.DTO.User;

/// <summary>
/// 用户注册
/// </summary>
public class UserRegisterInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 用户名称
    /// </summary>
    [Required]
    [StringLength(20, ErrorMessage = "{0}的长度必须至少为{2}个字符，最多为{1}个字符。", MinimumLength = 6)]
    public string UserName { get; set; } = null!;

    /// <summary>
    /// 电子邮件
    /// </summary>
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    /// <summary>
    /// 用户密码
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    /// <summary>
    /// 确认密码
    /// </summary>
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
    public string ConfirmPassword { get; set; } = null!;

}
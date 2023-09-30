using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain.Model;

/// <summary>
/// 用户
/// </summary>
[Table("User")]
public partial class User : Entity
{
    /// <summary>
    /// 用户名称
    /// </summary>
    [StringLength(50)]
    public string UserName { get; set; } = null!;
    /// <summary>
    /// 用户密码
    /// </summary>
    [StringLength(50)]
    public string Password { get; set; } = null!;
    /// <summary>
    /// 电子邮件
    /// </summary>
    [StringLength(100)]
    public string Email { get; set; } = null!;
}
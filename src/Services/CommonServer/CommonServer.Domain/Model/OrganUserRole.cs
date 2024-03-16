using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonServer.Domain.Model;

/// <summary>
/// 用户角色
/// </summary>
[Table("OrganUserRole")]
[Comment("用户角色")]
public partial class OrganUserRole : Entity
{
    /// <summary>
    /// 用户标识
    /// </summary>
    [Comment("用户标识")]
    public Guid UserId { get; set; }
    public OrganUser? User { get; set; }
    /// <summary>
    /// 角色标识
    /// </summary>
    [StringLength(50)]
    [Comment("角色标识")]
    public Guid RoleId { get; set; }
    public OrganRole? Role { get; set; }
}
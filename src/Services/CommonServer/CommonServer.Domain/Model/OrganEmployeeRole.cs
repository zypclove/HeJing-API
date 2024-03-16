using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonServer.Domain.Model;

/// <summary>
/// 员工角色
/// </summary>
[Table("OrganEmployeeRole")]
[Comment("员工角色")]
public partial class OrganEmployeeRole : Entity
{
    /// <summary>
    /// 员工标识
    /// </summary>
    [Comment("用户标识")]
    public Guid EmployeeId { get; set; }
    public OrganEmployee? Employee { get; set; }
    /// <summary>
    /// 角色标识
    /// </summary>
    [StringLength(50)]
    [Comment("角色标识")]
    public Guid RoleId { get; set; }
    public OrganRole? Role { get; set; }
}
using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonServer.Domain.Model;

/// <summary>
/// 角色资源
/// </summary>
[Table("OrganRoleResource")]
[Comment("角色资源")]
public partial class OrganRoleResource : Entity
{
    /// <summary>
    /// 角色标识
    /// </summary>
    [StringLength(50)]
    [Comment("角色标识")]
    public Guid RoleId { get; set; }
    public OrganRole? Role { get; set; }
    /// <summary>
    /// 资源标识
    /// </summary>
    [Comment("资源标识")]
    public Guid ResourceId { get; set; }
    public AppResource? Resource { get; set; }
}
using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonServer.Domain.Model;

/// <summary>
/// 角色数据
/// </summary>
[Table("OrganRoleData")]
[Comment("角色数据")]
public partial class OrganRoleData : Entity
{
    /// <summary>
    /// 角色标识
    /// </summary>
    [StringLength(50)]
    [Comment("角色标识")]
    public Guid RoleId { get; set; }
    public OrganRole? Role { get; set; }
    /// <summary>
    /// 数据标识
    /// </summary>
    [Comment("数据标识")]
    public Guid? DataId { get; set; }
    public AppData? Data { get; set; }
}
using CommonMormon.Infrastructure.Domain.SeedWork;
using CommonServer.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonServer.Domain.Model;

/// <summary>
/// 员工
/// </summary>
[Table("OrganEmployee")]
[Comment("员工")]
public partial class OrganEmployee : Entity
{
    /// <summary>
    /// 部门标识
    /// </summary>
    [Comment("部门标识")]
    public Guid DepartmentId { get; set; }
    public OrganDepartment? Department { get; set; }
    /// <summary>
    /// 用户标识
    /// </summary>
    [StringLength(450)]
    [Comment("用户标识")]
    public string? UserId { get; set; }
    /// <summary>
    /// 姓名
    /// </summary>
    [StringLength(200)]
    [Comment("姓名")]
    public string Name { get; set; } = null!;
    /// <summary>
    /// 编号
    /// </summary>
    [StringLength(50)]
    [Comment("编号")]
    public string Code { get; set; } = null!;
    /// <summary>
    /// 性别
    /// </summary>
    [StringLength(200)]
    [Comment("性别")]
    public GenderEnum Gender { get; set; }
    /// <summary>
    /// 昵称
    /// </summary>
    [StringLength(200)]
    [Comment("昵称")]
    public string? NickName { get; set; }
    /// <summary>
    /// 联系电话
    /// </summary>
    [StringLength(200)]
    [Comment("联系电话")]
    public string? Tel { get; set; }
    /// <summary>
    /// 电子邮箱
    /// </summary>
    [StringLength(200)]
    [Comment("电子邮箱")]
    public string? Email { get; set; }
    /// <summary>
    /// 备注
    /// </summary>
    [StringLength(2000)]
    [Comment("备注")]
    public string? Remark { get; set; }
    /// <summary>
    /// 是否启用
    /// </summary>
    [Comment("是否启用")]
    public bool EnabledFlag { get; set; }
    /// <summary>
    /// 排序号
    /// </summary>
    [Comment("排序号")]
    public int SortNo { get; set; }
}
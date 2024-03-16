using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MassTransit.MessageHeaders;

namespace CommonServer.Domain.Model;

/// <summary>
/// 机构
/// </summary>
[Table("Organs")]
[Comment("机构")]
public partial class Organs : Entity
{
    /// <summary>
    /// 编号
    /// </summary>
    [StringLength(50)]
    [Comment("编号")]
    public string Code { get; set; } = null!;
    /// <summary>
    /// 名称
    /// </summary>
    [StringLength(200)]
    [Comment("名称")]
    public string Name { get; set; } = null!;
    /// <summary>
    /// 简称
    /// </summary>
    [StringLength(200)]
    [Comment("简称")]
    public string? ShortName { get; set; }
    /// <summary>
    /// 联系地址
    /// </summary>
    [StringLength(200)]
    [Comment("联系地址")]
    public string? Address { get; set; }
    /// <summary>
    /// 邮政编码
    /// </summary>
    [StringLength(200)]
    [Comment("邮政编码")]
    public string? ZipCode { get; set; }
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
    /// 联系人
    /// </summary>
    [StringLength(200)]
    [Comment("联系人")]
    public string? ContactPerson { get; set; }
    /// <summary>
    /// 联系人电话
    /// </summary>
    [StringLength(200)]
    [Comment("联系人电话")]
    public string? ContactPersonTel { get; set; }
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
    public IList<OrganRole> Roles { get; } = new List<OrganRole>();
    public IList<OrganDepartment> Departments { get; } = new List<OrganDepartment>();
}
using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Model;

/// <summary>
/// 供应商
/// </summary>
[Table("Supplier")]
[Comment("供应商")]
public partial class Supplier : Entity
{
    /// <summary>
    /// 名称
    /// </summary>
    [StringLength(200)]
    [Comment("名称")]
    public string Name { get; set; } = null!;
    /// <summary>
    /// 地址
    /// </summary>
    [StringLength(2000)]
    [Comment("地址")]
    public string? Address { get; set; }
    /// <summary>
    /// 联系人
    /// </summary>
    [StringLength(200)]
    [Comment("联系人")]
    public string? ContactPerson { get; set; }
    /// <summary>
    /// 联系电话
    /// </summary>
    [StringLength(200)]
    [Comment("联系电话")]
    public string? ContactTel { get; set; }
    /// <summary>
    /// 电子邮件
    /// </summary>
    [StringLength(200)]
    [Comment("电子邮件")]
    public string? Email { get; set; }

}
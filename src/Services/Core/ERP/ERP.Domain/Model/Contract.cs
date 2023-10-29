using CommonMormon.Infrastructure.Domain.SeedWork;
using ERP.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Model;

/// <summary>
/// 合同
/// </summary>
[Table("Contract")]
[Comment("合同")]
public partial class Contract : Entity
{
    /// <summary>
    /// 合同类型
    /// </summary>
    [Comment("合同类型")]
    public ContractType ContractType { get; set; }
    /// <summary>
    /// 合同编号
    /// </summary>
    [StringLength(50)]
    [Comment("合同编号")]
    public string? ContractNumber { get; set; }
    /// <summary>
    /// 合同日期
    /// </summary>
    [Comment("合同日期")]
    public DateTimeOffset ContractDate { get; set; }
    /// <summary>
    /// 合同标题
    /// </summary>
    [StringLength(200)]
    [Comment("合同标题")]
    public string ContractTitle { get; set; } = null!;
    /// <summary>
    /// 备注
    /// </summary>
    [StringLength(2000)]
    [Comment("备注")]
    public string? Remark { get; set; }
    /// <summary>
    /// 合同清单
    /// </summary>
    public List<ContractItem> ContractItems = new List<ContractItem>();
}
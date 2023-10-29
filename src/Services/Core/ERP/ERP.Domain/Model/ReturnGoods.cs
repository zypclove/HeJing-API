using CommonMormon.Infrastructure.Domain.SeedWork;
using ERP.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Model;

/// <summary>
/// 退货
/// </summary>
[Table("ReturnGoods")]
[Comment("退货")]
public partial class ReturnGoods : Entity
{
    /// <summary>
    /// 退货类型
    /// </summary>
    [Comment("退货类型")]
    public ReturnGoodsType ReturnGoodsType { get; set; }
    /// <summary>
    /// 退货编号
    /// </summary>
    [StringLength(50)]
    [Comment("退货编号")]
    public string? ReturnGoodsNumber { get; set; }
    /// <summary>
    /// 退货日期
    /// </summary>
    [Comment("退货日期")]
    public DateTimeOffset ReturnGoodsDate { get; set; }
    /// <summary>
    /// 退货标题
    /// </summary>
    [StringLength(200)]
    [Comment("退货标题")]
    public string ReturnGoodsTitle { get; set; } = null!;
    /// <summary>
    /// 备注
    /// </summary>
    [StringLength(2000)]
    [Comment("备注")]
    public string? Remark { get; set; }
    /// <summary>
    /// 退货清单
    /// </summary>
    public List<ReturnGoodsItem> ReturnGoodsItems = new List<ReturnGoodsItem>();
}
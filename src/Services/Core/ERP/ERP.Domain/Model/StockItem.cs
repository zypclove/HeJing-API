﻿using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Model;

/// <summary>
/// 库存清单
/// </summary>
[Table("StockItem")]
[Comment("库存清单")]
public partial class StockItem : Entity
{
    /// <summary>
    /// 库存
    /// </summary>
    public Stock Stock { get; set; } = null!;
    [Comment("库存标识")]
    public Guid StockId { get; set; }
    /// <summary>
    /// 物品
    /// </summary>
    public Goods Goods { get; set; } = null!;
    [Comment("物品标识")]
    public Guid GoodsId { get; set; }
    /// <summary>
    /// 数量
    /// </summary>
    [Comment("数量")]
    public int Quantity { get; set; }
    /// <summary>
    /// 单价
    /// </summary>
    [Comment("单价")]
    public decimal UnitPrice { get; set; }
    /// <summary>
    /// 总价
    /// </summary>
    [Comment("总价")]
    public decimal TotalPrice
    {
        get
        {
            return Quantity * UnitPrice;
        }
        set { }
    }
    /// <summary>
    /// 备注
    /// </summary>
    [StringLength(2000)]
    [Comment("备注")]
    public string? Remark { get; set; }
}
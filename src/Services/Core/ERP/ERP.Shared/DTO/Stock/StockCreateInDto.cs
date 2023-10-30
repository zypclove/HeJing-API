﻿using ERP.Shared.Models;

namespace ERP.Shared.DTO.Stock;

/// <summary>
/// 库存
/// </summary>
public class StockCreateInDto : DtoBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 库存类型
    /// </summary>
    public int StockType { get; set; }
    /// <summary>
    /// 库存编号
    /// </summary>
    public string? StockNumber { get; set; }
    /// <summary>
    /// 库存日期
    /// </summary>
    public System.DateTimeOffset StockDate { get; set; }
    /// <summary>
    /// 库存标题
    /// </summary>
    public string StockTitle { get; set; } = null!;
    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }
    /// <summary>
    /// 库存清单
    /// </summary>
    public IList<StockItemModel> Items { get; set; } = new List<StockItemModel>();
}

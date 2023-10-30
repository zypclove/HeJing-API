﻿namespace ERP.Shared.Models;

/// <summary>
/// 合同清单
/// </summary>
public class ContractItemModel
{
    /// <summary>
    /// 物品名称
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 品牌型号
    /// </summary>
    public string BrandModel { get; set; } = null!;
    /// <summary>
    /// 数量
    /// </summary>
    public int Quantity { get; set; }
    /// <summary>
    /// 单价
    /// </summary>
    public decimal UnitPrice { get; set; }
}

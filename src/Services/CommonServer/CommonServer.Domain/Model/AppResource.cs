using CommonMormon.Infrastructure.Domain.SeedWork;
using CommonServer.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonServer.Domain.Model;

/// <summary>
/// 资源
/// </summary>
[Table("AppResource")]
[Comment("资源")]
public partial class AppResource : TreeEntity<AppResource>
{
    /// <summary>
    /// 资源类型
    /// </summary>
    [Comment("资源类型")]
    public ResourceTypeEnum ResourceType { get; set; }
    /// <summary>
    /// 路径
    /// </summary>
    [StringLength(200)]
    [Comment("路径")]
    public string Path { get; set; } = null!;
    /// <summary>
    /// 名称
    /// </summary>
    [StringLength(200)]
    [Comment("名称")]
    public string Name { get; set; } = null!;
    /// <summary>
    /// 组件
    /// </summary>
    [StringLength(200)]
    [Comment("组件")]
    public string? Component { get; set; }
    /// <summary>
    /// 图标
    /// </summary>
    [StringLength(200)]
    [Comment("图标")]
    public string? Icon { get; set; }
    /// <summary>
    /// 标题
    /// </summary>
    [StringLength(200)]
    [Comment("标题")]
    public string? Title { get; set; }
    /// <summary>
    /// 是否外链
    /// </summary>
    [Comment("是否外链")]
    public bool? IsLink { get; set; }
    /// <summary>
    /// 是否隐藏
    /// </summary>
    [Comment("是否隐藏")]
    public bool? IsHide { get; set; }
    /// <summary>
    /// 是否全屏
    /// </summary>
    [Comment("是否全屏")]
    public bool? IsFull { get; set; }
    /// <summary>
    /// 是否固定
    /// </summary>
    [Comment("是否固定")]
    public bool? IsAffix { get; set; }
    /// <summary>
    /// 是否缓存
    /// </summary>
    [Comment("是否缓存")]
    public bool? IsKeepAlive { get; set; }
    /// <summary>
    /// 备注
    /// </summary>
    [StringLength(2000)]
    [Comment("备注")]
    public string? Remark { get; set; }
    /// <summary>
    /// 排序号
    /// </summary>
    [Comment("排序号")]
    public int SortNo { get; set; }
}
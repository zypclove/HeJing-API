namespace CommonServer.Shared.DTO.AppResource;

/// <summary>
/// 资源
/// </summary>
public class AppResourceQueryOutDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 资源类型
    /// </summary>
    public int ResourceType { get; set; }
    /// <summary>
    /// 路径
    /// </summary>
    public string Path { get; set; } = null!;
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 组件
    /// </summary>
    public string? Component { get; set; }
    /// <summary>
    /// 图标
    /// </summary>
    public string? Icon { get; set; }
    /// <summary>
    /// 标题
    /// </summary>
    public string? Title { get; set; }
    /// <summary>
    /// 是否外链
    /// </summary>
    public bool? IsLink { get; set; }
    /// <summary>
    /// 是否隐藏
    /// </summary>
    public bool? IsHide { get; set; }
    /// <summary>
    /// 是否全屏
    /// </summary>
    public bool? IsFull { get; set; }
    /// <summary>
    /// 是否固定
    /// </summary>
    public bool? IsAffix { get; set; }
    /// <summary>
    /// 是否缓存
    /// </summary>
    public bool? IsKeepAlive { get; set; }
    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }
    /// <summary>
    /// 排序号
    /// </summary>
    public int SortNo { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public System.DateTimeOffset CreateTime { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public System.DateTimeOffset LastModifyTime { get; set; }
    /// <summary>
    /// 父级标识
    /// </summary>
    public Guid? ParentId { get; set; }
}


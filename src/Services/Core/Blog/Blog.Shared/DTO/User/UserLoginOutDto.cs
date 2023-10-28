namespace Blog.Shared.DTO.User;

/// <summary>
/// 用户注册
/// </summary>
public class UserLoginOutDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 说明
    /// </summary>
    public string? Notes { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public DateTimeOffset LastModifyTime { get; set; }
}
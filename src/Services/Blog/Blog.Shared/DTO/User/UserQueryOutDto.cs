namespace Blog.Shared.DTO.User;

/// <summary>
/// 
/// </summary>
public class UserQueryOutDto
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string UserName { get; set; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public string Password { get; set; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public string Email { get; set; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public DateTimeOffset CreateTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTimeOffset LastModifyTime { get; set; }
}


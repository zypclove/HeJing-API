namespace Blog.Shared.DTO.Comment;

/// <summary>
/// 
/// </summary>
public class CommentQueryOutDto
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Content { get; set; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public DateTime? PublishDate { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Guid? CreateUserId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? CreateFullName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Guid ArticleId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTimeOffset CreateTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTimeOffset LastModifyTime { get; set; }
}


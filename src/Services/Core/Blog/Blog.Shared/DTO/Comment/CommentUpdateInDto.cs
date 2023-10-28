namespace Blog.Shared.DTO.Comment;

/// <summary>
/// 
/// </summary>
public class CommentUpdateInDto : DtoBase
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
    public Guid ArticleId { get; set; }
}


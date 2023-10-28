namespace Blog.Shared.DTO.Article;

/// <summary>
/// 
/// </summary>
public class ArticleQueryOutDto
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Title { get; set; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public string Content { get; set; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public int Likes { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int Collections { get; set; }
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
    public Guid CategoryId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTimeOffset CreateTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTimeOffset LastModifyTime { get; set; }
}


namespace Blog.Shared.DTO.ArticleCollection;

/// <summary>
/// 
/// </summary>
public class ArticleCollectionQueryOutDto
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Guid ArticleId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Guid UserId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTimeOffset CreateTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTimeOffset LastModifyTime { get; set; }
}


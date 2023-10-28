namespace Blog.Shared.DTO.ArticleCollection;

/// <summary>
/// 
/// </summary>
public class ArticleCollectionCreateInDto : DtoBase
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
}

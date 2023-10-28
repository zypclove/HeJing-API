using System.ComponentModel.DataAnnotations;

namespace Blog.Shared.DTO.Comment;

/// <summary>
/// 
/// </summary>
public class CommentCreateInDto : DtoBase
{
    /// <summary>
    /// 
    /// </summary>
    [Required]
    public string? Content { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Required]
    public string? AuthorName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Guid ArticleId { get; set; }
}

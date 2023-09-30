using System.ComponentModel.DataAnnotations;

namespace Blog.Shared.DTO.Article;

/// <summary>
/// 
/// </summary>
public class ArticleCreateInDto : DtoBase
{
    /// <summary>
    /// 
    /// </summary>
    [Required]
    public string? Title { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Required]
    public string? Content { get; set; }
}

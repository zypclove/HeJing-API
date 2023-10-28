using CommonMormon.Infrastructure.Domain.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain.Model;

/// <summary>
/// 标签
/// </summary>
[Table("Tag")]
public partial class Tag : Entity
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 文章标签集合
    /// </summary>
    public ICollection<ArticleTag>? ArticleTags { get; set; }
}
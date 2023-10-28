using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain.Model;

/// <summary>
/// 文章标签
/// </summary>
[Table("ArticleTag")]
public partial class ArticleTag : Entity
{
    /// <summary>
    /// 文章标识
    /// </summary>
    public Guid ArticleId { get; set; }
    /// <summary>
    /// 文章
    /// </summary>
    public Article Article { get; set; } = null!;
    /// <summary>
    /// 标签标识
    /// </summary>
    public Guid TagId { get; set; }
    /// <summary>
    /// 标签
    /// </summary>
    public Tag Tag { get; set; } = null!;
}
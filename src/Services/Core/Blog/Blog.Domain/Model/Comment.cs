using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain.Model;

/// <summary>
/// 评论
/// </summary>
[Table("Comment")]
public partial class Comment : Entity
{
    /// <summary>
    /// 内容
    /// </summary>
    [StringLength(2000)]
    public string Content { get; set; } = null!;
    /// <summary>
    /// 评论人
    /// </summary>
    [StringLength(100)]
    public string AuthorName { get; set; } = null!;
    /// <summary>
    /// 发布时间
    /// </summary>
    public DateTime? PublishDate { get; set; }
    /// <summary>
    /// 创建人标识
    /// </summary>
    public Guid? CreateUserId { get; set; }
    /// <summary>
    /// 创建人用户姓名
    /// </summary>
    public string? CreateFullName { get; set; }
    /// <summary>
    /// 文章标识
    /// </summary>
    public Guid ArticleId { get; set; }
    /// <summary>
    /// 文章
    /// </summary>
    public Article Article { get; set; } = null!;

}
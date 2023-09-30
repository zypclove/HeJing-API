using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain.Model;

/// <summary>
/// 文章
/// </summary>
[Table("Article")]
public partial class Article : Entity
{
    /// <summary>
    /// 标题
    /// </summary>
    [StringLength(200)]
    public string Title { get; set; } = null!;
    /// <summary>
    /// 内容
    /// </summary>
    [StringLength(2000)]
    public string Content { get; set; } = null!;
    /// <summary>
    /// 点赞数
    /// </summary>
    public int Likes { get; set; }
    /// <summary>
    /// 点赞数
    /// </summary>
    public int Collections { get; set; }
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
    /// 分类标识
    /// </summary>
    public Guid CategoryId { get; set; }
    /// <summary>
    /// 分类
    /// </summary>
    public Category Category { get; set; } = null!;
    /// <summary>
    /// 文章评论集合
    /// </summary>
    public ICollection<Comment>? Comments { get; set; }
    /// <summary>
    /// 文章标签集合
    /// </summary>
    public ICollection<ArticleTag>? ArticleTags { get; set; }

}
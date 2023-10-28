using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain.Model;

/// <summary>
/// 文章标签
/// </summary>
[Table("ArticleCollection")]
public partial class ArticleCollection : Entity
{
    /// <summary>
    /// 文章标识
    /// </summary>
    public Guid ArticleId { get; set; }
    /// <summary>
    /// 用户标识
    /// </summary>
    public Guid UserId { get; set; }
}
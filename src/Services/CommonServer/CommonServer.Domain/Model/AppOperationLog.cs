using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonServer.Domain.Model;

/// <summary>
/// 操作日志
/// </summary>
[Table("AppOperationLog")]
[Comment("操作日志")]
public partial class AppOperationLog : Entity
{
    /// <summary>
    /// 事件
    /// </summary>
    [Comment("事件")]
    public string? Event { get; set; }
    /// <summary>
    /// 来源
    /// </summary>
    [Comment("来源")]
    public string? Source { get; set; }
    /// <summary>
    /// 分类
    /// </summary>
    [Comment("分类")]
    public string? Category { get; set; }
    /// <summary>
    /// 用户标识
    /// </summary>
    [Comment("用户标识")]
    public string? UserId { get; set; }
    /// <summary>
    /// 用户名称
    /// </summary>
    [Comment("用户名称")]
    public string? UserName { get; set; }
    /// <summary>
    /// 操作
    /// </summary>
    public string? Action { get; set; }
    /// <summary>
    /// 数据
    /// </summary>
    public string? Data { get; set; }
}
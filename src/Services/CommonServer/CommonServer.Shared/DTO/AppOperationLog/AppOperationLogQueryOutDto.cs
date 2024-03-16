﻿namespace CommonServer.Shared.DTO.AppOperationLog;

/// <summary>
/// 操作日志
/// </summary>
public class AppOperationLogQueryOutDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 事件
    /// </summary>
    public string? Event { get; set; }
    /// <summary>
    /// 来源
    /// </summary>
    public string? Source { get; set; }
    /// <summary>
    /// 分类
    /// </summary>
    public string? Category { get; set; }
    /// <summary>
    /// 用户标识
    /// </summary>
    public string? UserId { get; set; }
    /// <summary>
    /// 用户名称
    /// </summary>
    public string? UserName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? Action { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? Data { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public System.DateTimeOffset CreateTime { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public System.DateTimeOffset LastModifyTime { get; set; }
}


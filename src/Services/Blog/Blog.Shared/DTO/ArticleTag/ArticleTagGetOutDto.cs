﻿namespace Blog.Shared.DTO.ArticleTag;

/// <summary>
/// 
/// </summary>
public class ArticleTagGetOutDto : DtoBase
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
    public Guid TagId { get; set; }
}


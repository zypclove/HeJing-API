namespace Blog.Shared.DTO.Category;

/// <summary>
/// 
/// </summary>
public class CategoryUpdateInDto : DtoBase
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; } = null!;
}


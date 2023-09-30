namespace Blog.Shared.DTO.Category;

/// <summary>
/// 
/// </summary>
public class CategoryCreateInDto : DtoBase
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

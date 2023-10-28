namespace Blog.Shared.DTO.Tag;

/// <summary>
/// 
/// </summary>
public class TagGetOutDto : DtoBase
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


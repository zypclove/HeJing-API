namespace Blog.Shared.DTO.Role;

/// <summary>
/// 
/// </summary>
public class RoleUpdateInDto : DtoBase
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


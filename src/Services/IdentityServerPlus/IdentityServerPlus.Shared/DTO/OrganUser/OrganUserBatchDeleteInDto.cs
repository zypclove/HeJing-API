namespace IdentityServerPlus.Shared.DTO.OrganUser;

/// <summary>
/// 用户
/// </summary>
public class OrganUserBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


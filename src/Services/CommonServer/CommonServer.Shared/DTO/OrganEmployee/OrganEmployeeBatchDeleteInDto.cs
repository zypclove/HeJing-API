namespace CommonServer.Shared.DTO.OrganEmployee;

/// <summary>
/// 员工
/// </summary>
public class OrganEmployeeBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


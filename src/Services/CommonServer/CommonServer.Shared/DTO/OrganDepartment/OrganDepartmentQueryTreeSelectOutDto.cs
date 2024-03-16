namespace CommonServer.Shared.DTO.OrganDepartment;

/// <summary>
/// 部门
/// </summary>
public class OrganDepartmentQueryTreeSelectOutDto
{
    /// <summary>
    /// 标识
    /// </summary>
    [JsonProperty("value")]
    public Guid Id { get; set; }
    /// <summary>
    /// 名称
    /// </summary>
    [JsonProperty("label")]
    public string Name { get; set; } = null!;
    /// <summary>
    /// 子集合
    /// </summary>
    public IList<OrganDepartmentQueryTreeSelectOutDto>? Children { get; set; }
}


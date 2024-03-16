namespace CommonServer.Shared.DTO.OrganDepartment;

/// <summary>
/// 部门
/// </summary>
public class AppResourceQueryTreeSelectOutDto
{
    /// <summary>
    /// 标识
    /// </summary>
    [JsonProperty("value")]
    public Guid Id { get; set; }
    /// <summary>
    /// 标题
    /// </summary>
    [JsonProperty("label")]
    public string Title { get; set; } = null!;
    /// <summary>
    /// 子集合
    /// </summary>
    public IList<AppResourceQueryTreeSelectOutDto>? Children { get; set; }
}


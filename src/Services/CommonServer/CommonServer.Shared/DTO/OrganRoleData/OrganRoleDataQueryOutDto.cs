namespace CommonServer.Shared.DTO.OrganRoleData;

/// <summary>
/// 角色数据
/// </summary>
public class OrganRoleDataQueryOutDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 角色标识
    /// </summary>
    public Guid RoleId { get; set; }
    /// <summary>
    /// 数据标识
    /// </summary>
    public Guid? DataId { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public System.DateTimeOffset CreateTime { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public System.DateTimeOffset LastModifyTime { get; set; }
}


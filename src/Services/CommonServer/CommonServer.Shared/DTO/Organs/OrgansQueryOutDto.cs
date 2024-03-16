namespace CommonServer.Shared.DTO.Organs;

/// <summary>
/// 机构
/// </summary>
public class OrgansQueryOutDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 编号
    /// </summary>
    public string Code { get; set; } = null!;
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 简称
    /// </summary>
    public string? ShortName { get; set; }
    /// <summary>
    /// 联系地址
    /// </summary>
    public string? Address { get; set; }
    /// <summary>
    /// 邮政编码
    /// </summary>
    public string? ZipCode { get; set; }
    /// <summary>
    /// 联系电话
    /// </summary>
    public string? Tel { get; set; }
    /// <summary>
    /// 电子邮箱
    /// </summary>
    public string? Email { get; set; }
    /// <summary>
    /// 联系人
    /// </summary>
    public string? ContactPerson { get; set; }
    /// <summary>
    /// 联系人电话
    /// </summary>
    public string? ContactPersonTel { get; set; }
    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }
    /// <summary>
    /// 是否启用
    /// </summary>
    public bool EnabledFlag { get; set; }
    /// <summary>
    /// 排序号
    /// </summary>
    public int SortNo { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public System.DateTimeOffset CreateTime { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public System.DateTimeOffset LastModifyTime { get; set; }
}


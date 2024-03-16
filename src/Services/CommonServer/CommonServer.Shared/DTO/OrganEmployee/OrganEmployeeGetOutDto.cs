namespace CommonServer.Shared.DTO.OrganEmployee;

/// <summary>
/// 员工
/// </summary>
public class OrganEmployeeGetOutDto : DtoBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 部门标识
    /// </summary>
    public Guid DepartmentId { get; set; }
    /// <summary>
    /// 用户标识
    /// </summary>
    public string UserId { get; set; } = null!;
    /// <summary>
    /// 编号
    /// </summary>
    public string Code { get; set; } = null!;
    /// <summary>
    /// 姓名
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 昵称
    /// </summary>
    public string? NickName { get; set; }
    /// <summary>
    /// 联系电话
    /// </summary>
    public string? Tel { get; set; }
    /// <summary>
    /// 电子邮箱
    /// </summary>
    public string? Email { get; set; }
    /// <summary>
    /// 性别
    /// </summary>
    public int Gender { get; set; }
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
}


namespace IdentityServerPlus.Shared.DTO.AppAuditLog;

/// <summary>
/// 审计日志
/// </summary>
public class AppAuditLogBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


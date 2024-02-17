namespace IdentityServerPlus.API.Options;

/// <summary>
/// 枚举设置
/// </summary>
public class EnumConfiguration
{
    public string ApiName { get; set; } = null!;

    public string ApiVersion { get; set; } = null!;

    public string IdentityServerBaseUrl { get; set; } = null!;

    public string ApiBaseUrl { get; set; } = null!;

    public string OidcSwaggerUIClientId { get; set; } = null!;

    public bool RequireHttpsMetadata { get; set; }

    public string OidcApiName { get; set; } = null!;

    public string AdministrationRole { get; set; } = null!;

    public bool CorsAllowAnyOrigin { get; set; }

    public string[]? CorsAllowOrigins { get; set; }
}

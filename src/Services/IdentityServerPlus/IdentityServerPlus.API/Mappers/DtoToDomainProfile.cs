using IdentityServerPlus.Shared.DTO.AppAuditLog;
using IdentityServerPlus.Shared.DTO.AppData;
using IdentityServerPlus.Shared.DTO.AppFunction;
using IdentityServerPlus.Shared.DTO.AppOperationLog;
using IdentityServerPlus.Shared.DTO.AppResource;
using IdentityServerPlus.Shared.DTO.Apps;
using IdentityServerPlus.Shared.DTO.OrganDepartment;
using IdentityServerPlus.Shared.DTO.OrganEmployee;
using IdentityServerPlus.Shared.DTO.OrganRole;
using IdentityServerPlus.Shared.DTO.OrganRoleData;
using IdentityServerPlus.Shared.DTO.OrganRoleFunction;
using IdentityServerPlus.Shared.DTO.OrganRoleResource;
using IdentityServerPlus.Shared.DTO.Organs;
using IdentityServerPlus.Shared.DTO.OrganUser;
using IdentityServerPlus.Shared.DTO.OrganUserRole;

namespace IdentityServerPlus.API.Mappers;

/// <summary>
/// 
/// </summary>
public class DtoToDomainProfile : Profile
{
    /// <summary>
    /// 
    /// </summary>
    public DtoToDomainProfile()
    {
        #region Apps
        CreateMap<AppsCreateInDto, Apps>();
        CreateMap<AppsUpdateInDto, Apps>();
        CreateMap<Apps, AppsQueryOutDto>();
        CreateMap<Apps, AppsGetOutDto>();
        #endregion

        #region AppResource
        CreateMap<AppResourceCreateInDto, AppResource>();
        CreateMap<AppResourceUpdateInDto, AppResource>();
        CreateMap<AppResource, AppResourceQueryOutDto>();
        CreateMap<AppResource, AppResourceQueryTreeSelectOutDto>();
        CreateMap<AppResource, AppResourceGetOutDto>();
        #endregion

        #region AppFunction
        CreateMap<AppFunctionCreateInDto, AppFunction>();
        CreateMap<AppFunctionUpdateInDto, AppFunction>();
        CreateMap<AppFunction, AppFunctionQueryOutDto>();
        CreateMap<AppFunction, AppFunctionGetOutDto>();
        #endregion

        #region AppData
        CreateMap<AppsDataCreateInDto, AppData>();
        CreateMap<AppDataUpdateInDto, AppData>();
        CreateMap<AppData, AppDataQueryOutDto>();
        CreateMap<AppData, AppDataGetOutDto>();
        #endregion

        #region AppAuditLog
        CreateMap<AppAuditLogCreateInDto, AppAuditLog>();
        CreateMap<AppAuditLogUpdateInDto, AppAuditLog>();
        CreateMap<AppAuditLog, AppAuditLogQueryOutDto>();
        CreateMap<AppAuditLog, AppAuditLogGetOutDto>();
        #endregion

        #region AppOperationLog
        CreateMap<AppOperationLogCreateInDto, AppOperationLog>();
        CreateMap<AppOperationLogUpdateInDto, AppOperationLog>();
        CreateMap<AppOperationLog, AppOperationLogQueryOutDto>();
        CreateMap<AppOperationLog, AppOperationLogGetOutDto>();
        #endregion

        #region Organs
        CreateMap<OrgansCreateInDto, Organs>();
        CreateMap<OrgansUpdateInDto, Organs>();
        CreateMap<Organs, OrgansQueryOutDto>();
        CreateMap<Organs, OrgansGetOutDto>();
        #endregion

        #region OrganUser
        CreateMap<OrganUserCreateInDto, OrganUser>();
        CreateMap<OrganUserUpdateInDto, OrganUser>();
        CreateMap<OrganUser, OrganUserQueryOutDto>();
        CreateMap<OrganUser, OrganUserGetOutDto>();
        #endregion

        #region OrganUserRole
        CreateMap<OrganUserRoleCreateInDto, OrganUserRole>();
        CreateMap<OrganUserRoleUpdateInDto, OrganUserRole>();
        CreateMap<OrganUserRole, OrganUserRoleQueryOutDto>();
        CreateMap<OrganUserRole, OrganUserRoleGetOutDto>();
        #endregion

        #region OrganRole
        CreateMap<OrganRoleCreateInDto, OrganRole>();
        CreateMap<OrganRoleUpdateInDto, OrganRole>();
        CreateMap<OrganRole, OrganRoleQueryOutDto>();
        CreateMap<OrganRole, OrganRoleGetOutDto>();
        #endregion

        #region OrganRoleResource
        CreateMap<OrganRoleResourceCreateInDto, OrganRoleResource>();
        CreateMap<OrganRoleResourceUpdateInDto, OrganRoleResource>();
        CreateMap<OrganRoleResource, OrganRoleResourceQueryOutDto>();
        CreateMap<OrganRoleResource, OrganRoleResourceGetOutDto>();
        #endregion

        #region OrganRoleFunction
        CreateMap<OrganRoleFunctionCreateInDto, OrganRoleFunction>();
        CreateMap<OrganRoleFunctionUpdateInDto, OrganRoleFunction>();
        CreateMap<OrganRoleFunction, OrganRoleFunctionQueryOutDto>();
        CreateMap<OrganRoleFunction, OrganRoleFunctionGetOutDto>();
        #endregion

        #region OrganRoleData
        CreateMap<OrganRoleDataCreateInDto, OrganRoleData>();
        CreateMap<OrganRoleDataUpdateInDto, OrganRoleData>();
        CreateMap<OrganRoleData, OrganRoleDataQueryOutDto>();
        CreateMap<OrganRoleData, OrganRoleDataGetOutDto>();
        #endregion

        #region OrganDepartment
        CreateMap<OrganDepartmentCreateInDto, OrganDepartment>();
        CreateMap<OrganDepartmentUpdateInDto, OrganDepartment>();
        CreateMap<OrganDepartment, OrganDepartmentQueryOutDto>();
        CreateMap<OrganDepartment, OrganDepartmentQueryTreeSelectOutDto>();
        CreateMap<OrganDepartment, OrganDepartmentGetOutDto>();
        #endregion

        #region OrganEmployee
        CreateMap<OrganEmployeeCreateInDto, OrganEmployee>();
        CreateMap<OrganEmployeeUpdateInDto, OrganEmployee>();
        CreateMap<OrganEmployee, OrganEmployeeQueryOutDto>();
        CreateMap<OrganEmployee, OrganEmployeeGetOutDto>();
        #endregion
    }
}
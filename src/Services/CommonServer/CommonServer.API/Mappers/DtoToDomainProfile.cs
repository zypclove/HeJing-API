using CommonServer.Shared.DTO.AppData;
using CommonServer.Shared.DTO.AppFunction;
using CommonServer.Shared.DTO.AppOperationLog;
using CommonServer.Shared.DTO.AppResource;
using CommonServer.Shared.DTO.Apps;
using CommonServer.Shared.DTO.OrganDepartment;
using CommonServer.Shared.DTO.OrganEmployee;
using CommonServer.Shared.DTO.OrganRole;
using CommonServer.Shared.DTO.OrganRoleData;
using CommonServer.Shared.DTO.OrganRoleFunction;
using CommonServer.Shared.DTO.OrganRoleResource;
using CommonServer.Shared.DTO.Organs;
using CommonServer.Shared.DTO.OrganEmployeeRole;

namespace CommonServer.API.Mappers;

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

        #region OrganEmployeeRole
        CreateMap<OrganEmployeeRoleCreateInDto, OrganEmployeeRole>();
        CreateMap<OrganEmployeeRoleUpdateInDto, OrganEmployeeRole>();
        CreateMap<OrganEmployeeRole, OrganEmployeeRoleQueryOutDto>();
        CreateMap<OrganEmployeeRole, OrganEmployeeRoleGetOutDto>();
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
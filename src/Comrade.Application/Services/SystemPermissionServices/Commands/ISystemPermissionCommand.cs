using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Services.SystemPermissionServices.Dtos;

namespace Comrade.Application.Services.SystemPermissionServices.Commands;

public interface ISystemPermissionCommand
{
    Task<ISingleResultDto<EntityDto>> Create(SystemPermissionCreateDto dto);
    Task<ISingleResultDto<EntityDto>> Edit(SystemPermissionEditDto dto);
    Task<ISingleResultDto<EntityDto>> Delete(Guid id);
}
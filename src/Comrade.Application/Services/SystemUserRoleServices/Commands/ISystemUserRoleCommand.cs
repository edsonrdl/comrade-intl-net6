using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Services.SystemUserRoleServices.Dtos;

namespace Comrade.Application.Services.SystemUserRoleServices.Commands;

public interface ISystemUserRoleCommand
{
    Task<ISingleResultDto<EntityDto>> Create(SystemUserRoleCreateDto dto);
    Task<ISingleResultDto<EntityDto>> Edit(SystemUserRoleEditDto dto);
    Task<ISingleResultDto<EntityDto>> Delete(Guid id);
}
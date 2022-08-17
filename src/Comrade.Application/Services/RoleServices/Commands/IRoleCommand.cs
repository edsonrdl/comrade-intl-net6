using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Services.RoleServices.Dtos;

namespace Comrade.Application.Services.RoleServices.Commands;

public interface IRoleCommand
{
    Task<ISingleResultDto<EntityDto>> Create(RoleCreateDto dto);
    Task<ISingleResultDto<EntityDto>> Edit(RoleEditDto dto);
    Task<ISingleResultDto<EntityDto>> Delete(Guid id);
}
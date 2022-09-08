using Comrade.Application.Bases;
using Comrade.Application.Services.RoleServices.Dtos;
using MediatR;

namespace Comrade.Application.Services.SystemPermissionServices.Dtos;

public class SystemPermissionCreateDto : SystemPermissionDto, IRequest<SingleResultDto<EntityDto>>
{
}
using Comrade.Application.Bases;
using MediatR;

namespace Comrade.Application.Services.SystemPermissionServices.Dtos;

public class SystemPermissionDeleteDto : SystemPermissionDto, IRequest<SingleResultDto<EntityDto>>
{
}
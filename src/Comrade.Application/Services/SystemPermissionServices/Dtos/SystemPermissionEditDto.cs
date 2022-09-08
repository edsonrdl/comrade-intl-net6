using Comrade.Application.Bases;
using MediatR;

namespace Comrade.Application.Services.SystemPermissionServices.Dtos;

public class SystemPermissionEditDto : SystemPermissionDto, IRequest<SingleResultDto<EntityDto>>
{
}
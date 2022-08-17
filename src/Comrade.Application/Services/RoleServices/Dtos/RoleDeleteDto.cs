using Comrade.Application.Bases;
using MediatR;

namespace Comrade.Application.Services.RoleServices.Dtos;

public class RoleDeleteDto : RoleDto, IRequest<SingleResultDto<EntityDto>>
{
}
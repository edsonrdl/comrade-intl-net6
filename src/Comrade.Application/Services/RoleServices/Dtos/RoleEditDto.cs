using Comrade.Application.Bases;
using MediatR;

namespace Comrade.Application.Services.RoleServices.Dtos;

public class RoleEditDto : RoleDto, IRequest<SingleResultDto<EntityDto>>
{
}
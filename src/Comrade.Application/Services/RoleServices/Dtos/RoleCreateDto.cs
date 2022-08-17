using Comrade.Application.Bases;
using MediatR;

namespace Comrade.Application.Services.RoleServices.Dtos;

public class RoleCreateDto : RoleDto, IRequest<SingleResultDto<EntityDto>>
{
}
﻿using Comrade.Application.Bases;
using Comrade.Application.Services.RoleServices.Dtos;
using MediatR;

namespace Comrade.Application.Services.SystemUserRoleServices.Dtos;

public class SystemUserRoleEditDto : SystemUserRoleDto, IRequest<SingleResultDto<EntityDto>>
{
}
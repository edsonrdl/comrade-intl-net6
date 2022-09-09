﻿using Comrade.Application.Bases;
using MediatR;

namespace Comrade.Application.Services.SystemPermissionServices.Dtos;

public class SystemPermissionCreateDto : SystemPermissionDto, IRequest<SingleResultDto<EntityDto>>
{
}
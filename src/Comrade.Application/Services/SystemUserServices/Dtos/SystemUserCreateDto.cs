﻿using Comrade.Application.Bases;
using MediatR;

namespace Comrade.Application.Services.SystemUserServices.Dtos;

public class SystemUserCreateDto : SystemUserDto, IRequest<SingleResultDto<EntityDto>>
{
}
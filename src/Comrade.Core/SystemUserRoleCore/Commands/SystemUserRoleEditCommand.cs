﻿using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using MediatR;

namespace Comrade.Core.SystemUserRoleCore.Commands;

public class SystemUserRoleEditCommand : SystemUserRole, IRequest<ISingleResult<Entity>>
{
}
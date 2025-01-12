﻿using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.SystemMenuCore.Validations;

public interface ISystemMenuEditValidation
{
    Task<ISingleResult<Entity>> Execute(SystemMenu entity, SystemMenu? recordExists);
}
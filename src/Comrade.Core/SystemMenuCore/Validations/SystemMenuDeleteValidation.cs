﻿using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.SystemMenuCore.Validations;

public class SystemMenuDeleteValidation
{
    public Task<ISingleResult<Entity>> Execute(SystemMenu entity)
    {
        return null;
    }
}
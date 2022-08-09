﻿using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.FinancialInformationCore.Validations;

public class FinancialInformationEditValidation
{
    private readonly FinancialInformationValueByTypeValidation _financialInformationValueByTypeValidation;

    public FinancialInformationEditValidation(FinancialInformationValueByTypeValidation financialInformationValueByTypeValidation)
    {
        _financialInformationValueByTypeValidation = financialInformationValueByTypeValidation;
    }
    public ISingleResult<Entity> Execute(FinancialInformation entity)
    {
        var valueByTypeValidation = _financialInformationValueByTypeValidation.Execute(entity);
        if (!valueByTypeValidation.Success)
        {
            return valueByTypeValidation;
        }
        return new SingleResult<Entity>(entity);
    }
}
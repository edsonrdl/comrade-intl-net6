using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.FinancialInformationCore.Validations;

public class FinancialInformationForgotPasswordValidation
{
    private readonly FinancialInformationEditValidation _financialInformationEditValidation;

    public FinancialInformationForgotPasswordValidation(FinancialInformationEditValidation financialInformationEditValidation)
    {
        _financialInformationEditValidation = financialInformationEditValidation;
    }

    public ISingleResult<Entity> Execute(FinancialInformation entity)
    {
        var financialInformationEditValidationResult =
            _financialInformationEditValidation.Execute(entity);
        if (!financialInformationEditValidationResult.Success)
        {
            return financialInformationEditValidationResult;
        }

        return new SingleResult<Entity>(entity);
    }
}
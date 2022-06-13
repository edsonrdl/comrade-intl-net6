using Comrade.Application.Services.FinancialInformationServices.Dtos;

namespace Comrade.Application.Services.FinancialInformationServices.Validations;

public class FinancialInformationCreateValidation : FinancialInformationValidation<FinancialInformationCreateDto>
{
    public FinancialInformationCreateValidation()
    {
        ValidateName();
        ValidateEmail();
        PasswordValidation();
        ValidateRegistration();
    }
}
using Comrade.Application.Services.FinancialInformationServices.Dtos;

namespace Comrade.Application.Services.FinancialInformationServices.Validations;

public class FinancialInformationCreateValidation : FinancialInformationValidation<FinancialInformationCreateDto>
{
    public FinancialInformationCreateValidation()
    {
        ValidateType();
        ValidateDateTime();
        ValidateValue();
        ValidateCpf();
        ValidateCard();
        ValidateShop();
        ValidateStore();
   
    }
}
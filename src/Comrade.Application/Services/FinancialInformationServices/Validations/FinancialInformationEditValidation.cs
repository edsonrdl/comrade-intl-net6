﻿using Comrade.Application.Services.FinancialInformationServices.Dtos;

namespace Comrade.Application.Services.FinancialInformationServices.Validations;

public class FinancialInformationEditValidation : FinancialInformationValidation<FinancialInformationEditDto>
{
    public FinancialInformationEditValidation()
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
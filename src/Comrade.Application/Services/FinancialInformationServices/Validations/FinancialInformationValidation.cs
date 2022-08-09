using Comrade.Application.Bases;
using Comrade.Application.Messages;
using Comrade.Application.Services.FinancialInformationServices.Dtos;
using FluentValidation;

namespace Comrade.Application.Services.FinancialInformationServices.Validations;

public class FinancialInformationValidation<TDto> : DtoValidation<TDto>
    where TDto : FinancialInformationDto
{
    protected void ValidateType()
    {
        RuleFor(v => v.Type)
            .NotNull().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
            .WithName("Type");
    }
    protected void ValidateDateTime()
    {
        RuleFor(v => v.DateTime)
            .NotNull().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
            .WithName("DateTime");
    }
    protected void ValidateValue()
    {
        RuleFor(v => v.Value)
            .NotEmpty().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
            .WithName("Value");
    }
    protected void ValidateCpf()
    {
        RuleFor(v => v.Cpf)
            .NotEmpty().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
            .Length(11).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .WithName("Cpf");
    }
    protected void ValidateCard()
    {
        RuleFor(v => v.Card)
            .NotEmpty().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
            .Length(12).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .WithName("Card");
    }
    protected void ValidateShop()
    {
        RuleFor(v => v.Shop)
            .NotEmpty().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
            .MaximumLength(14).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .WithName("Shop");
    }
    protected void ValidateStore()
    {
        RuleFor(v => v.Store)
            .NotEmpty().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
            .MaximumLength(19).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .WithName("Store");
    }


}
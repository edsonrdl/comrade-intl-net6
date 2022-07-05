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
            .NotEmpty().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
            .MaximumLength(1).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .WithName("Type");
    }

    protected void ValidateDate()
    {
        RuleFor(v => v.Date)
            .MaximumLength(8).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .WithName("Date");
    }

    protected void ValidateValue()
    {
        RuleFor(v => v.Value)
            .NotEmpty().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
            .MinimumLength(01).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .MaximumLength(10).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .WithName("Value");
    }


    protected void ValidateCpf()
    {
        RuleFor(v => v.Cpf)
            .NotEmpty().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
            .MaximumLength(11).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .WithName("Cpf");
    }
    protected void ValidateCard()
    {
        RuleFor(v => v.Card)
            .NotEmpty().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
            .MaximumLength(12).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .WithName("Card");
    }


    protected void ValidateHour()
    {
        RuleFor(v => v.Hour)
            .NotEmpty().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
            .MaximumLength(6).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .WithName("Hour");
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
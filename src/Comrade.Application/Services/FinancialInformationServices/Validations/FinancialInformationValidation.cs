﻿using Comrade.Application.Bases;
using Comrade.Application.Messages;
using Comrade.Application.Services.FinancialInformationServices.Dtos;
using FluentValidation;

namespace Comrade.Application.Services.FinancialInformationServices.Validations;

public class FinancialInformationValidation<TDto> : DtoValidation<TDto>
    where TDto : FinancialInformationDto
{
    protected void ValidateName()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
            .MaximumLength(255).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .WithName("Name");
    }

    protected void ValidateEmail()
    {
        RuleFor(v => v.Email)
            .MaximumLength(255).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .WithName("Email");
    }

    protected void PasswordValidation()
    {
        RuleFor(v => v.Password)
            .NotEmpty().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
            .MinimumLength(4).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .MaximumLength(127).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .WithName("Password");
    }


    protected void ValidateRegistration()
    {
        RuleFor(v => v.Registration)
            .NotEmpty().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
            .MaximumLength(255).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .WithName("Registration");
    }
}
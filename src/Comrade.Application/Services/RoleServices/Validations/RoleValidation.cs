using Comrade.Application.Bases;
using Comrade.Application.Messages;
using Comrade.Application.Services.RoleServices.Dtos;
using FluentValidation;

namespace Comrade.Application.Services.RoleServices.Validations;

public class RoleValidation<TDto> : DtoValidation<TDto>
    where TDto : RoleDto
{
    protected void ValidateName()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
            .MaximumLength(255).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .WithName("Name");
    }

}
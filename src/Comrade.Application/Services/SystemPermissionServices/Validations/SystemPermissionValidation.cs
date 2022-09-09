using Comrade.Application.Bases;
using Comrade.Application.Messages;
using Comrade.Application.Services.SystemPermissionServices.Dtos;
using FluentValidation;

namespace Comrade.Application.Services.SystemPermissionServices.Validations;


public class SystemPermissionValidation<TDto> : DtoValidation<TDto>
    where TDto : SystemPermissionDto
{

    protected void ValidateTag()
    {
        RuleFor(v => v.Tag)
            .NotEmpty().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
            .MaximumLength(255).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .WithName("Tag");
    }
    protected void ValidateName()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
            .MaximumLength(255).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .WithName("Name");
    }

}
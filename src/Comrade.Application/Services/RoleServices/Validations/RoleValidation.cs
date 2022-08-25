using Comrade.Application.Bases;
using Comrade.Application.Messages;
using Comrade.Application.Services.RoleServices.Dtos;
using DocumentFormat.OpenXml.Office2016.Drawing.Command;
using DocumentFormat.OpenXml.Wordprocessing;
using FluentValidation;

namespace Comrade.Application.Services.RoleServices.Validations;


public class RoleValidation<TDto> : DtoValidation<TDto>
    where TDto : RoleDto
{

    protected void ValidateName()
    {
        RuleFor(v => v.Name)
            .NotEqual("")
            .NotEmpty().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
            .MaximumLength(255).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .WithName("Name");
            
    }
    
}
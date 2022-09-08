using Comrade.Application.Bases;
using Comrade.Application.Services.SystemPermissionServices.Dtos;
namespace Comrade.Application.Services.SystemPermissionServices.Validations;


public class SystemPermissionValidation<TDto> : DtoValidation<TDto>
    where TDto : SystemPermissionDto
{

}
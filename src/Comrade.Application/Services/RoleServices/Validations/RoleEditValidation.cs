using Comrade.Application.Services.RoleServices.Dtos;

namespace Comrade.Application.Services.RoleServices.Validations;

public class RoleEditValidation : RoleValidation<RoleEditDto>
{
    public RoleEditValidation()
    {
        ValidateName();
        
    }
}
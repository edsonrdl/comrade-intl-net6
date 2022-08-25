using Comrade.Application.Services.RoleServices.Dtos;

namespace Comrade.Application.Services.RoleServices.Validations;

public class RoleCreateValidation : RoleValidation<RoleCreateDto>
{
    public RoleCreateValidation()
    {
        ValidateName();

    }
}
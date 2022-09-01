using Comrade.Application.Bases;

namespace Comrade.Application.Services.SystemUserRoleServices.Dtos;

public class SystemUserRoleDto : EntityDto
{
    
    public Guid SystemUserId { get; set; }

    public Guid RoleId { get; set; }
   
}
using Comrade.Domain.Bases;

namespace Comrade.Domain.Models;

[Table("syus_system_user_syro_role")]
public class SystemUserRole : Entity
{
    public SystemUserRole()
    {

    }
    
    public SystemUserRole(Guid systemUserId,Guid roleId)
    {
        SystemUserId = systemUserId;
        RoleId = roleId;
        
    }

    [Column("syus_uuid_system_user")]
    [Required(ErrorMessage = "system User Id is required")]
    public Guid SystemUserId { get; set; }

    [Column("syro_uuid_role")]
    [Required(ErrorMessage = "Role  Id is required")]
    public Guid RoleId { get; set; }

}
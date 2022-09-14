using Comrade.Domain.Bases;
using System.Data;

namespace Comrade.Domain.Models;

[Table("sype_system_permission")]
public class SystemPermission : Entity
{
    public SystemPermission()
    {
        Name = "";
        Tag = "";
        SystemUsers = new HashSet<SystemUser>();
        Roles = new HashSet<Role>();
    }
    
    public SystemPermission(string name,string tag)
    {
        Name = name;
        Tag = tag;
        SystemUsers = new HashSet<SystemUser>();
        Roles = new HashSet<Role>();
    }

    [Column("sype_tx_name", TypeName = "varchar")]
    [MaxLength(255)]
    [Required(ErrorMessage = "name is required")]
    public string Name { get; set; } 

    [Column("sype_tx_tag", TypeName = "varchar")]
    [MaxLength(255)]
    [Required(ErrorMessage = "tag is required")]
    public string Tag { get; set; }
    public virtual ICollection<SystemUser> SystemUsers { get; set; }
    public virtual ICollection<Role> Roles { get; set; }

}
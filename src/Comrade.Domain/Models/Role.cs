using Comrade.Domain.Bases;
using System.Data;

namespace Comrade.Domain.Models;

[Table("syro_system_role")]
public class Role : Entity
{
    public Role()
    {
        Name = "";
        SystemUsers = new HashSet<SystemUser>();

    }

    public Role(string name)
    {
        Name = name;
        SystemUsers = new HashSet<SystemUser>();

    }

    [Column("syro_tx_name", TypeName = "varchar")]
    [MaxLength(255)]
    [Required(ErrorMessage = "name is required")]
    public string Name { get; set; }
    public virtual ICollection<SystemUser> SystemUsers { get; set; }


}
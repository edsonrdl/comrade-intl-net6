using Comrade.Domain.Bases;

namespace Comrade.Domain.Models;

[Table("syro_system_role")]
public class Role : Entity
{
    public Role()
    {
        Name = "";
        
    }

    public Role(string name)
    {
        Name = name;
        
    }

    [Column("syro_tx_name", TypeName = "varchar")]
    [MaxLength(255)]
    [Required(ErrorMessage = "name is required")]
    public string Name { get; set; }

    
}
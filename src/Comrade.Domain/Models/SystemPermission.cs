using Comrade.Domain.Bases;
namespace Comrade.Domain.Models;

[Table("sype_system_permission")]
public class SystemPermission : Entity
{
    public SystemPermission()
    {
        Name = "";
        Tag = "";
    }
    
    public SystemPermission(string name,string tag)
    {
        Name = name;
        Tag = tag;

    }

    [Column("sype_tx_system_permission", TypeName = "varchar")]
    [MaxLength(255)]
    public string Name { get; set; } = null !;

    [Column("sype_tx_system_permission", TypeName = "varchar")]
    [MaxLength(255)]
    public string Tag { get; set; } = null!;

}
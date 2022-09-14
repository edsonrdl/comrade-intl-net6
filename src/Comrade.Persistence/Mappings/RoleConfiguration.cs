using Comrade.Domain.Models;

namespace Comrade.Persistence.Mappings;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(b => b.Id).HasColumnName("syro_uuid_role").IsRequired();
        builder.HasKey(c => c.Id).HasName("pk_syro_role");
        builder.HasMany(x => x.SystemUsers)
            .WithMany(x => x.Roles)
            .UsingEntity(j => j.ToTable("syus_system_user_syro_role"));
        builder.HasMany(x => x.SystemPermissions)
            .WithMany(x => x.Roles)
            .UsingEntity(j => j.ToTable("sype_system_permission_user_syro_role"));
    }
}
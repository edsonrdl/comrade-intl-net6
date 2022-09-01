using Comrade.Domain.Models;

namespace Comrade.Persistence.Mappings;

public class SystemUserRoleConfiguration : IEntityTypeConfiguration<SystemUserRole>
{
    public void Configure(EntityTypeBuilder<SystemUserRole> builder)
    {
        builder.Property(b => b.Id).HasColumnName("syus_uuid_system_user_syro_role").IsRequired();
        builder.HasKey(c => c.Id).HasName("pk_syus_system_user_syro_role");

    }
}
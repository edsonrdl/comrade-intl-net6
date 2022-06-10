using Comrade.Domain.Models;

namespace Comrade.Persistence.Mappings;

public class FinancialInformationConfiguration : IEntityTypeConfiguration<FinancialInformation>
{
    public void Configure(EntityTypeBuilder<FinancialInformation> builder)
    {
        builder.Property(b => b.Id).HasColumnName("syus_uuid_financial_information").IsRequired();
        builder.HasKey(c => c.Id).HasName("pk_syus_financial_information");

        builder.HasIndex(c => c.Email).HasDatabaseName("ix_un_syus_tx_email").IsUnique();
        builder.HasIndex(c => c.Registration).HasDatabaseName("ix_un_syus_tx_registration")
            .IsUnique();
    }
}
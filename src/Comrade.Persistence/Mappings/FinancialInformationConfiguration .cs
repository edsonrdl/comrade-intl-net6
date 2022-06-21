using Comrade.Domain.Models;

namespace Comrade.Persistence.Mappings;

public class FinancialInformationConfiguration : IEntityTypeConfiguration<FinancialInformation>
{
    public void Configure(EntityTypeBuilder<FinancialInformation> builder)
    {
        builder.Property(b => b.Id).HasColumnName("fiin_uuid_financial_information").IsRequired();
        builder.HasKey(c => c.Id).HasName("pk_fiin_financial_information");

      
    }
}
using BankingApp.CreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingApp.CreditSystem.Persistence.EntityConfigurations;

public class CorporateCustomerEntityConfiguration : IEntityTypeConfiguration<CorporateCustomer>
{
    public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
    {
        builder.Property(cc => cc.CompanyName)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(cc => cc.TaxNumber)
            .IsRequired()
            .HasMaxLength(10)
            .IsFixedLength();

        builder.Property(cc => cc.TaxOffice)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(cc => cc.CompanyRegistrationNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(cc => cc.AuthorizedPersonName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(cc => cc.CompanyFoundationDate)
            .IsRequired()
            .HasColumnType("date");

        builder.HasIndex(cc => cc.TaxNumber)
            .IsUnique()
            .HasDatabaseName("IX_CorporateCustomers_TaxNumber");

        builder.HasIndex(cc => cc.CompanyRegistrationNumber)
            .IsUnique()
            .HasDatabaseName("IX_CorporateCustomers_CompanyRegistrationNumber");

        builder.HasIndex(cc => cc.CompanyName)
            .HasDatabaseName("IX_CorporateCustomers_CompanyName");

        builder.HasIndex(cc => cc.CompanyFoundationDate)
            .HasDatabaseName("IX_CorporateCustomers_CompanyFoundationDate");
    }
} 
using BankingApp.CreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingApp.CreditSystem.Persistence.EntityConfigurations;

public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasDefaultValueSql("NEWID()");

        builder.Property(c => c.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(c => c.Address)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(c => c.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(c => c.CreatedDate)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(c => c.UpdatedDate)
            .IsRequired(false);

        builder.Property(c => c.DeletedDate)
            .IsRequired(false);

        builder.HasIndex(c => c.Email)
            .IsUnique()
            .HasDatabaseName("IX_Customers_Email");

        builder.HasIndex(c => c.PhoneNumber)
            .IsUnique()
            .HasDatabaseName("IX_Customers_PhoneNumber");

        builder.HasIndex(c => c.IsActive)
            .HasDatabaseName("IX_Customers_IsActive");

        builder.HasDiscriminator<string>("CustomerType")
            .HasValue<IndividualCustomer>("Individual")
            .HasValue<CorporateCustomer>("Corporate");
    }
} 
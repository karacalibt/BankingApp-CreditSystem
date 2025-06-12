using BankingApp.CreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingApp.CreditSystem.Persistence.EntityConfigurations;

public class IndividualCustomerEntityConfiguration : IEntityTypeConfiguration<IndividualCustomer>
{
    public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
    {
        builder.Property(ic => ic.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ic => ic.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ic => ic.NationalId)
            .IsRequired()
            .HasMaxLength(11)
            .IsFixedLength();

        builder.Property(ic => ic.DateOfBirth)
            .IsRequired()
            .HasColumnType("date");

        builder.Property(ic => ic.MotherName)
            .HasMaxLength(200);

        builder.Property(ic => ic.FatherName)
            .HasMaxLength(200);

        builder.HasIndex(ic => ic.NationalId)
            .IsUnique()
            .HasDatabaseName("IX_IndividualCustomers_NationalId");

        builder.HasIndex(ic => new { ic.FirstName, ic.LastName })
            .HasDatabaseName("IX_IndividualCustomers_FullName");

        builder.HasIndex(ic => ic.DateOfBirth)
            .HasDatabaseName("IX_IndividualCustomers_DateOfBirth");
    }
} 
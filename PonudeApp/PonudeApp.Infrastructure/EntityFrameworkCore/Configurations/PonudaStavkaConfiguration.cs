using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PonudeApp.Domain.Entities;

namespace PonudeApp.Infrastructure.EntityFrameworkCore.Configurations;

public class PonudaStavkaConfiguration : IEntityTypeConfiguration<PonudaStavka>
{
    public void Configure(EntityTypeBuilder<PonudaStavka> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Artikl)
            .IsRequired()
            .HasMaxLength(32);

        builder.Property(s => s.JedinicnaCijena)
            .IsRequired();

        builder.Property(s => s.Kolicina)
            .IsRequired()
            .HasDefaultValue(1);
    }
}

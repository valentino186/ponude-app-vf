using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PonudeApp.Domain.Entities;

namespace PonudeApp.Infrastructure.EntityFrameworkCore.Configurations;

public class PonudaConfiguration : IEntityTypeConfiguration<Ponuda>
{
    public void Configure(EntityTypeBuilder<Ponuda> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever();

        builder.Property(p => p.BrojPonude)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(p => p.DatumPonude)
            .IsRequired();

        builder.HasMany(p => p.Stavke)
            .WithOne(s => s.Ponuda)
            .HasForeignKey(s => s.PonudaId)
            .IsRequired();
    }
}

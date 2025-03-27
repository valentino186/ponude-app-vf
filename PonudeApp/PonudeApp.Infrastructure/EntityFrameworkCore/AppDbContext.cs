using Microsoft.EntityFrameworkCore;
using PonudeApp.Domain.Entities;
using System.Reflection;

namespace PonudeApp.Infrastructure.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Ponuda> Ponude { get; set; }
    public DbSet<PonudaStavka> PonudaStavke { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

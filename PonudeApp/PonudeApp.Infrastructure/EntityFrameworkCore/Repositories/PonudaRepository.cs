using Microsoft.EntityFrameworkCore;
using PonudeApp.Domain.Entities;
using PonudeApp.Domain.Interfaces;
using PonudeApp.Infrastructure.EntityFrameworkCore.Repositories.Common;

namespace PonudeApp.Infrastructure.EntityFrameworkCore.Repositories;

public class PonudaRepository : Repository<Ponuda>, IPonudaRepository
{
    public PonudaRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<int> NextBrojPonudeAsync()
    {
        return await _context.Ponude.AnyAsync() 
            ? await _context.Ponude.MaxAsync(it => it.BrojPonude) + 1
            : 1;
    }
}

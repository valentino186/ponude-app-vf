using PonudeApp.Domain.Entities;

namespace PonudeApp.Domain.Interfaces;

public interface IPonudaRepository : IRepository<Ponuda>
{
    Task<int> NextBrojPonudeAsync();
}

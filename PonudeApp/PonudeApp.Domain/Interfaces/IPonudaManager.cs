using PonudeApp.Domain.Entities;

namespace PonudeApp.Domain.Interfaces;

public interface IPonudaManager
{
    Task<Ponuda> CreatePonuda(int brojPonude, DateTime datumPonude, List<PonudaStavka> stavke);
}

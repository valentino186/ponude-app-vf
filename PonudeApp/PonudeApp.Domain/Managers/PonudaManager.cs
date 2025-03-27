using PonudeApp.Domain.Entities;
using PonudeApp.Domain.Interfaces;

namespace PonudeApp.Domain.Managers;

public class PonudaManager : IPonudaManager
{
    private readonly IPonudaRepository _ponudaRepository;

    public PonudaManager(IPonudaRepository ponudaRepository)
    {
        _ponudaRepository = ponudaRepository;
    }

    public Task<Ponuda> CreatePonuda(int brojPonude, DateTime datumPonude, List<PonudaStavka> stavke)
    {
        var ponuda = new Ponuda(datumPonude, brojPonude);

        foreach (PonudaStavka ponudaStavka in stavke)
        {
            ponuda.AddStavka(ponudaStavka.Artikl, ponudaStavka.JedinicnaCijena, ponudaStavka.Kolicina);
        }

        _ponudaRepository.Create(ponuda);

        return Task.FromResult(ponuda);
    }
}

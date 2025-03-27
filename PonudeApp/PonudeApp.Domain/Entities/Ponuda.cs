using PonudeApp.Domain.Common;

namespace PonudeApp.Domain.Entities;

public class Ponuda : Entity<Guid>
{
    public int BrojPonude { get; set; }
    public DateTime DatumPonude { get; set; }
    public List<PonudaStavka> Stavke { get; set; } = [];

    public Ponuda(DateTime datumPonude, int brojPonude)
    {
        Id = Guid.NewGuid();
        DatumPonude = datumPonude;
        BrojPonude = brojPonude;
    }

    public Ponuda AddStavka(string artikl, decimal cijena, int kolicina)
    {
        Stavke.Add(new PonudaStavka
        {
            Id = Guid.NewGuid(),
            PonudaId = Id,
            Artikl = artikl,
            JedinicnaCijena = cijena,
            Kolicina = kolicina
        });

        return this;
    }
}

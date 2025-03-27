using PonudeApp.Domain.Common;

namespace PonudeApp.Domain.Entities;

public class PonudaStavka : Entity<Guid>
{
    public string Artikl { get; set; } = string.Empty;
    public decimal JedinicnaCijena { get; set; }
    public int Kolicina { get; set; }

    public Guid PonudaId { get; set; }
    public Ponuda Ponuda { get; set; }

    public decimal UkupnaCijena => JedinicnaCijena * Kolicina;
}

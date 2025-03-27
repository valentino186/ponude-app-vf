using PonudeApp.Domain.Entities;

namespace PonudeApp.Application.Services.Ponuda.CreatePonuda;

public class CreatePonudaRequest
{
    public int BrojPonude { get; set; }
    public DateTime DatumPonude { get; set; }
    public List<PonudaStavka> Stavke { get; set; } = [];
}

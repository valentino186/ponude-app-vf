using PonudeApp.Domain.Entities;

namespace PonudeApp.Application.Common.Responses;

public class PonudaResponse
{
    public Guid Id { get; set; }
    public int BrojPonude { get; set; }
    public DateTime DatumPonude { get; set; }
    public List<PonudaStavka> Stavke { get; set; } = [];
}

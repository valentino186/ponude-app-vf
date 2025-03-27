using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PonudeApp.API.ViewModels;

public class CreatePonudaViewModel
{
    [Required(ErrorMessage = "Broj ponude je obavezan")]
    [Range(1, int.MaxValue, ErrorMessage = "Broj ponude mora biti pozitivan broj")]
    public int BrojPonude { get; set; }

    [Required(ErrorMessage = "Morate dodati barem jednu stavku")]
    [MinLength(1, ErrorMessage = "Morate dodati barem jednu stavku")]
    public List<StavkaPonudeViewModel> Stavke { get; set; } = [];
}

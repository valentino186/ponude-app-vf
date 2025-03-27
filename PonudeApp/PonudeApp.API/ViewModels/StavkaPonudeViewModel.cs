using System.ComponentModel.DataAnnotations;

namespace PonudeApp.API.ViewModels;

public class StavkaPonudeViewModel
{
    [Required(ErrorMessage = "Artikl je obavezan")]
    [StringLength(100, ErrorMessage = "Naziv artikla ne može biti duži od 100 karaktera")]
    public string Artikl { get; set; }

    [Required(ErrorMessage = "Jedinična cijena je obavezna")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Jedinična cijena mora biti pozitivan broj")]
    public decimal JedinicnaCijena { get; set; }

    [Required(ErrorMessage = "Količina je obavezna")]
    [Range(1, int.MaxValue, ErrorMessage = "Količina mora biti pozitivan broj")]
    public int Kolicina { get; set; }
}

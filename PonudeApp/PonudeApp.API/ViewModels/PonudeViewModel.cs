using PonudeApp.Application.Common.Responses;
using PonudeApp.Domain.Entities;

namespace PonudeApp.API.ViewModels;

public class PonudeViewModel
{
    public List<PonudaResponse> Ponude { get; set; } = [];
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}
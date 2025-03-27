using Microsoft.AspNetCore.Mvc;
using PonudeApp.API.ViewModels;
using PonudeApp.Application.Services.Ponuda;
using PonudeApp.Application.Services.Ponuda.CreatePonuda;
using PonudeApp.Domain.Entities;
using PonudeApp.Domain.Interfaces;

namespace PonudeApp.API.Controllers;

public class PonudaController : Controller
{
    private readonly IPonudaService _ponudaService;

    public PonudaController(IPonudaService ponudaService)
    {
        _ponudaService = ponudaService;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 3, CancellationToken cancellationToken = default)
    {
        var ponude = await _ponudaService.GetPonudeAsync(page, pageSize, cancellationToken);

        var viewModel = new PonudeViewModel
        {
            Ponude = ponude,
            CurrentPage = page,
            TotalPages = (int)Math.Ceiling(ponude.Count / (double)pageSize)
        };

        return View(viewModel);
    }

    public async Task<IActionResult> Create()
    {
        var nextBrojPonude = await _ponudaService.NextBrojPonude();

        var model = new CreatePonudaViewModel
        {
            BrojPonude = nextBrojPonude
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePonudaViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new
            {
                errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToList()
                )
            });
        }

        var createPonudaRequest = new CreatePonudaRequest
        {
            BrojPonude = model.BrojPonude,
            DatumPonude = DateTime.UtcNow,
            Stavke = model.Stavke.Select(s => new PonudaStavka
            {
                Artikl = s.Artikl,
                JedinicnaCijena = s.JedinicnaCijena,
                Kolicina = s.Kolicina
            }).ToList()
        };

        await _ponudaService.CreatePonudaAsync(createPonudaRequest);

        return Ok(new { message = "Ponuda uspješno kreirana" });
    }
}

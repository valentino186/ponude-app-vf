using PonudeApp.Application.Common.Responses;
using PonudeApp.Application.Services.Ponuda.CreatePonuda;

namespace PonudeApp.Application.Services.Ponuda;

public interface IPonudaService
{
    Task<List<PonudaResponse>> GetPonudeAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<PonudaResponse> GetPonudaAsync(Guid id, CancellationToken cancellationToken = default);
    Task<PonudaResponse> CreatePonudaAsync(CreatePonudaRequest request);
    Task DeletePonudaAsync(Guid id);
    Task<int> NextBrojPonude();
}

using AutoMapper;
using PonudeApp.Application.Common.Responses;
using PonudeApp.Application.Services.Ponuda.CreatePonuda;
using PonudeApp.Domain.Exceptions;
using PonudeApp.Domain.Interfaces;

namespace PonudeApp.Application.Services.Ponuda;

public class PonudaService : IPonudaService
{
    private readonly IPonudaRepository _ponudaRepository;
    private readonly IPonudaManager _ponudaManager;

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PonudaService(IPonudaRepository ponudaRepository, IMapper mapper, IPonudaManager ponudaManager, IUnitOfWork unitOfWork)
    {
        _ponudaRepository = ponudaRepository;
        _mapper = mapper;
        _ponudaManager = ponudaManager;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<PonudaResponse>> GetPonudeAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var ponude = await  _ponudaRepository.GetPaginationAsync(page, pageSize, cancellationToken);

        return _mapper.Map<List<PonudaResponse>>(ponude);
    }

    public async Task<PonudaResponse> GetPonudaAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var ponuda = await _ponudaRepository.GetAsync(it => it.Id == id, cancellationToken);

        if (ponuda is null)
        {
            throw new EntityNotFoundException();
        }

        return _mapper.Map<PonudaResponse>(ponuda);
    }

    public async Task<PonudaResponse> CreatePonudaAsync(CreatePonudaRequest request)
    {
        var nextBrojPonuda = await _ponudaRepository.NextBrojPonudeAsync();

        var ponuda = await _ponudaManager.CreatePonuda(request.BrojPonude, request.DatumPonude, request.Stavke);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<PonudaResponse>(ponuda);
    }

    public async Task DeletePonudaAsync(Guid id)
    {
        var ponuda = await _ponudaRepository.GetAsync(it => it.Id == id);

        if (ponuda is null)
        {
            throw new EntityNotFoundException();
        }

        _ponudaRepository.Delete(ponuda);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<int> NextBrojPonude()
    {
        return await _ponudaRepository.NextBrojPonudeAsync();
    }
}

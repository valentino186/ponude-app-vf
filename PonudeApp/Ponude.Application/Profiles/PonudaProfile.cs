using AutoMapper;
using PonudeApp.Application.Common.Responses;
using PonudeApp.Domain.Entities;

namespace PonudeApp.Application.Profiles;

public class PonudaProfile : Profile
{
    public PonudaProfile()
    {
        CreateMap<Ponuda, PonudaResponse>();
    }
}

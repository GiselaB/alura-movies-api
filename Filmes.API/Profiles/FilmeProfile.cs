using AutoMapper;
using Filmes.Domain.Models;
using Filmes.Services.Data.Dtos.Filme;

namespace FilmesAPI.Profiles;
public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<Filme, ReadFilmeDto>();
        CreateMap<UpdateFilmeDto, Filme>();
    }
}
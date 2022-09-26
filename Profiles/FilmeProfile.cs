using AutoMapper;
using Filmes.Services.Data.Dtos.Filme;
using FilmesAPI.Models;

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
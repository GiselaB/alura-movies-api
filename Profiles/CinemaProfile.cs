using AutoMapper;
using Filmes.Services.Data.Dtos.Cinema;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;
public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDto>();
        CreateMap<UpdateCinemaDto, Cinema>();
    }
}

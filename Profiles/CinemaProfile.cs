using AutoMapper;
using Filmes.Domain.Models;
using Filmes.Services.Data.Dtos.Cinema;

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

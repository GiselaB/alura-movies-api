using AutoMapper;
using FilmesAPI.Models;
using FilmesAPI.Data.Dtos;

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

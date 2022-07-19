using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;
public class GerenteProfile : Profile
{
    public GerenteProfile()
    {
        CreateMap<CreateGerenteDto, Gerente>();
        CreateMap<Gerente, ReadGerenteDto>();
        CreateMap<UpdateGerenteDto, Gerente>();
    }
}
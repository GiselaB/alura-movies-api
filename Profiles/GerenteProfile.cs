using AutoMapper;
using Filmes.Services.Data.Dtos.Gerente;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;
public class GerenteProfile : Profile
{
    public GerenteProfile()
    {
        CreateMap<CreateGerenteDto, Gerente>();
        CreateMap<Gerente, ReadGerenteDto>()
            .ForMember(gerente => gerente.Cinemas, opts => opts
            .MapFrom(gerente => gerente.Cinemas.Select
            (c => new {c.Id, c.Nome, c.Endereco, c.EnderecoId})));
        CreateMap<UpdateGerenteDto, Gerente>();
    }
}
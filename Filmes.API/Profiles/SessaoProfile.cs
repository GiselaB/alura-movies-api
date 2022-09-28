using AutoMapper;
using Filmes.Domain.Models;
using Filmes.Services.Data.Dtos.Sessao;

namespace FilmesAPI.Profiles;
public class SessaoProfile : Profile
{
    public SessaoProfile()
    {
        CreateMap<CreateSessaoDto, Sessao>();
        CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(dto => dto.HorarioDeInicio, opts => opts
                .MapFrom(dto =>
                dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao * (-1))));
        CreateMap<UpdateSessaoDto, Sessao>();
    }
}
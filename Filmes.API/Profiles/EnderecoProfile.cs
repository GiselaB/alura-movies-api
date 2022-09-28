using AutoMapper;
using Filmes.Domain.Models;
using Filmes.Services.Data.Dtos.Endereco;

namespace FilmesAPI.Profiles;
public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<CreateEnderecoDto, Endereco>();
        CreateMap<Endereco, ReadEnderecoDto>();
        CreateMap<UpdateEnderecoDto, Endereco>();
    }
}
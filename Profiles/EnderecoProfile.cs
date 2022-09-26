using AutoMapper;
using Filmes.Services.Data.Dtos.Endereco;
using FilmesAPI.Models;

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
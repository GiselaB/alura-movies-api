using Filmes.Services.Data.Dtos.Endereco;
using FluentResults;

namespace Filmes.Services.Interfaces;

public interface IEnderecoService
{
    ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto);
    List<ReadEnderecoDto> RecuperaEnderecos();
    ReadEnderecoDto RecuperaEnderecoPorId(int id);
    Result AtualizaEndereco(int id, UpdateEnderecoDto enderecoDto);
    Result DeletaEndereco(int id);
}
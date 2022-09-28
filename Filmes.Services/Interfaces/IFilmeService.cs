using Filmes.Services.Data.Dtos.Filme;
using FluentResults;

namespace Filmes.Services.Interfaces;

public interface IFilmeService
{
    ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto);
    List<ReadFilmeDto> RecuperaFilmes(int? classificacaoEtaria);
    ReadFilmeDto RecuperaFilmePorId(int id);
    Result AtualizaFilme(int id, UpdateFilmeDto filmeDto);
    Result DeletaFilme(int id);
}
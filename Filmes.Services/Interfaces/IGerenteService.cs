using Filmes.Services.Data.Dtos.Gerente;
using FluentResults;

namespace Filmes.Services.Interfaces;

public interface IGerenteService
{
    ReadGerenteDto AdicionaGerente(CreateGerenteDto gerenteDto);
    List<ReadGerenteDto> RecuperaGerentes();
    ReadGerenteDto RecuperaGerentePorId(int id);
    Result AtualizaGerente(int id, UpdateGerenteDto gerenteDto);
    Result DeletaGerente(int id);
}
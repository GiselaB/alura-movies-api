using Filmes.Domain.Models;
using Filmes.Services.Data.Dtos.Sessao;
using FluentResults;

namespace Filmes.Services.Interfaces;

public interface ISessaoService
{
    Sessao AdicionaSessao(CreateSessaoDto sessaoDto);
    List<ReadSessaoDto> RecuperaSessoes();
    ReadSessaoDto RecuperaSessaoPorId(int id);
    Result AtualizaSessao(int id, UpdateSessaoDto sessaoDto);
    Result DeletaSessao(int id);
}
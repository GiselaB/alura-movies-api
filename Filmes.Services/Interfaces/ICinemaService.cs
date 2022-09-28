using Filmes.Services.Data.Dtos.Cinema;
using FluentResults;

namespace Filmes.Services.Interfaces;

public interface ICinemaService
{
    ReadCinemaDto AdicionaCinema(CreateCinemaDto cinemaDto);
    List<ReadCinemaDto> RecuperaCinemas(string nomeDoFilme);
    ReadCinemaDto RecuperaCinemaPorId(int id);
    Result AtualizaCinema(int id, UpdateCinemaDto cinemaDto);
    Result DeletaCinema(int id);
}
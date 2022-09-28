using Filmes.Services.Data.Dtos.Cinema;
using Filmes.Services.Data.Dtos.Filme;

namespace Filmes.Services.Data.Dtos.Sessao;
public class ReadSessaoDto
{
    public int Id { get; set; }
    public ReadCinemaDto Cinema { get; set; }
    public ReadFilmeDto Filme { get; set; }
    public DateTime HorarioDeEncerramento { get; set; }
    public DateTime HorarioDeInicio { get; set; }
}
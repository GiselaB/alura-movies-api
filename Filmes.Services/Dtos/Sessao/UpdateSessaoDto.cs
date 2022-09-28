namespace Filmes.Services.Data.Dtos.Sessao;
public class UpdateSessaoDto
{
    public int CinemaId { get; set; }
    public int FilmeId { get; set; }
    public DateTime HorarioDeEncerramento { get; set; }
}
namespace FilmesAPI.Models;
public class UpdateSessaoDto
{
    public int CinemaId { get; set; }
    public int FilmeId { get; set; }
    public DateTime HorarioDeEncerramento { get; set; }
}
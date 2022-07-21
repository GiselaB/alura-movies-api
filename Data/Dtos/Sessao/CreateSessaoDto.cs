using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;
public class CreateSessaoDto
{
    public int CinemaId { get; set; }
    public int FilmeId { get; set; }
    public DateTime HorarioDeEncerramento { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;
public class ReadSessaoDto
{
    public Cinema Cinema { get; set; }
    public Filme Filme { get; set; }
    public DateTime HorarioDeEncerramento { get; set; }
    public DateTime HorarioDeInicio { get; set; }
}
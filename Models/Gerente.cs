using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;
public class Gerente
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo de nome é obrigatório")]
    public string Nome { get; set; }
    public virtual List<Cinema> Cinemas { get; set; }   
}
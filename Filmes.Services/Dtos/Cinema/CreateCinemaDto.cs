using System.ComponentModel.DataAnnotations;

namespace Filmes.Services.Data.Dtos.Cinema;
public class CreateCinemaDto
{
    [Required(ErrorMessage = "O campo de nome é obrigatório")]
    public string Nome { get; set; }
    public int EnderecoId { get; set; }
    public int GerenteId { get; set; }
}

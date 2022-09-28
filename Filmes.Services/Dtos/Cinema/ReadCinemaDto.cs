using System.ComponentModel.DataAnnotations;
using Filmes.Services.Data.Dtos.Endereco;
using Filmes.Services.Data.Dtos.Gerente;

namespace Filmes.Services.Data.Dtos.Cinema;
public class ReadCinemaDto
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo de nome é obrigatório")]
    public string Nome { get; set; }
    public ReadEnderecoDto Endereco { get; set; }
    public ReadGerenteDto Gerente { get; set; }
}

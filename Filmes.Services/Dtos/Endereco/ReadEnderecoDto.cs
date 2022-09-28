using System.ComponentModel.DataAnnotations;

namespace Filmes.Services.Data.Dtos.Endereco;
public class ReadEnderecoDto
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Logradouro { get; set; }
    public string Bairro { get; set; }
    public int Numero { get; set; }
}
using System.ComponentModel.DataAnnotations;
namespace FilmesAPI.Models;
public class ReadEnderecoDto
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Logradouro { get; set; }
    public string Bairro { get; set; }
    public int Numero { get; set; }
}
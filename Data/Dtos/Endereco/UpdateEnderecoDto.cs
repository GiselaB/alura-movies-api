using System.ComponentModel.DataAnnotations;
namespace FilmesAPI.Models;
public class UpdateEnderecoDto
{
    public string Logradouro { get; set; }
    public string Bairro { get; set; }
    public int Numero { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Filmes.Domain.Models;
public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo de título é obrigatório")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O campo de Diretor é obrigatório")]
    public string Diretor { get; set; }

    [StringLength(30, ErrorMessage = "O gênero não pode ter mais do que 30 caracteres")]
    public string Genero { get; set; }

    [Range(1, 600, ErrorMessage = "A duração deve ter no mínimo 1 minuto e no máximo 600 minutos")]
    public int Duracao { get; set; }
    public int ClassificacaoEtaria { get; set; }
    [JsonIgnore]
    public virtual List<Sessao> Sessoes { get; set; }


}
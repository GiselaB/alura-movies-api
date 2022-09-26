using Filmes.Services.Data.Dtos.Endereco;
using Microsoft.AspNetCore.Mvc;
using FluentResults;
using Filmes.Services.Interfaces;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private readonly IEnderecoService _enderecoService;
    public EnderecoController(IEnderecoService enderecoService)
    {
        _enderecoService = enderecoService;
    }
    [HttpPost]
    public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        var readDto = _enderecoService.AdicionaEndereco(enderecoDto);
        return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = readDto.Id }, readDto);
    }

    [HttpGet]
    public IActionResult RecuperaEnderecos()
    {
        List<ReadEnderecoDto> enderecosDto = _enderecoService.RecuperaEnderecos();
        return Ok(enderecosDto);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaEnderecoPorId(int id)
    {
        ReadEnderecoDto enderecoDto = _enderecoService.RecuperaEnderecoPorId(id);
        if (enderecoDto != null)
            return Ok(enderecoDto);
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
    {
        Result resultado = _enderecoService.AtualizaEndereco(id, enderecoDto);
        if (resultado.IsFailed)
            return NotFound();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeletaEndereco(int id)
    {
        Result resultado = _enderecoService.DeletaEndereco(id);
        if (resultado.IsFailed)
            return NotFound();
        return NoContent();
    }

}

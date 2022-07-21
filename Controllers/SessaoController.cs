using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FilmesAPI.Models;
using FilmesAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SessaoController : ControllerBase
{
    private AppDbContext _context;
    private IMapper _mapper;

    public SessaoController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaSessao(CreateSessaoDto sessaoDto)
    {
        Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
        _context.Sessoes.Add(sessao);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = sessao.Id }, sessao);
    }

    [HttpGet]
    public IActionResult RecuperarSessoes()
    {
        return Ok(_context.Sessoes
            .Include(x => x.Cinema)
            .Include(x => x.Filme)
            .ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaSessaoPorId(int id)
    {
        Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
        if (sessao != null)
        {
            ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
            return Ok(sessaoDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaSessao(int id, [FromBody] UpdateSessaoDto sessaoDto)
    {
        Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
        if (sessao == null)
        {
            return NotFound();
        }
        _mapper.Map(sessaoDto, sessao);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaSessao(int id)
    {
        Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
        if (sessao == null)
        {
            return NotFound();
        }
        _context.Remove(sessao);
        _context.SaveChanges();
        return NoContent();
    }
}

using AutoMapper;
using FluentResults;
using FilmesAPI.Models;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;

namespace FilmesAPI.Services;

public class GerenteService
{
    private AppDbContext _context;
    private IMapper _mapper;
    public GerenteService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public ReadGerenteDto AdicionaGerente(CreateGerenteDto gerenteDto)
    {
        Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
        _context.Gerentes.Add(gerente);
        _context.SaveChanges();

        return _mapper.Map<ReadGerenteDto>(gerente);
    }
    public List<ReadGerenteDto> RecuperaGerentes()
    {
        List<Gerente> gerentes = _context.Gerentes.ToList();
        return _mapper.Map<List<ReadGerenteDto>>(gerentes);
    }
    public ReadGerenteDto RecuperaGerentePorId(int id)
    {
        Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
        if (gerente != null)
        {
            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        return null;
    }
    public Result AtualizaGerente(int id, UpdateGerenteDto gerenteDto)
    {
        Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
        if (gerente == null)
        {
            return Result.Fail("Gerente não encontrado");
        }
        _mapper.Map(gerenteDto, gerente);
        _context.SaveChanges();

        return Result.Ok();
    }
    public Result DeletaGerente(int id)
    {
        Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
        if (gerente == null)
        {
            return Result.Fail("Gerente não encontrado");
        }
        _context.Remove(gerente);
        _context.SaveChanges();

        return Result.Ok();
    }
}
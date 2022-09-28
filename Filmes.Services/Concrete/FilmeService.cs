using AutoMapper;
using FluentResults;
using Filmes.Services.Data.Dtos.Filme;
using Filmes.Infra;
using Filmes.Domain.Models;
using Filmes.Services.Interfaces;

namespace Filmes.Services.Concrete;

public class FilmeService : IFilmeService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public FilmeService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();

        return _mapper.Map<ReadFilmeDto>(filme);
    }

    public List<ReadFilmeDto> RecuperaFilmes(int? classificacaoEtaria)
    {
        List<Filme> filmes;

        if (classificacaoEtaria == null)
        {
            filmes = _context.Filmes.ToList();
        }
        else
        {
            filmes = _context
            .Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria)
            .ToList();
        }

        if (filmes != null)
        {
            return _mapper.Map<List<ReadFilmeDto>>(filmes);
        }

        return null;
    }

    public ReadFilmeDto RecuperaFilmePorId(int id)
    {
        Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        return filme != null 
            ? _mapper.Map<ReadFilmeDto>(filme) 
            : null;
    }
    public Result AtualizaFilme(int id, UpdateFilmeDto filmeDto)
    {
        Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
        {
            return Result.Fail("Filme não encontrado");
        }
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();

        return Result.Ok();
    }

    public Result DeletaFilme(int id)
    {
        Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
        {
            return Result.Fail("Filme não encontrado");
        }
        _context.Remove(filme);
        _context.SaveChanges();

        return Result.Ok();
    }
}
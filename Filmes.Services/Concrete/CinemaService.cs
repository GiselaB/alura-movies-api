using AutoMapper;
using FluentResults;
using Filmes.Services.Data.Dtos.Cinema;
using Filmes.Services.Interfaces;
using Filmes.Infra;
using Filmes.Domain.Models;

namespace Filmes.Services.Concrete;

public class CinemaService : ICinemaService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    
    public CinemaService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public ReadCinemaDto AdicionaCinema(CreateCinemaDto cinemaDto)
    {
        var cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();

        return _mapper.Map<ReadCinemaDto>(cinema);
    }
    
    public List<ReadCinemaDto> RecuperaCinemas(string nomeDoFilme)
    {
        if (string.IsNullOrWhiteSpace(nomeDoFilme))
        {
            return _mapper.Map<List<ReadCinemaDto>>(
                _context.Cinemas.ToList());
        }

        nomeDoFilme = nomeDoFilme.Trim();

        var cinemas = _context.Cinemas
            .Where(s => s.Sessoes.Any(f => f.Filme.Titulo == nomeDoFilme))
            .ToList();
        
        return _mapper.Map<List<ReadCinemaDto>>(cinemas);
    }
    
    public ReadCinemaDto RecuperaCinemaPorId(int id)
    {
        // TODO: E se o id for <= 0?
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        
        return cinema != null 
            ? _mapper.Map<ReadCinemaDto>(cinema) 
            : null;
    }
    public Result AtualizaCinema(int id, UpdateCinemaDto cinemaDto)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
        {
            return Result.Fail("Cinema não encontrado");
        }
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();

        return Result.Ok();
    }
    public Result DeletaCinema(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
        {
            return Result.Fail("Cinema não encontrado");
        }
        _context.Remove(cinema);
        _context.SaveChanges();

        return Result.Ok();
    }
}
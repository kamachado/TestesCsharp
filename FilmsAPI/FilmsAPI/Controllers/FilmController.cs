using AutoMapper;
using FilmesApi.Data;
using FilmesAPI.Data.Dtos;
using FilmsAPI.Data.Dtos;
using FilmsAPI.Data.Dtos.Film;
using FilmsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult PostFilm ([FromBody] CreateFilmDto filmeDto)
        {
            Film film = _mapper.Map<Film>(filmeDto);
            _context.Films.Add(film);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { Id = film.Id }, film);
        }



        [HttpGet]
        public IActionResult GetFilms()
        {
            return Ok(_context.Films);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Film film = _context.Films.FirstOrDefault(film => film.Id == id);

            if (film != null)
            {
                ReadFilmDto filmDto = _mapper.Map<ReadFilmDto>(film);
                return Ok(filmDto);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveById(int id)
        {
            Film film = _context.Films.FirstOrDefault(film => film.Id == id);
            if (film == null)
            {
                return NotFound();
            }
            _context.Remove(film);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, [FromBody] UpdateFilmDto filmDto)
        {
            Film film = _context.Films.FirstOrDefault(film => film.Id == id);

            if (film == null)
            {
                return NotFound();
            }

            _mapper.Map(filmDto, film);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
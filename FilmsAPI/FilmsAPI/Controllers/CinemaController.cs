using AutoMapper;
using FilmesApi.Data;
using FilmsAPI.Data.Dtos.Cinema;
using FilmsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmsAPI.Controllers
{
   
        [ApiController]
        [Route("[controller]")]
        public class CinemaController : ControllerBase
        {
            private AppDbContext _context;
            private IMapper _mapper;

            public CinemaController(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            [HttpPost]
            public IActionResult PostCinema([FromBody] CreateCinemaDto cinemaDto)
            {
                Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
                _context.Cinemas.Add(cinema);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetCinemasById), new { Id = cinema.Id }, cinema);
            }

            [HttpGet]
            public IActionResult GetCinemas([FromQuery] string nameOfFilm)
            {
            List<Cinema> cinemas = _context.Cinemas.ToList();
            if (cinemas == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(nameOfFilm))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Session.Any(session =>
                                            session.Film.Title == nameOfFilm)
                                            select cinema;

                cinemas = query.ToList();
            }
            List<ReadCinemaDto> readDto = _mapper.Map<List<ReadCinemaDto>>(cinemas);

            return Ok(readDto);
        }

            [HttpGet("{id}")]
            public IActionResult GetCinemasById(int id)
            {
                Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
                if (cinema != null)
                {
                    ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                    return Ok(cinemaDto);
                }
                return NotFound();
            }

            [HttpPut("{id}")]
            public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
            {
                Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
                if (cinema == null)
                {
                    return NotFound();
                }
                _mapper.Map(cinemaDto, cinema);
                _context.SaveChanges();
                return NoContent();
            }


            [HttpDelete("{id}")]
            public IActionResult RemoveCinema(int id)
            {
                Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
                if (cinema == null)
                {
                    return NotFound();
                }
                _context.Remove(cinema);
                _context.SaveChanges();
                return NoContent();
            }

        }
    }


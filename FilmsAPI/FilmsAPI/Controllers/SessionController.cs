using AutoMapper;
using FilmesApi.Data;
using FilmsAPI.Data.Dtos.Session;
using FilmsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FilmsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {

        private AppDbContext _context;
        private IMapper _mapper;

        public SessionController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult PostSession(CreateSessionDto dto)
        {
            Session session = _mapper.Map<Session>(dto);
            _context.Session.Add(session);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSessionById), new { Id = session.Id }, session);
        }

        [HttpGet("{id}")]
        public IActionResult GetSessionById(int id)
        {
            Session session = _context.Session.FirstOrDefault(sessao => sessao.Id == id);
            if (session != null)
            {
                ReadSessionDto sessionDto = _mapper.Map< ReadSessionDto >(session);

                return Ok(sessionDto);
            }
            return NotFound();
        }
    }
}


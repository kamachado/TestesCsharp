using AutoMapper;
using FilmesApi.Data;
using FilmsAPI.Data.Dtos.Manager;
using FilmsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAPI.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class ManagerController : ControllerBase
    {

            private AppDbContext _context;
            private IMapper _mapper;

            public ManagerController(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            [HttpPost]
            public IActionResult PostManager(CreateManagerDto dto)
            {
                Manager manager = _mapper.Map<Manager>(dto);
                _context.Manager.Add(manager);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetManagerById), new { Id = manager.Id }, manager);
            }

            [HttpGet("{id}")]
            public IActionResult GetManagerById(int id)
            {
                Manager manager = _context.Manager.FirstOrDefault(manager => manager.Id == id);
                if (manager != null)
                {
                    ReadManagerDto managerDto = _mapper.Map<ReadManagerDto>(manager);

                    return Ok(managerDto);
                }
                return NotFound();
            }

            [HttpDelete("{id}")]
            public IActionResult RemoveManager(int id)
            {
                Manager manager = _context.Manager.FirstOrDefault(manager => manager.Id == id);
                if (manager == null)
                {
                    return NotFound();
                }
                _context.Remove(manager);
                _context.SaveChanges();
                return NoContent();
            }
        }




}



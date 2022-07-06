using AutoMapper;
using FilmesApi.Data;
using FilmsAPI.Data.Dtos.Address;
using FilmsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public AddressController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult PostAddress([FromBody] CreateAddressDto addressDto)
        {
            Address address = _mapper.Map<Address>(addressDto);
            _context.Address.Add(address);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAddressById), new { Id = address.Id }, address);
        }

        [HttpGet]
        public IActionResult GetAddress()
        {
            return Ok(_context.Address);
        }

        [HttpGet("{id}")]
        public IActionResult GetAddressById(int id)
        {
            Address address = _context.Address.FirstOrDefault(address => address.Id == id);
            if (address != null)
            {
                ReadAddressDto enderecoDto = _mapper.Map<ReadAddressDto>(address);

                return Ok(enderecoDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAddress(int id, [FromBody] UpdateAddressDto addressDto)
        {
            Address address = _context.Address.FirstOrDefault(address => address.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            _mapper.Map(addressDto, address);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult RemoveAddress(int id)
        {
            Address address = _context.Address.FirstOrDefault(address => address.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            _context.Remove(address);
            _context.SaveChanges();
            return NoContent();
        }

    }
}

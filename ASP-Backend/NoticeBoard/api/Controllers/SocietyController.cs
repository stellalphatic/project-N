using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Society;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocietyController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SocietyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var societies = await _context.Societies.ToListAsync();
            return Ok(societies);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var society = await _context.Societies.FirstOrDefaultAsync(x => x.SocietyId == id);
            if (society == null)
                return NotFound();

            return Ok(society);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSocietyDto societyDto)
        {


            var society = new Society
            {
                Name = societyDto.Name,
                Description = societyDto.Description

            };

            await _context.AddAsync(society);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = society.SocietyId }, society);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSocietyDto updateDto)  //since we'r gettin id from route and dto from body or request
        {

            var society = await _context.Societies.FindAsync(id);
            if (society == null)
                return NotFound();

            society.Name = updateDto.Name;
            society.Description = updateDto.Description;
            society.CreationDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();


            return Ok(society);

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            var society = await _context.Societies.FindAsync(id);

            if (society == null)
                return NotFound();

            _context.Societies.Remove(society);
            await _context.SaveChangesAsync();


            return NoContent();
        }
    }
}
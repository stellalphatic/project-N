using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Dtos.Posts;
using api.Dtos.SocietyPosts;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocietyPostController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SocietyPostController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var societies = await _context.SocietyPosts.ToListAsync();
            return Ok(societies);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var post = await _context.SocietyPosts.FirstOrDefaultAsync(x => x.SocietyPostId == id);
            if (post == null)
                return NotFound();

            return Ok(post);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSocietyPostDto postDto)
        {


            var post = new SocietyPost
            {
                Title = postDto.Title,
                Content = postDto.Content,
                ImageUrl = postDto.ImageUrl

            };

            await _context.AddAsync(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = post.SocietyPostId }, post);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSocietyPostDto updateDto)
        {

            var post = await _context.SocietyPosts.FindAsync(id);
            if (post == null)
                return NotFound();

            post.Title = updateDto.Title;
            post.Content = updateDto.Content;
            post.ImageUrl = updateDto.ImageUrl;
            post.PostDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();


            return Ok(post);

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            var post = await _context.SocietyPosts.FindAsync(id);

            if (post == null)
                return NotFound();

            _context.SocietyPosts.Remove(post);
            await _context.SaveChangesAsync();


            return NoContent();
        }

    }

}
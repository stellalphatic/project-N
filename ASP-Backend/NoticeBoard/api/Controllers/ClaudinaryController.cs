using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Service;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly ICloudinaryStorageService _cloudinaryStorageService;
        private readonly AppDbContext _dbContext;

        public UploadController(ICloudinaryStorageService cloudinaryStorageService, AppDbContext dbContext)
        {
            _cloudinaryStorageService = cloudinaryStorageService;
            _dbContext = dbContext;
        }

        [HttpPost("image")]
        public async Task<IActionResult> UploadImage(IFormFile file, string entityType, int entityId)
        {
            // ... (file validation as before)

            string folder = "";
            if (entityType.ToLower() == "notice") folder = "notices";
            else if (entityType.ToLower() == "event") folder = "events";
            else if (entityType.ToLower() == "society") folder = "societies";
            else return BadRequest("Invalid entity type.");

            var imageUrl = await _cloudinaryStorageService.UploadFileAsync(file, folder);

            if (string.IsNullOrEmpty(imageUrl))
            {
                return StatusCode(500, "Failed to upload image to Cloudinary.");
            }

            // Update database with imageUrl (same logic as before)
            if (entityType.ToLower() == "notice")
            {
                var notice = await _dbContext.Notices.FindAsync(entityId);
                if (notice != null)
                {
                    notice.ImageUrl = imageUrl;
                    await _dbContext.SaveChangesAsync();
                }
            }
            // ... (similar logic for Event and SocietyPost)

            return Ok(new { imageUrl });
        }
    }
}
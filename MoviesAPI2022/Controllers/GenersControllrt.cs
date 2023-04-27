using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenersControllrt : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenersControllrt(ApplicationDbContext context)
        {
            _context = context;
        }


        //first endPpoint to rerturn all geners in database
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var geners = await _context.Genres.OrderBy(m => m.Name).ToListAsync();
            return Ok(geners);
        }

        [HttpPost]
        public async Task<IActionResult> addasync(CreateGenreDTO dto)
        {
            var genere = new CreateGenreDto
            {
                Name = dto.Name,
            };
            await _context.Genres.AddAsync(genere);
            _context.SaveChanges();
            return Ok(genere);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CreateGenreDto dto)
        {

        }
        

    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Controllers
{
    [Authorize(Roles = "1")]
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroService _generoService;

        public GeneroController(IGeneroService generoService)
        {
            _generoService = generoService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllGenerosAsync()
        {
            var generos = await _generoService.GetAllAsync();
            return Ok(generos);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetGeneroByIdAsync(ObjectId id)
        {
            var genero = await _generoService.GetByIdAsync(id);
            if (genero == null)
            {
                return NotFound();
            }
            return Ok(genero);
        }

        [HttpPost]
        public async Task<IActionResult> AddGeneroAsync([FromBody] GeneroModel genero)
        {
            if (genero == null)
            {
                return BadRequest("Genero cannot be null.");
            }

            await _generoService.AddAsync(genero);
            return Ok(genero);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGeneroAsync(ObjectId id, [FromBody] GeneroModel genero)
        {
            if (genero == null || genero.Id != id)
            {
                return BadRequest("Genero is null or id mismatch.");
            }

            var existingGenero = await _generoService.GetByIdAsync(id);
            if (existingGenero == null)
            {
                return NotFound();
            }

            await _generoService.UpdateAsync(id, genero);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneroAsync(ObjectId id)
        {
            var genero = await _generoService.GetByIdAsync(id);
            if (genero == null)
            {
                return NotFound();
            }

            await _generoService.DeleteAsync(id);
            return NoContent();
        }
    }
}

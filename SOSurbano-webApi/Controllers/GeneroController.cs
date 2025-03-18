using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Controllers
{
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
            var generos = await _generoService.GetAllGenerosAsync();
            return Ok(generos);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetGeneroByIdAsync(ObjectId id)
        {
            var genero = await _generoService.GetGeneroByIdAsync(id);
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

            await _generoService.AddGeneroAsync(genero);
            return Ok(genero);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGeneroAsync(ObjectId id, [FromBody] GeneroModel genero)
        {
            if (genero == null || genero.Id != id)
            {
                return BadRequest("Genero is null or id mismatch.");
            }

            var existingGenero = await _generoService.GetGeneroByIdAsync(id);
            if (existingGenero == null)
            {
                return NotFound();
            }

            await _generoService.UpdateGeneroAsync(genero);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneroAsync(ObjectId id)
        {
            var genero = await _generoService.GetGeneroByIdAsync(id);
            if (genero == null)
            {
                return NotFound();
            }

            await _generoService.DeleteGeneroAsync(id);
            return NoContent();
        }
    }
}

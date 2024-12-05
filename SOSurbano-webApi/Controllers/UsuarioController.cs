using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsuariosAsync()
        {
            var usuarios = await _usuarioService.GetAllUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> AddUsuarioAsync([FromBody] UsuarioModel usuario)
        {
            if (usuario == null)
            {
                return BadRequest("User cannot be null.");
            }

            await _usuarioService.AddUsuarioAsync(usuario);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuarioAsync(int id, [FromBody] UsuarioModel usuario)
        {
            if (usuario == null || usuario.Id != id)
            {
                return BadRequest("Invalid data.");
            }

            await _usuarioService.UpdateUsuarioAsync(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioAsync(int id)
        {
            await _usuarioService.DeleteUsuarioAsync(id);
            return NoContent();
        }
    }
}

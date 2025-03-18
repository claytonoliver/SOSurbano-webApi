using Microsoft.AspNetCore.Mvc;
using SosUrbano.Application.DTOs;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public AuthController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] RequestLoginDTO UsuarioLogin)
        {
            var Token = await _usuarioService.Authenticate(UsuarioLogin);
            if (Token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token = Token });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SosUrbano.Application.DTOs;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] RequestLoginDTO UsuarioLogin)
        {
            var Token = await _authService.Authenticate(UsuarioLogin);
            if (Token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token = Token });
        }
    }
}

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SosUrbano.Application.DTOs;
using SosUrbano.Domain.Entities;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SOSurbano_webApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly JwtSettingsModel _jwtSettings;
        public AuthService(IUsuarioService usuarioService, IOptions<JwtSettingsModel> jwtSettings)
        {
            _usuarioService = usuarioService;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<string> Authenticate(RequestLoginDTO UsuarioLogin)
        {
            var usuarioLogado = await _usuarioService.Authenticate(UsuarioLogin);

            return GenerateJwtToken((UsuarioModel)usuarioLogado);
        }

        private string GenerateJwtToken(UsuarioModel user)
        {

            byte[] secretKey = Encoding.UTF8.GetBytes(_jwtSettings.Secret);
            var securityKey = new SymmetricSecurityKey(secretKey);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Nome),
                new Claim(ClaimTypes.Role, user.RoleId.ToString()),
                new Claim(ClaimTypes.Hash, Guid.NewGuid().ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = credentials
            };


            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }
    }
}

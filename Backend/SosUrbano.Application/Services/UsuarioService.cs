using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using SosUrbano.Application.DTOs;
using SosUrbano.Application.Services.Interfaces;
using SosUrbano.Domain.Entities;
using SosUrbano.Infrastructure.Data.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SosUrbano.Application.Services
{
    public class UsuarioService : BaseMongoService<UsuarioModel>, IUsuarioService
    {
        private readonly IMongoCollection<UsuarioModel> _usuarios;
        private readonly JwtSettingsModel _jwtSettings;
        public UsuarioService(IMongoDatabase database, MongoDbContext context, IOptions<JwtSettingsModel> jwtSettings) : base(database, "SOU_Usuario")
        {
            _usuarios = context.GetCollection<UsuarioModel>("SOU_Usuario");
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<string> Authenticate(RequestLoginDTO usuario)
        {
            var usuarioAutenticado = await _usuarios.Find(u => u.CPF == usuario.CPF).FirstOrDefaultAsync();
            return GenerateJwtToken(usuarioAutenticado);
        }

        private string GenerateJwtToken(UsuarioModel user)
        {

            byte[] secretKey = Convert.FromBase64String(_jwtSettings.Secret);
            var securityKey = new SymmetricSecurityKey(secretKey);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Nome),
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
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
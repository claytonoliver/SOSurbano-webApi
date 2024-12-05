using Fiap.Api.Alunos.Services;
using SOSurbano_webApi.Model;

namespace Fiap.Web.Alunos.Services
{
    public class AuthService : IAuthService
    {
        private List<UsuarioModel> _users = new List<UsuarioModel>
        {
            new UsuarioModel { Id = 1, Nome = "operador01", Senha = "pass123", Role = new RoleModel { Id = 1, Nome = "operador" } },
            new UsuarioModel { Id = 2, Nome = "analista01", Senha = "pass123", Role = new RoleModel { Id = 2, Nome = "analista" } },
            new UsuarioModel { Id = 3, Nome = "gerente01", Senha = "pass123", Role = new RoleModel { Id = 3, Nome = "gerente" } },
            new UsuarioModel { Id = 4, Nome = "operador02", Senha = "pass123", Role = new RoleModel { Id = 1, Nome = "operador" } },
            new UsuarioModel { Id = 5, Nome = "analista02", Senha = "pass123", Role = new RoleModel { Id = 2, Nome = "analista" } },
            new UsuarioModel { Id = 6, Nome = "gerente02", Senha = "pass123", Role = new RoleModel { Id = 3, Nome = "gerente" } },
            new UsuarioModel { Id = 7, Nome = "operador03", Senha = "pass123", Role = new RoleModel { Id = 1, Nome = "operador" } }
        };

        public UsuarioModel Authenticate(string username, string password)
        {
            // Aqui você normalmente faria a verificação de senha de forma segura
            return _users.FirstOrDefault(u => u.Nome == username && u.Senha == password);
        }
    }
}

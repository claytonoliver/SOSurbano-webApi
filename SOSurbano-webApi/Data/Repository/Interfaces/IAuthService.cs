using SOSurbano_webApi.Model;

namespace Fiap.Api.Alunos.Services
{
    public interface IAuthService
    {
        UsuarioModel Authenticate(string username, string password);

    }
}

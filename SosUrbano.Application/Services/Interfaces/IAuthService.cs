using SosUrbano.Application.DTOs;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Authenticate(RequestLoginDTO UsuarioLogin);
    }
}

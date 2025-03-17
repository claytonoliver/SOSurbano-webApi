using MongoDB.Bson;
using SosUrbano.Application.DTOs;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioModel> GetUsuarioByIdAsync(ObjectId id);
        Task<IEnumerable<UsuarioModel>> GetAllUsuariosAsync();
        Task UserRegisterAsync(RequestUserRegistrationDto usuario);
        Task UpdateUsuarioAsync(UsuarioModel usuario);
        Task DeleteUsuarioAsync(ObjectId id);
        Task<UsuarioModel> Authenticate(RequestLoginDTO usuario);
    }
}
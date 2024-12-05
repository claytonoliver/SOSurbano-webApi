using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioModel> GetUsuarioByIdAsync(int id);
        Task<IEnumerable<UsuarioModel>> GetAllUsuariosAsync();
        Task AddUsuarioAsync(UsuarioModel usuario);
        Task UpdateUsuarioAsync(UsuarioModel usuario);
        Task DeleteUsuarioAsync(int id);
    }
}
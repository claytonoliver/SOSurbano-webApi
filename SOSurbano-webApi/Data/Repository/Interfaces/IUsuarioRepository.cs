using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel> GetByIdAsync(int id);
        Task<IEnumerable<UsuarioModel>> GetAllAsync();
        Task AddAsync(UsuarioModel usuario);
        Task UpdateAsync(UsuarioModel usuario);
        Task DeleteAsync(int id);
    }
}

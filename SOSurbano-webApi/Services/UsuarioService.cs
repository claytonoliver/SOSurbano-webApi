using SOSurbano_webApi.Data.Repository;
using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<UsuarioModel> GetUsuarioByIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<UsuarioModel>> GetAllUsuariosAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task AddUsuarioAsync(UsuarioModel usuario)
        {
            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task UpdateUsuarioAsync(UsuarioModel usuario)
        {
            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }
    }
}
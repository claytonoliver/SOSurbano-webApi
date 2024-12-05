using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Services
{
    public class ChamadoService : IChamadoService
    {
        private readonly IChamadoRepository _chamadoRepository;

        public ChamadoService(IChamadoRepository generoRepository)
        {
            _chamadoRepository = generoRepository;
        }

        public async Task<ChamadoModel> GetChamadoByIdAsync(int id)
        {
            return await _chamadoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ChamadoModel>> GetAllChamadosAsync()
        {
            return await _chamadoRepository.GetAllAsync();
        }

        public async Task AddChamadoAsync(ChamadoModel chamado)
        {
            await _chamadoRepository.AddAsync(chamado);
        }

        public async Task UpdateChamadoAsync(ChamadoModel chamado)
        {
            await _chamadoRepository.UpdateAsync(chamado);
        }

        public async Task DeleteChamadoAsync(int id)
        {
            await _chamadoRepository.DeleteAsync(id);
        }
    }
}

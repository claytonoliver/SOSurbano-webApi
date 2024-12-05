using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Services
{
    public class StatusChamadoService : IStatusChamadoService
    {
        private readonly IStatusChamadoRepository _statusChamadoRepository;
        public StatusChamadoService(IStatusChamadoRepository statusChamadoRepository)
        {
            _statusChamadoRepository = statusChamadoRepository;
        }

        public async Task<StatusChamadoModel> GetStatusChamadoByIdAsync(int id)
        {
            return await _statusChamadoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<StatusChamadoModel>> GetAllStatusChamadosAsync()
        {
            return await _statusChamadoRepository.GetAllAsync();
        }

        public async Task AddStatusChamadoAsync(StatusChamadoModel statusChamado)
        {
            await _statusChamadoRepository.AddAsync(statusChamado);
        }

        public async Task UpdateStatusChamadoAsync(StatusChamadoModel statusChamado)
        {
            await _statusChamadoRepository.UpdateAsync(statusChamado);
        }

        public async Task DeleteStatusChamadoAsync(int id)
        {
            await _statusChamadoRepository.DeleteAsync(id);
        }
    }
}

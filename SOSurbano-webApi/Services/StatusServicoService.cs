using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Services
{
    public class StatusServicoService : IStatusServicoService
    {
        private readonly IStatusServiceRepository _statusServicoRepository;
        public StatusServicoService(IStatusServiceRepository statusServicoRepository)
        {
            _statusServicoRepository = statusServicoRepository;
        }

        public async Task<StatusServicoModel> GetStatusServicoByIdAsync(int id)
        {
            return await _statusServicoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<StatusServicoModel>> GetAllStatusServicosAsync()
        {
            return await _statusServicoRepository.GetAllAsync();
        }

        public async Task AddStatusServicoAsync(StatusServicoModel statusServico)
        {
            await _statusServicoRepository.AddAsync(statusServico);
        }

        public async Task UpdateStatusServicoAsync(StatusServicoModel statusServico)
        {
            await _statusServicoRepository.UpdateAsync(statusServico);
        }

        public async Task DeleteStatusServicoAsync(int id)
        {
            await _statusServicoRepository.DeleteAsync(id);
        }
    }
}
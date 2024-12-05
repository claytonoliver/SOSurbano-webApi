using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Services
{
    public class HistoricoServicoStatusService : IHistoricoServicoStatusService
    {
        private readonly IHistoricoServicoStatusRepository _historicoServicoStatusRepository;
        public HistoricoServicoStatusService(IHistoricoServicoStatusRepository historicoServicoStatusRepository)
        {
            _historicoServicoStatusRepository = historicoServicoStatusRepository;
        }

        public async Task<HistoricoServicoStatusModel> GetHistoricoServicoStatusByIdAsync(int id)
        {
            return await _historicoServicoStatusRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<HistoricoServicoStatusModel>> GetAllHistoricoServicoStatusAsync()
        {
            return await _historicoServicoStatusRepository.GetAllAsync();
        }

        public async Task AddHistoricoServicoStatusAsync(HistoricoServicoStatusModel historicoServicoStatus)
        {
            await _historicoServicoStatusRepository.AddAsync(historicoServicoStatus);
        }

        public async Task UpdateHistoricoServicoStatusAsync(HistoricoServicoStatusModel historicoServicoStatus)
        {
            await _historicoServicoStatusRepository.UpdateAsync(historicoServicoStatus);
        }

        public async Task DeleteHistoricoServicoStatusAsync(int id)
        {
            await _historicoServicoStatusRepository.DeleteAsync(id);
        }
    }
}
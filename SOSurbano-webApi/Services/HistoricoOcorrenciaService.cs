using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Services
{
    public class HistoricoOcorrenciaService : IHistoricoOcorrenciaService
    {
        private readonly IHistoricoOcorrenciaRepository _historicoOcorrenciaRepository;
        public HistoricoOcorrenciaService(IHistoricoOcorrenciaRepository historicoOcorrenciaRepository)
        {
            _historicoOcorrenciaRepository = historicoOcorrenciaRepository;
        }

        public async Task<HistoricoOcorrenciaModel> GetHistoricoOcorrenciaByIdAsync(int id)
        {
            return await _historicoOcorrenciaRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<HistoricoOcorrenciaModel>> GetAllHistoricoOcorrenciasAsync()
        {
            return await _historicoOcorrenciaRepository.GetAllAsync();
        }

        public async Task AddHistoricoOcorrenciaAsync(HistoricoOcorrenciaModel historicoOcorrencia)
        {
            await _historicoOcorrenciaRepository.AddAsync(historicoOcorrencia);
        }

        public async Task UpdateHistoricoOcorrenciaAsync(HistoricoOcorrenciaModel historicoOcorrencia)
        {
            await _historicoOcorrenciaRepository.UpdateAsync(historicoOcorrencia);
        }

        public async Task DeleteHistoricoOcorrenciaAsync(int id)
        {
            await _historicoOcorrenciaRepository.DeleteAsync(id);
        }
    }
}

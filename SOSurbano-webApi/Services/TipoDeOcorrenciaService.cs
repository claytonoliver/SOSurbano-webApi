using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Services
{
    public class TipoDeOcorrenciaService : ITipoDeOcorrenciaService
    {
        private readonly ITipoDeOcorrenciaRepository _tipoDeOcorrenciaRepository;

        public TipoDeOcorrenciaService(ITipoDeOcorrenciaRepository tipoDeOcorrenciaRepository)
        {
            _tipoDeOcorrenciaRepository = tipoDeOcorrenciaRepository;
        }

        public async Task<TipoDeOcorrenciaModel> GetTipoDeOcorrenciaByIdAsync(int id)
        {
            return await _tipoDeOcorrenciaRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TipoDeOcorrenciaModel>> GetAllTiposDeOcorrenciaAsync()
        {
            return await _tipoDeOcorrenciaRepository.GetAllAsync();
        }

        public async Task AddTipoDeOcorrenciaAsync(TipoDeOcorrenciaModel tipoDeOcorrencia)
        {
            await _tipoDeOcorrenciaRepository.AddAsync(tipoDeOcorrencia);
        }

        public async Task UpdateTipoDeOcorrenciaAsync(TipoDeOcorrenciaModel tipoDeOcorrencia)
        {
            await _tipoDeOcorrenciaRepository.UpdateAsync(tipoDeOcorrencia);
        }

        public async Task DeleteTipoDeOcorrenciaAsync(int id)
        {
            await _tipoDeOcorrenciaRepository.DeleteAsync(id);
        }
    }
}
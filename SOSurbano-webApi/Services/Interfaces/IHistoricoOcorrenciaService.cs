using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface IHistoricoOcorrenciaService
    {
        Task<HistoricoOcorrenciaModel> GetHistoricoOcorrenciaByIdAsync(int id);
        Task<IEnumerable<HistoricoOcorrenciaModel>> GetAllHistoricoOcorrenciasAsync();
        Task AddHistoricoOcorrenciaAsync(HistoricoOcorrenciaModel historicoOcorrencia);
        Task UpdateHistoricoOcorrenciaAsync(HistoricoOcorrenciaModel historicoOcorrencia);
        Task DeleteHistoricoOcorrenciaAsync(int id);
    }
}

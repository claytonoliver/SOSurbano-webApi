using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Repository.Interfaces
{
    public interface IHistoricoOcorrenciaRepository
    {
        Task<HistoricoOcorrenciaModel> GetByIdAsync(int id);
        Task<IEnumerable<HistoricoOcorrenciaModel>> GetAllAsync();
        Task AddAsync(HistoricoOcorrenciaModel historicoOcorrencia);
        Task UpdateAsync(HistoricoOcorrenciaModel historicoOcorrencia);
        Task DeleteAsync(int id);
    }
}

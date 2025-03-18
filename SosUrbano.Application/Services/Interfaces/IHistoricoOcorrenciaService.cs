using MongoDB.Bson;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface IHistoricoOcorrenciaService
    {
        Task AddAsync(HistoricoOcorrenciaModel historicoOcorrencia);
        Task DeleteAsync(ObjectId id);
        Task<IEnumerable<HistoricoOcorrenciaModel>> GetAllAsync();
        Task<HistoricoOcorrenciaModel> GetByIdAsync(ObjectId id);
        Task UpdateAsync(ObjectId id, HistoricoOcorrenciaModel historicoOcorrencia);
    }
}

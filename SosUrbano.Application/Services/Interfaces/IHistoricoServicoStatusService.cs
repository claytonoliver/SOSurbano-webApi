using MongoDB.Bson;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface IHistoricoServicoStatusService
    {
        Task AddAsync(HistoricoServicoStatusModel historicoServicoStatusModel);
        Task DeleteAsync(ObjectId id);
        Task<IEnumerable<HistoricoServicoStatusModel>> GetAllAsync();
        Task<HistoricoServicoStatusModel> GetByIdAsync(ObjectId id);
        Task UpdateAsync(ObjectId id, HistoricoServicoStatusModel historicoServicoStatusModel);
    }
}

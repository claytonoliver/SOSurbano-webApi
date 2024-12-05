using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Repository.Interfaces
{
    public interface IHistoricoServicoStatusRepository
    {
        Task<HistoricoServicoStatusModel> GetByIdAsync(int id);
        Task<IEnumerable<HistoricoServicoStatusModel>> GetAllAsync();
        Task AddAsync(HistoricoServicoStatusModel historicoServicoStatus);
        Task UpdateAsync(HistoricoServicoStatusModel historicoServicoStatus);
        Task DeleteAsync(int id);
    }
}

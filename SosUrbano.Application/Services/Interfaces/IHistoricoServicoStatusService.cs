using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface IHistoricoServicoStatusService
    {
        Task<HistoricoServicoStatusModel> GetHistoricoServicoStatusByIdAsync(int id);
        Task<IEnumerable<HistoricoServicoStatusModel>> GetAllHistoricoServicoStatusAsync();
        Task AddHistoricoServicoStatusAsync(HistoricoServicoStatusModel historicoServicoStatus);
        Task UpdateHistoricoServicoStatusAsync(HistoricoServicoStatusModel historicoServicoStatus);
        Task DeleteHistoricoServicoStatusAsync(int id);
    }
}

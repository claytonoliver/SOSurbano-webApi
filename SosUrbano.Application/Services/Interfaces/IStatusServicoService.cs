using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface IStatusServicoService
    {
        Task<StatusServicoModel> GetStatusServicoByIdAsync(int id);
        Task<IEnumerable<StatusServicoModel>> GetAllStatusServicosAsync();
        Task AddStatusServicoAsync(StatusServicoModel statusServico);
        Task UpdateStatusServicoAsync(StatusServicoModel statusServico);
        Task DeleteStatusServicoAsync(int id);
    }
}

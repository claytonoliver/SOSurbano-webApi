using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface IStatusChamadoService
    {
        Task<StatusChamadoModel> GetStatusChamadoByIdAsync(int id);
        Task<IEnumerable<StatusChamadoModel>> GetAllStatusChamadosAsync();
        Task AddStatusChamadoAsync(StatusChamadoModel statusChamado);
        Task UpdateStatusChamadoAsync(StatusChamadoModel statusChamado);
        Task DeleteStatusChamadoAsync(int id);
    }
}
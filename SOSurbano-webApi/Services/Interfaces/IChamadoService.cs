using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface IChamadoService
    {
        Task<ChamadoModel> GetChamadoByIdAsync(int id);
        Task<IEnumerable<ChamadoModel>> GetAllChamadosAsync();
        Task AddChamadoAsync(ChamadoModel chamado);
        Task UpdateChamadoAsync(ChamadoModel chamado);
        Task DeleteChamadoAsync(int id);
    }
}

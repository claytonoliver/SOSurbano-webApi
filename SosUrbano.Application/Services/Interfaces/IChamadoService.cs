using MongoDB.Bson;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface IChamadoService
    {
        Task<ChamadoModel> GetChamadoByIdAsync(ObjectId id);
        Task<IEnumerable<ChamadoModel>> GetAllChamadosAsync();
        Task AddChamadoAsync(ChamadoModel chamado);
        Task UpdateChamadoAsync(ChamadoModel chamado);
        Task DeleteChamadoAsync(ObjectId id);
    }
}

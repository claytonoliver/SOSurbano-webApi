using MongoDB.Bson;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface IChamadoService
    {
        Task AddAsync(ChamadoModel chamado);
        Task DeleteAsync(ObjectId id);
        Task<IEnumerable<ChamadoModel>> GetAllAsync();
        Task<ChamadoModel> GetByIdAsync(ObjectId id);
        Task UpdateAsync(ObjectId id, ChamadoModel chamado);
    }
}

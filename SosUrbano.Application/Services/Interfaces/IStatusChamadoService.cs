using MongoDB.Bson;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface IStatusChamadoService
    {
        Task AddAsync(StatusChamadoModel statusChamado);
        Task DeleteAsync(ObjectId id);
        Task<IEnumerable<StatusChamadoModel>> GetAllAsync();
        Task<StatusChamadoModel> GetByIdAsync(ObjectId id);
        Task UpdateAsync(ObjectId id, StatusChamadoModel statusChamado);
    }
}
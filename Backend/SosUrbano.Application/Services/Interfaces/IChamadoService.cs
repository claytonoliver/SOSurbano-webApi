using MongoDB.Bson;
using SosUrbano.Domain.Entities;

namespace SosUrbano.Application.Services.Interfaces
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

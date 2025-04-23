using MongoDB.Bson;
using SosUrbano.Domain.Entities;

namespace SosUrbano.Application.Services.Interfaces
{
    public interface IVeiculoService
    {
        Task AddAsync(VeiculoModel veiculo);
        Task DeleteAsync(ObjectId id);
        Task<IEnumerable<VeiculoModel>> GetAllAsync();
        Task<VeiculoModel> GetByIdAsync(ObjectId id);
        Task UpdateAsync(ObjectId id, VeiculoModel veiculo);
    }
}

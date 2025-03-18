using MongoDB.Bson;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface IGeneroService
    {
        Task AddAsync(GeneroModel Genero);
        Task DeleteAsync(ObjectId id);
        Task<IEnumerable<GeneroModel>> GetAllAsync();
        Task<GeneroModel> GetByIdAsync(ObjectId id);
        Task UpdateAsync(ObjectId id, GeneroModel Genero);
    }
}

using MongoDB.Bson;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface IGeneroService
    {
        Task<GeneroModel> GetGeneroByIdAsync(ObjectId id);
        Task<IEnumerable<GeneroModel>> GetAllGenerosAsync();
        Task AddGeneroAsync(GeneroModel genero);
        Task UpdateGeneroAsync(GeneroModel genero);
        Task DeleteGeneroAsync(ObjectId id);
    }
}

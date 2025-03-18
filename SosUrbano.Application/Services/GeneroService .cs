using MongoDB.Bson;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Services
{
    public class GeneroService : IGeneroService
    {
        public Task AddGeneroAsync(GeneroModel genero)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGeneroAsync(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GeneroModel>> GetAllGenerosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GeneroModel> GetGeneroByIdAsync(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGeneroAsync(GeneroModel genero)
        {
            throw new NotImplementedException();
        }
    }
}
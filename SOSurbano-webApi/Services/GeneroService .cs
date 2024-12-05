using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroService(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        public async Task<GeneroModel> GetGeneroByIdAsync(int id)
        {
            return await _generoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<GeneroModel>> GetAllGenerosAsync()
        {
            return await _generoRepository.GetAllAsync();
        }

        public async Task AddGeneroAsync(GeneroModel genero)
        {
            await _generoRepository.AddAsync(genero);
        }

        public async Task UpdateGeneroAsync(GeneroModel genero)
        {
            await _generoRepository.UpdateAsync(genero);
        }

        public async Task DeleteGeneroAsync(int id)
        {
            await _generoRepository.DeleteAsync(id);
        }
    }
}
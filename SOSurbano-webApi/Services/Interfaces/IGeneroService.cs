using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface IGeneroService
    {
        Task<GeneroModel> GetGeneroByIdAsync(int id);
        Task<IEnumerable<GeneroModel>> GetAllGenerosAsync();
        Task AddGeneroAsync(GeneroModel genero);
        Task UpdateGeneroAsync(GeneroModel genero);
        Task DeleteGeneroAsync(int id);
    }
}

using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Repository.Interfaces
{
    public interface IGeneroRepository
    {
        Task<GeneroModel> GetByIdAsync(int id);
        Task<IEnumerable<GeneroModel>> GetAllAsync();
        Task AddAsync(GeneroModel genero);
        Task UpdateAsync(GeneroModel genero);
        Task DeleteAsync(int id);
    }
}
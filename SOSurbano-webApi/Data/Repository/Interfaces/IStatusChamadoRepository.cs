using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Repository.Interfaces
{
    public interface IStatusChamadoRepository
    {
        Task<StatusChamadoModel> GetByIdAsync(int id);
        Task<IEnumerable<StatusChamadoModel>> GetAllAsync();
        Task AddAsync(StatusChamadoModel statusChamado);
        Task UpdateAsync(StatusChamadoModel statusChamado);
        Task DeleteAsync(int id);
    }
}

using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Repository.Interfaces
{
    public interface IStatusServiceRepository
    {
        Task<StatusServicoModel> GetByIdAsync(int id);
        Task<IEnumerable<StatusServicoModel>> GetAllAsync();
        Task AddAsync(StatusServicoModel statusServico);
        Task UpdateAsync(StatusServicoModel statusServico);
        Task DeleteAsync(int id);
    }
}

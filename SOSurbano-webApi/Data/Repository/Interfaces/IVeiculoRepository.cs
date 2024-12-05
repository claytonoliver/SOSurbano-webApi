using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Repository.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<VeiculoModel> GetByIdAsync(int id);
        Task<IEnumerable<VeiculoModel>> GetAllAsync();
        Task AddAsync(VeiculoModel veiculo);
        Task UpdateAsync(VeiculoModel veiculo);
        Task DeleteAsync(int id);
    }
}

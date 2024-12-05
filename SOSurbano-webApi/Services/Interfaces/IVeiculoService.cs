using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface IVeiculoService
    {
        Task<VeiculoModel> GetVeiculoByIdAsync(int id);
        Task<IEnumerable<VeiculoModel>> GetAllVeiculosAsync();
        Task AddVeiculoAsync(VeiculoModel veiculo);
        Task UpdateVeiculoAsync(VeiculoModel veiculo);
        Task DeleteVeiculoAsync(int id);
    }
}

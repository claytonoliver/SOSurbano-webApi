using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<VeiculoModel> GetVeiculoByIdAsync(int id)
        {
            return await _veiculoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<VeiculoModel>> GetAllVeiculosAsync()
        {
            return await _veiculoRepository.GetAllAsync();
        }

        public async Task AddVeiculoAsync(VeiculoModel veiculo)
        {
            await _veiculoRepository.AddAsync(veiculo);
        }

        public async Task UpdateVeiculoAsync(VeiculoModel veiculo)
        {
            await _veiculoRepository.UpdateAsync(veiculo);
        }

        public async Task DeleteVeiculoAsync(int id)
        {
            await _veiculoRepository.DeleteAsync(id);
        }
    }
}

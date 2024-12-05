using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Repository.Interfaces
{
    public interface IChamadoRepository
    {
        Task<ChamadoModel> GetByIdAsync(int id);
        Task<IEnumerable<ChamadoModel>> GetAllAsync();
        Task AddAsync(ChamadoModel chamado);
        Task UpdateAsync(ChamadoModel chamado);
        Task DeleteAsync(int id);
    }
}

using MongoDB.Bson;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface IStatusServicoService
    {
        Task AddAsync(StatusServicoModel statusServico);
        Task DeleteAsync(ObjectId id);
        Task<IEnumerable<StatusServicoModel>> GetAllAsync();
        Task<StatusServicoModel> GetByIdAsync(ObjectId id);
        Task UpdateAsync(ObjectId id, StatusServicoModel statusServico);
    }
}

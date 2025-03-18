using MongoDB.Bson;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface IRoleService
    {
        Task AddAsync(RoleModel role);
        Task DeleteAsync(ObjectId id);
        Task<IEnumerable<RoleModel>> GetAllAsync();
        Task<RoleModel> GetByIdAsync(ObjectId id);
        Task UpdateAsync(ObjectId id, RoleModel role);
    }
}

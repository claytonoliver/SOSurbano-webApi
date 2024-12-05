using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Repository.Interfaces
{
    public interface IRoleRepository
    {
        Task<RoleModel> GetByIdAsync(int id);
        Task<IEnumerable<RoleModel>> GetAllAsync();
        Task AddAsync(RoleModel role);
        Task UpdateAsync(RoleModel role);
        Task DeleteAsync(int id);
    }
}
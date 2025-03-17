using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface IRoleService
    {
        Task<RoleModel> GetRoleByIdAsync(int id);
        Task<IEnumerable<RoleModel>> GetAllRolesAsync();
        Task AddRoleAsync(RoleModel role);
        Task UpdateRoleAsync(RoleModel role);
        Task DeleteRoleAsync(int id);
    }
}

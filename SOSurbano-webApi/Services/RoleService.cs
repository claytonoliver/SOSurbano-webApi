using SOSurbano_webApi.Data.Repository;
using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<RoleModel> GetRoleByIdAsync(int id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<RoleModel>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllAsync();
        }

        public async Task AddRoleAsync(RoleModel role)
        {
            await _roleRepository.AddAsync(role);
        }

        public async Task UpdateRoleAsync(RoleModel role)
        {
            await _roleRepository.UpdateAsync(role);
        }

        public async Task DeleteRoleAsync(int id)
        {
            await _roleRepository.DeleteAsync(id);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using SOSurbano_webApi.Data.Context;
using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DatabaseContext _context;

        public RoleRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<RoleModel> GetByIdAsync(int id)
        {
            return await _context.Roles
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<RoleModel>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task AddAsync(RoleModel role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RoleModel role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }
    }
}
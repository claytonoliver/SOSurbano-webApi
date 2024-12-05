using Microsoft.EntityFrameworkCore;
using SOSurbano_webApi.Data.Context;
using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DatabaseContext _context;

        public UsuarioRepository(DatabaseContext context)
        {
            _context = context;
        }


        public async Task<UsuarioModel> GetByIdAsync(int id)
        {
            return await _context.Usuarios
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<UsuarioModel>> GetAllAsync()
        {
            return await _context.Usuarios
                .Include(u => u.Role)
                .ToListAsync();
        }

        public async Task AddAsync(UsuarioModel usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UsuarioModel usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
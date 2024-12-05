using Microsoft.EntityFrameworkCore;
using SOSurbano_webApi.Data.Context;
using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Repository
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly DatabaseContext _context;

        public GeneroRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<GeneroModel> GetByIdAsync(int id)
        {
            return await _context.Genero
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<IEnumerable<GeneroModel>> GetAllAsync()
        {
            return await _context.Genero.ToListAsync();
        }

        public async Task AddAsync(GeneroModel genero)
        {
            await _context.Genero.AddAsync(genero);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GeneroModel genero)
        {
            _context.Genero.Update(genero);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var genero = await _context.Genero.FindAsync(id);
            if (genero != null)
            {
                _context.Genero.Remove(genero);
                await _context.SaveChangesAsync();
            }
        }
    }
}
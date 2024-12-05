using Microsoft.EntityFrameworkCore;
using SOSurbano_webApi.Data.Context;
using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Repository
{
    public class StatusChamadoRepository : IStatusChamadoRepository
    {
        private readonly DatabaseContext _context;

        public StatusChamadoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<StatusChamadoModel> GetByIdAsync(int id)
        {
            return await _context.StatusChamado
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<StatusChamadoModel>> GetAllAsync()
        {
            return await _context.StatusChamado.ToListAsync();
        }

        public async Task AddAsync(StatusChamadoModel statusChamado)
        {
            await _context.StatusChamado.AddAsync(statusChamado);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StatusChamadoModel statusChamado)
        {
            _context.StatusChamado.Update(statusChamado);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var statusChamado = await _context.StatusChamado.FindAsync(id);
            if (statusChamado != null)
            {
                _context.StatusChamado.Remove(statusChamado);
                await _context.SaveChangesAsync();
            }
        }
    }
}
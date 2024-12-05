using Microsoft.EntityFrameworkCore;
using SOSurbano_webApi.Data.Context;
using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Repository
{
    public class StatusServicoRepository : IStatusServiceRepository
    {
        private readonly DatabaseContext _context;

        public StatusServicoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<StatusServicoModel> GetByIdAsync(int id)
        {
            return await _context.StatusServico
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<StatusServicoModel>> GetAllAsync()
        {
            return await _context.StatusServico.ToListAsync();
        }

        public async Task AddAsync(StatusServicoModel statusServico)
        {
            await _context.StatusServico.AddAsync(statusServico);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StatusServicoModel statusServico)
        {
            _context.StatusServico.Update(statusServico);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var statusServico = await _context.StatusServico.FindAsync(id);
            if (statusServico != null)
            {
                _context.StatusServico.Remove(statusServico);
                await _context.SaveChangesAsync();
            }
        }
    }
}

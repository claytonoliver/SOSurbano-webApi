using Microsoft.EntityFrameworkCore;
using SOSurbano_webApi.Data.Context;
using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Repository
{
    public class HistoricoServicoStatusRepository : IHistoricoServicoStatusRepository
    {
        private readonly DatabaseContext _context;

        public HistoricoServicoStatusRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<HistoricoServicoStatusModel> GetByIdAsync(int id)
        {
            return await _context.HistoricoServico
                .Include(h => h.VeiculoId)
                .Include(h => h.ChamadoId)
                .Include(h => h.StatusServicoId)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<IEnumerable<HistoricoServicoStatusModel>> GetAllAsync()
        {
            return await _context.HistoricoServico
                .Include(h => h.VeiculoId)
                .Include(h => h.ChamadoId)
                .Include(h => h.StatusServicoId)
                .ToListAsync();
        }

        public async Task AddAsync(HistoricoServicoStatusModel historicoServicoStatus)
        {
            await _context.HistoricoServico.AddAsync(historicoServicoStatus);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(HistoricoServicoStatusModel historicoServicoStatus)
        {
            _context.HistoricoServico.Update(historicoServicoStatus);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var historicoServicoStatus = await _context.HistoricoServico.FindAsync(id);
            if (historicoServicoStatus != null)
            {
                _context.HistoricoServico.Remove(historicoServicoStatus);
                await _context.SaveChangesAsync();
            }
        }
    }
}
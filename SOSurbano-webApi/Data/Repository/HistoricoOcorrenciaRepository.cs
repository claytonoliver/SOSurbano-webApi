using Microsoft.EntityFrameworkCore;
using SOSurbano_webApi.Data.Context;
using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Repository
{
    public class HistoricoOcorrenciaRepository : IHistoricoOcorrenciaRepository
    {
        private readonly DatabaseContext _context;

        public HistoricoOcorrenciaRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<HistoricoOcorrenciaModel> GetByIdAsync(int id)
        {
            return await _context.HistoricoOcorrencia
                .Include(h => h.TipoOcorrenciaId)
                .FirstOrDefaultAsync(h => h.IdOcorrencia == id);
        }

        public async Task<IEnumerable<HistoricoOcorrenciaModel>> GetAllAsync()
        {
            return await _context.HistoricoOcorrencia
                .Include(h => h.TipoOcorrenciaId)
                .ToListAsync();
        }

        public async Task AddAsync(HistoricoOcorrenciaModel historicoOcorrencia)
        {
            await _context.HistoricoOcorrencia.AddAsync(historicoOcorrencia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(HistoricoOcorrenciaModel historicoOcorrencia)
        {
            _context.HistoricoOcorrencia.Update(historicoOcorrencia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var historicoOcorrencia = await _context.HistoricoOcorrencia.FindAsync(id);
            if (historicoOcorrencia != null)
            {
                _context.HistoricoOcorrencia.Remove(historicoOcorrencia);
                await _context.SaveChangesAsync();
            }
        }
    }
}
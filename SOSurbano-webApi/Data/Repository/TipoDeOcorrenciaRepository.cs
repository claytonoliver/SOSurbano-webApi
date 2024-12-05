using Microsoft.EntityFrameworkCore;
using SOSurbano_webApi.Data.Context;
using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Repository
{
    public class TipoDeOcorrenciaRepository : ITipoDeOcorrenciaRepository
    {
        private readonly DatabaseContext _context;

        public TipoDeOcorrenciaRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<TipoDeOcorrenciaModel> GetByIdAsync(int id)
        {
            return await _context.TipoOcorrencia
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<TipoDeOcorrenciaModel>> GetAllAsync()
        {
            return await _context.TipoOcorrencia.ToListAsync();
        }

        public async Task AddAsync(TipoDeOcorrenciaModel tipoDeOcorrencia)
        {
            await _context.TipoOcorrencia.AddAsync(tipoDeOcorrencia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TipoDeOcorrenciaModel tipoDeOcorrencia)
        {
            _context.TipoOcorrencia.Update(tipoDeOcorrencia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tipoDeOcorrencia = await _context.TipoOcorrencia.FindAsync(id);
            if (tipoDeOcorrencia != null)
            {
                _context.TipoOcorrencia.Remove(tipoDeOcorrencia);
                await _context.SaveChangesAsync();
            }
        }
    }
}
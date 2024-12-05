using Microsoft.EntityFrameworkCore;
using SOSurbano_webApi.Data.Context;
using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Repository
{
    public class ChamadoRepository : IChamadoRepository
    {
        private readonly DatabaseContext _context;

        public ChamadoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ChamadoModel> GetByIdAsync(int id)
        {
            return await _context.Chamados
                .Include(c => c.Usuario) 
                .Include(c => c.StatusChamadoId) 
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        // Método para buscar todos os chamados
        public async Task<IEnumerable<ChamadoModel>> GetAllAsync()
        {
            return await _context.Chamados
                .Include(c => c.Usuario) 
                .Include(c => c.StatusChamadoId) 
                .ToListAsync();
        }


        public async Task AddAsync(ChamadoModel chamado)
        {
            await _context.Chamados.AddAsync(chamado);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ChamadoModel chamado)
        {
            _context.Chamados.Update(chamado);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var chamado = await _context.Chamados.FindAsync(id);
            if (chamado != null)
            {
                _context.Chamados.Remove(chamado);
                await _context.SaveChangesAsync();
            }
        }
    }
}
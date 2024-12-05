using Microsoft.EntityFrameworkCore;
using SOSurbano_webApi.Data.Context;
using SOSurbano_webApi.Data.Repository.Interfaces;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly DatabaseContext _context;

        public VeiculoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<VeiculoModel> GetByIdAsync(int id)
        {
            return await _context.Veiculos
                .Include(v => v.StatusServicoId) 
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<VeiculoModel>> GetAllAsync()
        {
            return await _context.Veiculos
                .Include(v => v.StatusServicoId)
                .ToListAsync();
        }

        public async Task AddAsync(VeiculoModel veiculo)
        {
            await _context.Veiculos.AddAsync(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VeiculoModel veiculo)
        {
            _context.Veiculos.Update(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo != null)
            {
                _context.Veiculos.Remove(veiculo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
using MongoDB.Bson;
using SosUrbano.Domain.Entities;

namespace SosUrbano.Application.Services.Interfaces
{
    public interface ITipoDeOcorrenciaService
    {
        Task AddAsync(TipoDeOcorrenciaModel tipoDeOcorrencia);
        Task DeleteAsync(ObjectId id);
        Task<IEnumerable<TipoDeOcorrenciaModel>> GetAllAsync();
        Task<TipoDeOcorrenciaModel> GetByIdAsync(ObjectId id);
        Task UpdateAsync(ObjectId id, TipoDeOcorrenciaModel tipoDeOcorrencia);
    }
}

using MongoDB.Bson;
using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
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

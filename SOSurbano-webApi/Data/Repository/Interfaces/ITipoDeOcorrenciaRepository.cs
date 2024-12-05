using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Data.Repository.Interfaces
{
    public interface ITipoDeOcorrenciaRepository
    {
        Task<TipoDeOcorrenciaModel> GetByIdAsync(int id);
        Task<IEnumerable<TipoDeOcorrenciaModel>> GetAllAsync();
        Task AddAsync(TipoDeOcorrenciaModel tipoDeOcorrencia);
        Task UpdateAsync(TipoDeOcorrenciaModel tipoDeOcorrencia);
        Task DeleteAsync(int id);
    }
}

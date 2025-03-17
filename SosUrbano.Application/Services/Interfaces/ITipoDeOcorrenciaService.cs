using SOSurbano_webApi.Model;

namespace SOSurbano_webApi.Services.Interfaces
{
    public interface ITipoDeOcorrenciaService
    {
        Task<TipoDeOcorrenciaModel> GetTipoDeOcorrenciaByIdAsync(int id);
        Task<IEnumerable<TipoDeOcorrenciaModel>> GetAllTiposDeOcorrenciaAsync();
        Task AddTipoDeOcorrenciaAsync(TipoDeOcorrenciaModel tipoDeOcorrencia);
        Task UpdateTipoDeOcorrenciaAsync(TipoDeOcorrenciaModel tipoDeOcorrencia);
        Task DeleteTipoDeOcorrenciaAsync(int id);
    }
}

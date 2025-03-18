using MongoDB.Driver;
using SosUrbano.Application.Services;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Services
{
    public class TipoDeOcorrenciaService : BaseMongoService<TipoDeOcorrenciaModel>, ITipoDeOcorrenciaService
    {
        public TipoDeOcorrenciaService(IMongoDatabase database) : base(database, "SOU_TIPO_OCORRENCIA")
        {
            
        }
    }
}
using MongoDB.Driver;
using SosUrbano.Application.Services.Interfaces;
using SosUrbano.Domain.Entities;

namespace SosUrbano.Application.Services
{
    public class TipoDeOcorrenciaService : BaseMongoService<TipoDeOcorrenciaModel>, ITipoDeOcorrenciaService
    {
        public TipoDeOcorrenciaService(IMongoDatabase database) : base(database, "SOU_TIPO_OCORRENCIA")
        {
            
        }
    }
}
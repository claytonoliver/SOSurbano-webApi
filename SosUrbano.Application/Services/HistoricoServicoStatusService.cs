using MongoDB.Driver;
using SosUrbano.Application.Services;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Services
{
    public class HistoricoServicoStatusService : BaseMongoService<HistoricoServicoStatusModel>, IHistoricoServicoStatusService
    {
        public HistoricoServicoStatusService(IMongoDatabase database) : base(database, "SOU_HISTORICO_STATUS_SERVICO")
        {
            
        }
    }
}
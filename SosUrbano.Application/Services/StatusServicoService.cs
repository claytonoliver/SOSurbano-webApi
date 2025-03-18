using MongoDB.Driver;
using SosUrbano.Application.Services;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Services
{
    public class StatusServicoService : BaseMongoService<StatusServicoModel>, IStatusServicoService
    {
        public StatusServicoService(IMongoDatabase database) : base (database, "SOU_SERVICO_STATUS")
        {
            
        }
    }
}
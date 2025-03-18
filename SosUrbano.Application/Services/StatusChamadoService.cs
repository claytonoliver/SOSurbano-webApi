using MongoDB.Driver;
using SosUrbano.Application.Services;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Services
{
    public class StatusChamadoService : BaseMongoService<StatusChamadoModel>, IStatusChamadoService
    {
        public StatusChamadoService(IMongoDatabase database) : base(database, "SOU_STATUS_CHAMADO")
        {
            
        }
    }
}

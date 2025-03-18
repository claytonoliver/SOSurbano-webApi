using MongoDB.Driver;
using SosUrbano.Application.Services;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Services
{
    public class ChamadoService : BaseMongoService<ChamadoModel>, IChamadoService
    {
        public ChamadoService(IMongoDatabase database) : base(database, "SOU_Chamado")
        {

        }
    }
}

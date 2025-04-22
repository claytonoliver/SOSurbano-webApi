using MongoDB.Driver;
using SosUrbano.Application.Services;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Services
{
    public class VeiculoService : BaseMongoService<VeiculoModel>, IVeiculoService
    {
        public VeiculoService(IMongoDatabase database) : base(database, "SOU_VEICULO")
        {
            
        }
    }
}

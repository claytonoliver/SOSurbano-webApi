using MongoDB.Driver;
using SosUrbano.Application.Services.Interfaces;
using SosUrbano.Domain.Entities;

namespace SosUrbano.Application.Services
{
    public class VeiculoService : BaseMongoService<VeiculoModel>, IVeiculoService
    {
        public VeiculoService(IMongoDatabase database) : base(database, "SOU_VEICULO")
        {
            
        }
    }
}

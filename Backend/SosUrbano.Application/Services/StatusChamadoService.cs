using MongoDB.Driver;
using SosUrbano.Application.Services.Interfaces;
using SosUrbano.Domain.Entities;

namespace SosUrbano.Application.Services
{
    public class StatusChamadoService : BaseMongoService<StatusChamadoModel>, IStatusChamadoService
    {
        public StatusChamadoService(IMongoDatabase database) : base(database, "SOU_STATUS_CHAMADO")
        {
            
        }
    }
}

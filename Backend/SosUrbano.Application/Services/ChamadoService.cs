using MongoDB.Driver;
using SosUrbano.Application.Services.Interfaces;
using SosUrbano.Domain.Entities;

namespace SosUrbano.Application.Services
{
    public class ChamadoService : BaseMongoService<ChamadoModel>, IChamadoService
    {
        public ChamadoService(IMongoDatabase database) : base(database, "SOU_Chamado")
        {

        }
    }
}

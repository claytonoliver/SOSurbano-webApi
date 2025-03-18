using MongoDB.Bson;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Services
{
    public class ChamadoService : IChamadoService
    {
        Task IChamadoService.AddChamadoAsync(ChamadoModel chamado)
        {
            throw new NotImplementedException();
        }

        Task IChamadoService.DeleteChamadoAsync(ObjectId id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ChamadoModel>> IChamadoService.GetAllChamadosAsync()
        {
            throw new NotImplementedException();
        }

        Task<ChamadoModel> IChamadoService.GetChamadoByIdAsync(ObjectId id)
        {
            throw new NotImplementedException();
        }

        Task IChamadoService.UpdateChamadoAsync(ChamadoModel chamado)
        {
            throw new NotImplementedException();
        }
    }
}

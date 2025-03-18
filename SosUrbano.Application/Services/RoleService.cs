using MongoDB.Driver;
using SosUrbano.Application.Services;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Services
{
    public class RoleService : BaseMongoService<RoleModel>, IRoleService
    {
        public RoleService(IMongoDatabase database) : base(database, "SOU_Role")
        {
            
        }
    }
}
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SOSurbano_webApi.Model
{
    public class RoleModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SOSurbano_webApi.Model
{
    public class GeneroModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("descricao")]
        public string Descricao { get; set; } = string.Empty;
    }
}

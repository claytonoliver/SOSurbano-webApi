using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SOSurbano_webApi.Model
{

    public class TipoDeOcorrenciaModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}

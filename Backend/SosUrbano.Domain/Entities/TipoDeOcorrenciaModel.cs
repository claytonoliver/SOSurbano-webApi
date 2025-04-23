using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SosUrbano.Domain.Entities
{

    public class TipoDeOcorrenciaModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}

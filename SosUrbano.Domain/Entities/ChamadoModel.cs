using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SOSurbano_webApi.Model
{
    public sealed class ChamadoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UsuarioId { get; set; } = string.Empty;

        public string StatusChamado { get; set; } = string.Empty;

        [BsonElement("dataChamado")]
        public DateTime DataChamado { get; set; }

        [BsonElement("descricao")]
        public string Descricao { get; set; } = string.Empty;

        [BsonElement("latitude")]
        public double Latitude { get; set; }

        [BsonElement("longitude")]
        public double Longitude { get; set; }

        [BsonElement("status")]
        public int Status { get; set; }
    }
}

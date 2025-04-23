using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SosUrbano.Domain.Entities
{
    public class VeiculoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string? Placa { get; set; }
        public int StatusServicoId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}

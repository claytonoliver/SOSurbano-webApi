using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SOSurbano_webApi.Model
{
    public class HistoricoServicoStatusModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public int VeiculoId { get; set; }
        public int ChamadoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int StatusServicoId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SOSurbano_webApi.Model
{
    [Table("SOU_VEICULO")]
    public class VeiculoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Placa { get; set; }
        [ForeignKey("SOU_SERVICO_STATUS")]
        public StatusServicoModel StatusServicoId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}

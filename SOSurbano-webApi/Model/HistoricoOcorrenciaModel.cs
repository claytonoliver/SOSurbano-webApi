using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOSurbano_webApi.Model
{
    [Table("SOU_HISTORICO_OCORRENCIA")]
    public class HistoricoOcorrenciaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOcorrencia { get; set; }
        [ForeignKey("SOU_TIPO_OCORRENCIA")]
        public TipoDeOcorrenciaModel TipoOcorrenciaId { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Descricao { get; set; }
    }
}

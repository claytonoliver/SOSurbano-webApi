using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SOSurbano_webApi.Model
{
    [Table("SOU_HISTORICO_STATUS_SERVICO")]
    public class HistoricoServicoStatusModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("SOU_VEICULO")]
        public VeiculoModel VeiculoId { get; set; }
        [ForeignKey("SOU_CHAMADO")]
        public ChamadoModel ChamadoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        [ForeignKey("SOU_SERVICO_STATUS")]
        public StatusServicoModel StatusServicoId { get; set; }
    }
}

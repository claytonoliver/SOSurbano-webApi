using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SOSurbano_webApi.Model
{
    [Table("SOU_TIPO_OCORRENCIA")]
    public class TipoDeOcorrenciaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}

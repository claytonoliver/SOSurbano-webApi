using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SOSurbano_webApi.Model
{
    [Table("SOU_STATUS_CHAMADO")]
    public class StatusChamadoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}

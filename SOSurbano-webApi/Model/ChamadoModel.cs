using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOSurbano_webApi.Model
{
    [Table("SOU_CHAMADO")]
    public class ChamadoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("SOU_USER")]
        public UsuarioModel Usuario { get; set; }
        [ForeignKey("SOU_STATUS_CHAMADO")]
        public StatusChamadoModel StatusChamadoId { get; set; }
        public DateTime DataChamado { get; set; }
        public string Descricao { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}

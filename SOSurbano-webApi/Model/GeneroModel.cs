using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOSurbano_webApi.Model
{
    [Table("SOU_GENERO")]
    public class GeneroModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}

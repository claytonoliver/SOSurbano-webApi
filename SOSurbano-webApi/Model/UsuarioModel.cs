using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOSurbano_webApi.Model
{
    [Table("SOU_USUARIO")]
    public class UsuarioModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
        public string CellPhone { get; set; }
        [ForeignKey("SOU_ROLE")]
        [Column("RoleId")]
        public int RoleId { get; set; }
        public RoleModel Role { get; set; }
    }
}

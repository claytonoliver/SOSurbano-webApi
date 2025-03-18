namespace SOSurbano_webApi.ModelViewModel
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; } // Alterado para DateTime por maior compatibilidade
        public string CellPhone { get; set; }
        public int RoleId { get; set; }
        public string RoleDescricao { get; set; } // Para exibir o nome do papel, se necessário
    }
}

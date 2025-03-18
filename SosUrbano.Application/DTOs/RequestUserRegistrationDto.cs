namespace SosUrbano.Application.DTOs
{
    public class RequestUserRegistrationDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; } = string.Empty;
        public string CellPhone { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public bool Ativo { get; set; }
    }
}

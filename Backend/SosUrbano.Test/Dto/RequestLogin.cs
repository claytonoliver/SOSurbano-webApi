namespace SosUrbano.Test.Dto;

public record RequestLogin
{
    public string CPF { get; set; }
    public string Senha { get; set; }
}

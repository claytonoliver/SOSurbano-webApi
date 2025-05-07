using MongoDB.Bson;
using SosUrbano.Domain.Enums;

namespace SosUrbano.Test.Models;

public record class Usuario
{
    public ObjectId Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public string Senha { get; set; } = string.Empty;
    public string CellPhone { get; set; } = string.Empty;
    public RoleEnum RoleId { get; set; }
    public bool Ativo { get; set; }
    public string Genero { get; set; } = string.Empty;

}

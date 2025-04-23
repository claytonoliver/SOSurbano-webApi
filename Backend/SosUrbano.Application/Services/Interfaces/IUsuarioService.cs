using MongoDB.Bson;
using SosUrbano.Application.DTOs;
using SosUrbano.Domain.Entities;

namespace SosUrbano.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task AddAsync(UsuarioModel usuario);
        Task DeleteAsync(ObjectId id);
        Task<IEnumerable<UsuarioModel>> GetAllAsync();
        Task<UsuarioModel> GetByIdAsync(ObjectId id);
        Task UpdateAsync(ObjectId id, UsuarioModel usuario);
        Task<string> Authenticate(RequestLoginDTO usuario);
    }
}
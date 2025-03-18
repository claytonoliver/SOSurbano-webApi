using MongoDB.Bson;
using MongoDB.Driver;
using SosUrbano.Application.DTOs;
using SOSurbano_webApi.Data.Context;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMongoCollection<UsuarioModel> _usuarios;
        public UsuarioService(MongoDbContext context)
        {
            _usuarios = context.GetCollection<UsuarioModel>("SOU_Usuarios");
        }

        public async Task UserRegisterAsync(RequestUserRegistrationDto usuario)
        {
            var user = new UsuarioModel
            {
                Id = ObjectId.GenerateNewId(),
                Nome = usuario.Nome,
                Email = usuario.Email,
                CPF = usuario.CPF,
                DataNascimento = usuario.DataNascimento,
                Senha = usuario.Senha,
                CellPhone = usuario.CellPhone,
                RoleId = usuario.RoleId,
                Ativo = usuario.Ativo
            };

            await _usuarios.InsertOneAsync(user);
        }

        public Task DeleteUsuarioAsync(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UsuarioModel>> GetAllUsuariosAsync()
        {
            return await _usuarios.Find(_ => true).ToListAsync();
        }

        public async Task<UsuarioModel> GetUsuarioByIdAsync(ObjectId id)
        {
            return await _usuarios.Find(u => u.Id == id).FirstOrDefaultAsync();
        }

        public Task UpdateUsuarioAsync(UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioModel> Authenticate(RequestLoginDTO usuario)
        {
            return await _usuarios.Find(u => u.CPF.Equals(usuario.CPF) && u.Senha.Equals(usuario.Senha)).FirstOrDefaultAsync();
        }
    }
}
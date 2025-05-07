using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using SosUrbano.Test.Models;
using SOSurbano_webApi;
using System.Net.Http.Json;
using System.Text.Json;

namespace SosUrbano.Test.StepDefinitions
{
    [Binding]
    public class RegistroDeNovoUsuarioStepDefinitions
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;
        private HttpResponseMessage _response;
        private Usuario _usuarioPayload;

        public RegistroDeNovoUsuarioStepDefinitions()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [Given("que estou com os dados válidos de um novo usuário")]
        public void GivenQueEstouComOsDadosValidosDeUmNovoUsuario()
        {
            _usuarioPayload = new Usuario
            {
                Id = MongoDB.Bson.ObjectId.GenerateNewId(),
                Nome = "Teste teste",
                Email = $"testeClayton@teste.com",
                CPF = "12345678901",
                DataNascimento = new DateTime(2000, 4, 29),
                Senha = "SenhaForte123!",
                CellPhone = "11999999999",
                RoleId = 0,
                Ativo = true,
                Genero = "Masculino"
            };
        }

        [When("envio uma requisição para a API de registro de usuários")]
        public async Task WhenEnvioUmaRequisicaoParaAAPIDeRegistroDeUsuarios()
        {
            _response = await _client.PostAsJsonAsync("/api/usuario", _usuarioPayload);
        }

        [Then("o sistema deve retornar status {int} CREATED")]
        public void ThenOSistemaDeveRetornarStatusOK(int status)
        {
            ((int)_response.StatusCode).Should().Be(status);
        }

        [Then("o corpo da resposta deve conter o ID do novo usuário")]
        public async Task ThenOCorpoDaRespostaDeveConterOIDDoNovoUsuario()
        {
            var json = await _response.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(json);
            var hasId = doc.RootElement.TryGetProperty("id", out var idProp);

            hasId.Should().BeTrue("a resposta deve conter um campo 'id'");
            idProp.GetString().Should().NotBeNullOrWhiteSpace("o campo 'id' não pode estar vazio");
        }

        [Given("que estou com um novo usuário sem email")]
        public void GivenQueEstouComUmNovoUsuarioSemEmail()
        {
            _usuarioPayload = new Usuario
            {
                Id = MongoDB.Bson.ObjectId.GenerateNewId(),
                Nome = "Teste Sem Email",
                CPF = "12345678901",
                DataNascimento = new DateTime(2000, 4, 29),
                Senha = "SenhaForte123!",
                CellPhone = "11999999999",
                RoleId = 0,
                Ativo = true,
                Genero = "Masculino"
            };
        }

        [Then("o sistema deve retornar status {int} Bad Request")]
        public void ThenOSistemaDeveRetornarStatusBadRequest(int status)
        {
            ((int)_response.StatusCode).Should().Be(status);
        }

        [Given("que já existe um usuário com o email {string}")]
        public async Task GivenQueJaExisteUmUsuarioComOEmail(string email)
        {
            var existente = new Usuario
            {
                Id = MongoDB.Bson.ObjectId.GenerateNewId(),
                Nome = "Usuário Existente",
                Email = email,
                CPF = "11122233344",
                DataNascimento = new DateTime(1995, 1, 1),
                Senha = "SenhaExistente123!",
                CellPhone = "11900001111",
                RoleId = 0,
                Ativo = true,
                Genero = "Outro"
            };

            await _client.PostAsJsonAsync("/api/usuario", existente);
        }

        [Given("estou com um novo usuário usando o mesmo email")]
        public void GivenEstouComUmNovoUsuarioUsandoOMesmoEmail()
        {
            _usuarioPayload = new Usuario
            {
                Id = MongoDB.Bson.ObjectId.GenerateNewId(),
                Nome = "Tentativa Duplicada",
                Email = "admin@teste.com",
                CPF = "55566677788",
                DataNascimento = new DateTime(2000, 10, 10),
                Senha = "SenhaDuplicada123!",
                CellPhone = "11912345678",
                RoleId = 0,
                Ativo = true,
                Genero = "Feminino"
            };
        }

        [Then("o sistema deve retornar status {int} Conflict")]
        public void ThenOSistemaDeveRetornarStatusConflict(int status)
        {
            ((int)_response.StatusCode).Should().Be(status);
        }
    }
}

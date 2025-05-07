using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Reqnroll;
using SOSurbano_webApi;
using SosUrbano.Test.Models;
using SosUrbano.Test.Dto;
using Json.Schema;
using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace SosUrbano.Test.StepDefinitions
{
    [Binding]
    public class LoginUsuarioStepDefinitions
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;
        private HttpResponseMessage _response;
        private RequestLogin _loginPayload;

        public LoginUsuarioStepDefinitions()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [Given("que estou com credenciais válidas")]
        public void GivenQueEstouComCredenciaisValidas()
        {
            _loginPayload = new RequestLogin
            {
                CPF = "12345678901",
                Senha = "Senha123!"
            };
        }

        [When("envio uma requisição de login com as credenciais válidas")]
        public async Task WhenEnvioUmaRequisicaoDeLogin()
        {
            _response = await _client.PostAsJsonAsync("/api/auth/login", _loginPayload);
        }

        [Then("o sistema deve retornar status {int} OK")]
        public void ThenOSistemaDeveRetornarStatus200OK(int statusCode)
        {
            ((int)_response.StatusCode).Should().Be(statusCode);
        }

        [Then("o corpo da resposta deve conter o token JWT")]
        public async Task ThenOCorpoDaRespostaDeveConterOTokenJWT()
        {
            var content = await _response.Content.ReadFromJsonAsync<ResponseLogin>();
            content.Token.Should().NotBeNullOrWhiteSpace();
        }

        [Then("a resposta deve seguir o contrato do login")]
        public async Task ThenARespostaDeveSeguirOContratoDoLogin()
        {
            var content = await _response.Content.ReadAsStringAsync();
            var jsonNode = JsonNode.Parse(content); // CORREÇÃO AQUI!

            var schema = new JsonSchemaBuilder()
                .Type(SchemaValueType.Object)
                .Properties(
                    ("token", new JsonSchemaBuilder().Type(SchemaValueType.String))
                )
                .Required("token");
                var result = schema.Evaluate(jsonNode);
            result.IsValid.Should().BeTrue("o JSON deve seguir o contrato esperado com o campo 'token'");
        }
    }
}

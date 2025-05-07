using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Reqnroll;
using SOSurbano_webApi;
using SosUrbano.Application.DTOs;
using SosUrbano.Test.Helpers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using Json.Schema;
using SosUrbano.Test.Helpers.SosUrbano.Test.Helpers;
using SosUrbano.Test.Dto;

namespace SosUrbano.Test.StepDefinitions
{
    [Binding]
    public class ChamadoStepDefinitions
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;
        private RequestChamado _novoChamado;
        private HttpResponseMessage _response;
        private RequestLogin _loginPayload;

        public ChamadoStepDefinitions()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [Given("que estou autenticado como administrador")]
        public async Task Autenticar()
        {

            _loginPayload = new RequestLogin
            {
                CPF = "12345678901",
                Senha = "Senha123!"
            };
            await AuthHelper.AutenticarComoAsync(_client, _loginPayload);
        }

        [Given("tenho os dados válidos de um novo chamado")]
        public void GivenTenhoOsDadosValidosDeChamado()
        {
            _novoChamado = new RequestChamado
            {
                UsuarioId = MongoDB.Bson.ObjectId.GenerateNewId().ToString(),
                StatusChamado = "1",
                DataChamado = DateTime.UtcNow,
                Descricao = "Chamado de teste gerado via BDD",
                Latitude = -23.5505,
                Longitude = -46.6333,
                Status = 1,
            };
        }

        [When("Quando envio uma requisição POST para (.+)")]
        public async Task WhenEnvioRequisicaoPostChamado(string endpoint)
        {
            _response = await _client.PostAsJsonAsync(endpoint, _novoChamado);
        }

        [Then("o corpo da resposta deve conter o ID do chamado")]
        public async Task ThenOCorpoDaRespostaDeveConterId()
        {
            var json = await _response.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(json);

            doc.RootElement.TryGetProperty("id", out var idProp).Should().BeTrue();
            idProp.GetString().Should().NotBeNullOrWhiteSpace();
        }

        [Then("a resposta deve seguir o contrato do chamado")]
        public async Task ThenARespostaDeveSeguirContrato()
        {
            var json = await _response.Content.ReadAsStringAsync();
            var node = JsonNode.Parse(json);

            var schema = new JsonSchemaBuilder()
                .Type(SchemaValueType.Object)
                .Properties(
                    ("id", new JsonSchemaBuilder().Type(SchemaValueType.String))
                )
                .Required("id");

            var result = schema.Evaluate(node);
            result.IsValid.Should().BeTrue("a resposta deve seguir o contrato do chamado");
        }


        [Then(@"o sistema deve retornar status (\d+) (.*)")]
        public void ThenSistemaDeveRetornarStatus(int status, string descricao)
        {
            ((int)_response.StatusCode).Should().Be(status, $"esperado: {status} {descricao}");
        }
    }
}

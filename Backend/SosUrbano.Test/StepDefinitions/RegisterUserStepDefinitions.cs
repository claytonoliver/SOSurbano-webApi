using System;
using Reqnroll;

namespace SosUrbano.Test.StepDefinitions
{
    [Binding]
    public class RegisterUserStepDefinitions
    {
        [Then("o sistema deve retornar status {int} Created")]
        public void ThenOSistemaDeveRetornarStatusCreated(int p0)
        {
            throw new PendingStepException();
        }

        [Then("o corpo da resposta deve conter o ID do novo usuário")]
        public void ThenOCorpoDaRespostaDeveConterOIDDoNovoUsuario()
        {
            throw new PendingStepException();
        }
    }
}

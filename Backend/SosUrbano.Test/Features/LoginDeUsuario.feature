#language: pt
Funcionalidade: Login de usuário

@tag
  Cenário: Usuário realiza login com sucesso
    Dado que estou com credenciais válidas
	Quando envio uma requisição de login com as credenciais válidas
    Então o sistema deve retornar status 200 OK
    E o corpo da resposta deve conter o token JWT
    E a resposta deve seguir o contrato do login

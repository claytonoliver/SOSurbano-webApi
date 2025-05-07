#language: pt
Funcionalidade: Registro de novo usuário
  Como um visitante da API
  Quero registrar novos usuários
  Para que possam acessar o sistema

  @tag1
  Cenário: Usuário se registra com sucesso
    Dado que estou com os dados válidos de um novo usuário
    Quando envio uma requisição para a API de registro de usuários
    Então o sistema precisa retornar status 201 CREATED
    E o corpo da resposta precisa conter o ID do novo usuário

  Cenário: Usuário tenta se registrar sem email
    Dado que estou com um novo usuário sem email
    Quando envio uma requisição para a API de registro de usuários
    Então o sistema precisa retornar status 400 Bad Request

  Cenário: Usuário tenta se registrar com email já utilizado
    Dado que já existe um usuário com o email "testeClayton@teste.com"
    E estou com um novo usuário usando o mesmo email
    Quando envio uma requisição para a API de registro de usuários
    Então o sistema precisa retornar status 409 Conflict

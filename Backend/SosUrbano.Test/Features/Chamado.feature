#language: pt
Funcionalidade: Chamado


Cenário: Criar um novo chamado com sucesso
  Dado que estou autenticado como administrador
  E tenho os dados válidos de um novo chamado
  Quando Quando envio uma requisição POST para /api/chamado
  Então o sistema deve retornar status 201 Created
  E o corpo da resposta deve conter o ID do chamado
  E a resposta deve seguir o contrato do chamado

#language: pt
Funcionalidade: RegisterUser

@tag1
Cenário: Usuário se registra com sucesso
    Dado que estou na API de registro de usuários
    Quando envio os dados válidos de um novo usuário
    Então o sistema deve retornar status 201 Created
    E o corpo da resposta deve conter o ID do novo usuário
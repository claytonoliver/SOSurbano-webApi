# SOSurbano-webApi

## Visão Geral
O **SOSurbano-webApi** é uma API desenvolvida para gerenciar operações relacionadas a serviços urbanos, como chamados de ocorrências, histórico de status e gerenciamento de usuários e veículos. 

Originalmente, o sistema utilizava o banco de dados **Oracle**, mas foi migrado para o **MongoDB** visando melhorias de performance e escalabilidade.

## Estrutura do Projeto
O projeto está organizado nas seguintes camadas, seguindo os princípios da **Clean Architecture**:

- **SosUrbano.Application**: Contém a lógica de aplicação e os casos de uso.
- **SosUrbano.Domain**: Define as entidades e interfaces de repositório.
- **SosUrbano.Infraestructure**: Implementa os repositórios e a comunicação com o banco de dados MongoDB.

## Collections Utilizadas
Foram criadas as seguintes collections no **MongoDB**:

- `SOU_Genero`: Armazena informações sobre os gêneros dos usuários.
- `SOU_Usuarios`: Contém dados dos usuários do sistema.
- `SOU_Chamado`: Registra os chamados de ocorrências urbanas.
- `SOU_HISTORICO_OCORRENCIA`: Guarda o histórico das ocorrências registradas.
- `SOU_HISTORICO_STATUS_SERVICO`: Armazena o histórico de status dos serviços.
- `SOU_ROLE`: Define as permissões e papéis dos usuários.
- `SOU_STATUS_CHAMADO`: Contém os possíveis status dos chamados.
- `SOU_SERVICO_STATUS`: Registra os status dos serviços disponíveis.
- `SOU_TIPO_OCORRENCIA`: Define os tipos de ocorrências possíveis.
- `SOU_VEICULO`: Armazena informações sobre os veículos cadastrados.

## Tecnologias Utilizadas
- **.NET Core**: Framework para desenvolvimento da API.
- **MongoDB**: Banco de dados NoSQL utilizado para armazenar os dados.
- **Docker**: Utilizado para containerização da aplicação.

## Como Executar o Projeto

### Pré-requisitos:
- **Docker** instalado na máquina.
- **MongoDB** em execução (pode ser via Docker).

### Clonar o Repositório:
```bash
 git clone https://github.com/claytonoliver/SOSurbano-webApi.git
```

### Navegar até o Diretório do Projeto:
```bash
 cd SOSurbano-webApi
```

### Construir a Imagem Docker:
```bash
 docker build -t sosurbano-webapi .
```

### Executar o Container:
```bash
 docker run -d -p 5000:80 sosurbano-webapi
```

### Executar o Container do MongoDB para Testes:
```bash
 docker run -d -p 27017:27017 --name mongo-test mongo
```

### Acessar a API:
A API estará disponível em: [http://localhost:5000](http://localhost:5000)

### Testes Automatizados

Para configurar e executar os testes automatizados (BDD/Reqnroll):

1. Pré-requisitos:

 - Projeto de testes baseado em .NET 6.

 - Container MongoDB em execução (mongo-test).

2. Configurar string de conexão:

 - No arquivo appsettings.Test.json, ajuste a conexão para mongodb://localhost:27017.

3. Executar testes localmente:
   
    # Na raiz do projeto de testes
 cd SosUrbano.Test
 dotnet test SosUrbano.Test.csproj

 4. Execução em CI/CD:

Insira no pipeline o passo:

- name: Run API Tests
  run: |
    cd SosUrbano.Test
    dotnet test SosUrbano.Test.csproj

Evidências de execução serão exibidas no console ou no relatório HTML gerado pelo Reqnroll.


## Contribuições
Contribuições são bem-vindas! Sinta-se à vontade para abrir **issues** e **pull requests** no repositório do projeto.

# Microservices-API — E-commerce de exemplo (C#/.NET)

Solução em **microsserviços** para um domínio simples de e-commerce. Inclui um **API Gateway** e três serviços independentes (**Produtos**, **Pedidos** e **Clientes**) além de uma biblioteca de **objetos de domínio/DTOs** compartilhados. Foco em separação de responsabilidades, baixo acoplamento e facilidade de evolução.

---

## Sumário
- Visão geral da arquitetura
- Estrutura do repositório
- Tecnologias
- Como executar localmente
- Rotas e exemplos
- Padrões e decisões

---

## Visão geral da arquitetura

- API Gateway faz a orquestração/roteamento das chamadas do cliente para os serviços internos.
- Cada serviço é um processo independente, com **Web API** própria, ciclo de vida e deploy isolado.
- Contratos/DTOs e enums comuns ficam centralizados em **BusinessObjects**, evitando duplicação.
- Comunicação por HTTP (REST) de forma simples para fins didáticos; mensageria pode ser adicionada no futuro.

---

## Estrutura do repositório

Microservices-API.sln  
├─ BusinessObjects/        — Entidades, DTOs, contratos e utilitários compartilhados  
├─ Ecommerce-APIGateway/   — Ponto único de entrada; roteamento e agregação  
├─ ProductService/         — CRUD e consultas de produtos  
├─ OrderService/           — Ciclo de vida de pedidos (abertura, listagem etc.)  
└─ CustomerService/        — Cadastro e gestão de clientes

---

## Tecnologias

- .NET (Web API)
- ASP.NET Core Minimal/Controllers
- Swagger/OpenAPI
- Injeção de Dependência (DI) nativa
- Serialização JSON (System.Text.Json)

---

## Como executar localmente

Pré-requisitos:
- SDK do .NET instalado
- Git instalado

Passo a passo:
1) Clonar o repositório: `git clone https://github.com/brunostan/Microservices-API.git`  
2) Restaurar e compilar: `dotnet restore` e depois `dotnet build -c Release` na raiz  
3) Executar cada serviço em terminais separados usando `dotnet run` dentro de:
   - `ProductService`
   - `OrderService`
   - `CustomerService`
   - `Ecommerce-APIGateway`
4) Acessar a documentação Swagger de cada serviço pelo endereço exibido no console ao subir (ex.: `http://localhost:{porta}/swagger`).

---

## Rotas e exemplos

ProductService (exemplos):
- GET `/api/products` — lista produtos
- GET `/api/products/{id}` — detalhe
- POST `/api/products` — cria
- PUT `/api/products/{id}` — atualiza
- DELETE `/api/products/{id}` — remove

CustomerService (exemplos):
- GET `/api/customers`
- GET `/api/customers/{id}`
- POST `/api/customers`
- PUT `/api/customers/{id}`
- DELETE `/api/customers/{id}`

OrderService (exemplos):
- GET `/api/orders`
- GET `/api/orders/{id}`
- POST `/api/orders` — cria pedido
- PUT `/api/orders/{id}` — atualiza status/itens

Ecommerce-APIGateway (exemplos):
- Reescreve/encaminha chamadas do cliente para os serviços internos, preservando contratos.
- Rotas de fachada como `/api/products`, `/api/customers`, `/api/orders` são roteadas aos respectivos serviços.

---

## Padrões e decisões

- Camadas independentes por serviço; contratos comuns em BusinessObjects para evitar duplicação.
- DI nativa para manter baixo acoplamento e facilitar testes.
- Endpoints REST simples, com Swagger ativado por padrão.
- Logging básico via `ILogger<T>`; extensível para observabilidade futura.

---

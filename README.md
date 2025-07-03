# 🧁 Project Alfajor - API de Controle de Vendas Pessoais

Este é um projeto pessoal criado para organizar e gerenciar as **vendas de alfajor** que faço no meu curso. A ideia é usar esse projeto como forma de **aprender, treinar e evoluir** meus conhecimentos em backend com .NET.

## 📌 Objetivos do Projeto

- Cadastrar produtos comprados (com nome, valor e data)
- Registrar vendas diárias (quantidade vendida, sobra e valor recebido)
- Controlar clientes que compraram fiado (e se já pagaram ou não)
- API feita para **uso pessoal**, mas pensada com estrutura profissional

---

## 🔧 Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/en-us/download)
- ASP.NET Core Web API
- Entity Framework Core
- SQLite (banco de dados local) Para visualizar o banco de dados, recomendo usar o DB Browser (SQLite) ou uma extensão SQLite.
- Visual Studio

---

## 📂 Estrutura do Projeto

- `Models/` → contém as entidades (Product, DailySale, CreditCustomer)
- `Controllers/` → responsáveis pelos endpoints da API
- `Data/` → contexto do banco de dados (`AppDbContext`)
- `Program.cs` → configuração do app
- `Migrations/` → versões do banco de dados geradas via EF Core

---

## 📫 Endpoints da API

### `/api/products`
- `GET` → lista todos os produtos
- `GET /{id}` → busca produto pelo ID
- `POST` → cria um novo produto
- `PUT /{id}` → atualiza produto pelo ID
- `DELETE /{id}` → deleta produto pelo ID

### `/api/dailysale`
- `GET` → lista todas as vendas diárias
- `GET /{id}` → busca venda diária pelo ID
- `POST` → registra uma nova venda
- `PUT /{id}` → atualiza uma venda existente
- `DELETE /{id}` → remove uma venda

### `/api/creditcustomer`
- `GET` → lista todos os clientes fiado
- `GET /NotPaid` → lista apenas os que **não pagaram**
- `GET /isPaid` → lista apenas os que **já pagaram**
- `GET /{id}` → busca um cliente pelo ID
- `POST` → registra novo cliente fiado
- `PUT /{id}` → atualiza status para "pago"
- `DELETE /{id}` → remove o cliente

---

## 💻 Como rodar o projeto

1. Clone o repositório:
```bash
git clone https://github.com/Fillipinh0/ProjectAlfajor.git

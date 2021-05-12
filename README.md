# Teste pr�tico Dog And Peoples

# Criado projeto com estrutura base (DDD)
# Tecnologias:
- ASP.NET MVC
- Framework 4.6.1
- DataTable pra listar os dados 
- Bootstrap v3.4.1
- Dapper
- DependencyInjection 5.0.1

# Estrutura do projeto
- Web - WebApplication
- Application - Class Library
- Domain - Class Library
- Infra Data - Class Library
- Infra IoC - Class Library

# Web
- Website/Administrativo para gerenciar os cadastros de c�es e seus devidos donos

# Application
- A regra de neg�cio ficou na application
- Validar os campos Nome, Ra�a e Nome do dono, como obrigat�rio
- Criado o filtro por nome do c�o e ra�a, por�m o filtro final ficou direto na tela usando o DataTable
- Criado o CRUD - Listar, Obter, Adicionar, Remover e Atualizar dados

# Domain
- Definido as entidades
- Criado as interfaces da Application e Repository

# Infra - Data
- Conex�o e acesso com o banco de dados
- Utilizado o ORM Dapper para gerenciar os acessos a dados

# Infra - IoC
- Criado a inje��o de depend�ncia com o DependencyInjection

# Scripts
- Criado um TXT com o script para criar as tables do banco de dados 
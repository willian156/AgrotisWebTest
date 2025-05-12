# AgrotisWebTest 🌱

Este sistema foi desenvolvido como parte do processo seletivo da **Agrotis**.  
Ele consiste em telas para **cadastro**, **visualização**, **atualização** e **remoção** de **Clientes**, **Produtos** e **Pedidos**.

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core com .NET 8
- SQL Server
- Entity Framework Core
- Razor Pages (Views com `.cshtml`)
- DotNetEnv (para uso de variáveis de ambiente com `.env`)

---

## 🚀 Como executar o projeto

### Pré-requisitos

Certifique-se de que os seguintes softwares estejam instalados na sua máquina:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) com a carga de trabalho **ASP.NET e desenvolvimento web**
- [Git](https://git-scm.com/)

---

### 🔄 Clonando o repositório

```bash
git clone https://github.com/seu-usuario/AgrotisWebTest.git
cd AgrotisWebTest
```
###⚙️ Configuração do ambiente
Crie um arquivo .env na raiz do projeto com o seguinte conteúdo:

```bash
DB_CONN=Server=SEU_SERVIDOR;Database=AgrotisWebTestDb;User Id=SEU_USUARIO;Password=SUA_SENHA;TrustServerCertificate=True;
```
🧪 Nota: o projeto utiliza o pacote NuGet DotNetEnv para ler variáveis do arquivo .env.
Esse pacote é importado no DatabaseContext.cs para carregar a string de conexão.

### 📦 Restaurando os pacotes NuGet

```bash
dotnet restore
```
### 🗄️ Criando o banco de dados
Aplique as migrations existentes com:

```bash
dotnet ef database update
```
Isso criará o banco de dados e suas tabelas com base no seu modelo atual.

### ▶️ Executando o projeto
Para iniciar o servidor web local:
```bash
dotnet run
```
Depois, acesse no navegador:
```bash
http://localhost:7172
```
### 🧭 Navegação no sistema

O sistema está dividido em três áreas principais:

-Customers

--➕ Create new

--📄 List

-Products

--➕ Create new

--📄 List

-Orders

--➕ Create new

--📄 List

A Home apresenta uma tela centralizada com os botões de acesso para cada funcionalidade.
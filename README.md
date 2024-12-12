# **Especificação do Desafio**
O desafio é criar um sistema financeiro para gerenciar depósitos, compras e vendas de Bitcoin. Ele deve permitir cadastro e login com JWT, consulta de saldo, cotação em tempo real, e posição de investimentos. Transações, como depósitos e vendas, enviam notificações por e-mail. Também inclui histórico de cotações e relatórios de operações com intervalos customizáveis. A base de dados pode ser MariaDB, PostgreSQL ou MongoDB.
### **1. Contas**
- Deve permitir cadastro (nome, e-mail e senha) e login utilizando **token JWT**.
- Todos os endpoints, exceto login e cadastro, exigem autenticação.
### **2. Depósitos**
- O cliente pode fazer depósitos em reais na plataforma (apenas registro do valor, sem transferência real).
- Após o depósito, um e-mail deve ser enviado informando o valor depositado.
### **3. Saldo**
- É necessário um endpoint para consultar o saldo disponível em reais na conta do cliente.
### **4. Cotação**
- O cliente deve visualizar a cotação atual do **Bitcoin** (compra e venda).
### **5. Compra**
- O cliente pode comprar bitcoins utilizando o saldo disponível na conta.
- O valor em reais será convertido pela cotação de venda.
- Um e-mail deve ser enviado informando:
  - Valor investido em R$.
  - Valor comprado em BTC.
### **6. Posição dos Investimentos**
- O cliente deve visualizar suas posições de investimento com as seguintes informações:
  - Data da compra.
  - Valor investido.
  - Cotação do BTC no momento da compra.
  - Percentual de variação do preço do BTC.
  - Valor bruto atual do investimento.
### **7. Venda**
- O cliente pode vender bitcoins:
  - O valor será debitado dos investimentos pela ordem de compra (FIFO).
  - O dinheiro será creditado na conta da plataforma.
- Em caso de venda parcial:
  - O investimento deve ser liquidado completamente.
  - Valor residual deve ser reinvestido na cotação original do BTC.
  - Ambas as transações devem constar no extrato.
- Um e-mail deve ser enviado informando:
  - Valor vendido em BTC.
  - Valor resgatado em R$.
### **8. Extrato**
- O cliente pode listar depósitos, compras e resgates com:
  - Datas.
  - Cotações.
- Intervalo: últimos 90 dias ou intervalo customizado.
### **9. Volume**
- Um endpoint deve retornar o total de bitcoins comprados e vendidos no dia atual.
### **10. Histórico**
- Endpoint com histórico de compra/venda do Bitcoin com:
  - Frequência: 10 minutos (ex.: 8:00, 8:10, 8:20).
  - Período: últimas 24 horas.
- Dados com mais de 90 dias devem ser expurgados automaticamente.
---
# **Solução**

## **IDE's Utilizadas**
- Visual Studio 2022
- PostgreSQL
- Postman

---

## **Recursos do Projeto**
- **Serilog**: Para geração e gerenciamento de logs.
- **FluentValidator**: Para validação de dados e regras de negócios.
- **Entity Framework (ORM)**: Para mapeamento e interação com o banco de dados.
- **Unit of Work**: Padrão de design para gerenciar transações e persistência de dados de forma coesa.
- **Migrations**: Gerenciamento de alterações no banco de dados.
- **Swagger**: Para documentação e teste interativo dos endpoints da API.
- **xUnit**: Framework para testes unitários, promovendo simplicidade, flexibilidade e paralelismo.
- **Moq**: Biblioteca para criação de mocks, facilitando a simulação de comportamentos e dependências em testes unitários.

---

## **Como Executar o Projeto**

### **1. Configuração Inicial do Banco de Dados**
1. Faça o clone do projeto e use a IDE que for de sua preferência.
2. Verifique se a pasta `Migrations` no projeto está vazia. Caso contrário, delete todos os arquivos dessa pasta.
   
3. Execute os seguintes comandos no **Package Manager Console**:
   - Certifique-se de selecionar o projeto relacionado ao banco de dados no menu "Default project".
   - Execute:
     ```bash
     add-migration PrimeiraMigracao
     update-database
     ```
   - Isso criará e configurará o banco de dados no PostgreSQL.

---

### **2. Executando o Projeto**
1. Abra o projeto no Visual Studio 2022.
2. Configure o projeto principal para execução:
   - Clique com o botão direito no projeto **TestWebBackEndDeveloper** e selecione `Set as Startup Project`.
3. Clique no botão **HTTPS** no menu superior para iniciar a aplicação.

**Observações:**
- Caso seu antivírus exiba alertas ao executar o projeto, será necessário fechar esses avisos para continuar.
- Durante a execução, um console será aberto para a geração de logs. Caso queira, você pode fechá-lo sem impactar a execução do sistema.

### **3. Configurando o Postman**

### **4. Banco de Dados**

- **Centralização de Exceções:**  
  Implementada a classe `ExceptionMiddleware` para unificar o tratamento de erros no sistema.

- **Alterações Realizadas:**  
  Ajustadas as classes `Program` e `RepositoryUoW` para integrar o middleware.

- **Mensagens de Erro:**  
  - Se o banco de dados não existir, os endpoints retornam:  
    ```text
    The database is currently unavailable. Please try again later.
    ```
  - Para erros inesperados na criação do banco, é exibido:  
    ```text
    An unexpected error occurred. Please contact support if the problem persists.
    ```

---

### **4. Configuração do Log**
- O sistema gera logs diários com informações sobre os processos executados no projeto.
- O log será salvo no diretório:  
  `C://Users//User//Downloads//logs`.  
  **Nota**: É necessário criar a pasta manualmente nesse caminho ou alterar o diretório no código, caso deseje personalizá-lo.

**Formato do arquivo de log criado**:
- Arquivo diário com informações estruturadas.

---

### **5. Finalização**
Após seguir as etapas anteriores, o sistema será iniciado, e uma página com a interface **Swagger** será aberta automaticamente no navegador configurado no Visual Studio. Essa página permitirá explorar e testar os endpoints da API.

---

## **Estrutura do Projeto**
Essa estrutura garante organização, modularidade e escalabilidade ao projeto.
### **1. TestWebBackEndDeveloper (API)**
Contém os endpoints para acesso e execução das funcionalidades:
1. Organização das pastas:
- **Controllers**: Controladores da aplicação.
- **Extensions**:  
  - SwaggerDocumentation: Documentação do swagger.
  - ExtensionsLogs:       Classe para gerar logs.
  - ExceptionMiddleware classe para tratar erro de conexão com o banco de dados.
  - Extensões para a classe `Program`.
- **Appsettings**: Configurações, incluindo conexão com o banco de dados.
- **Program**: Classe principal para inicialização.

---

### **2. TestWebBackEndDeveloper.Application**
Camada intermediária entre os controladores e o banco de dados. Responsável também por funções específicas, como envio de e-mails.
1. Organização das pastas:
- **ExtensionError**: Contém a classe `Result` para controle de erros, usando FluentValidator.
- **Services**: Contém as classes de serviços e interfaces.
- **UnitOfWork**: Implementação do padrão **Unit of Work**, que gerencia transações e persistência de dados.

---

### **3. TestWebBackEndDeveloper.Domain**
Camada de domínio, responsável pelos dados principais do sistema.
1. Organização das pastas:
- **Entity**: Contém as entidades do projeto.
- **Enum**: Contém enums utilizados no projeto.
- **General**: Contém classes genéricas, incluindo a `BaseEntity`, com propriedades comuns às entidades.

---

### **4. TestWebBackEndDeveloper.Infrastructure**
Camada responsável pela interação com o banco de dados.
1. Organização das pastas:
- **Connection**: Configuração de conexão e mapeamento das entidades para o Entity Framework.
- **Migrations**: Diretório onde as migrations geradas serão armazenadas.
- **Repository**: Contém repositórios e suas interfaces.

---

### **5. TestWebBackEndDeveloper.Shared**
Biblioteca utilizada para validações e compartilhamento de recursos comuns:
1. Organização das pastas:
- **Enums**: Classes de enums para erros.
- **Helpers**: Classe auxiliar para validação de erros.
- **Validator**: Regras de validação para as entidades.

---

### **6. TestWebBackEndDeveloper.Tests**
Biblioteca destinada à criação e execução de testes automatizados para garantir a qualidade e confiabilidade do sistema:
- **xUnit**: Garante a qualidade do código ao permitir a criação de testes unitários eficientes e de fácil manutenção.
- **Moq**: Permite simular objetos e comportamentos, eliminando a necessidade de criar implementações reais para dependências durante os testes.
1. Organização das pastas:
- **DomainTests**: Contém as classes de testes para as entidades.
---

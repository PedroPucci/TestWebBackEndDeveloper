# **TestWebBackEndDeveloper**

## **IDE's Utilizadas**
- Visual Studio 2022
- PostgreSQL

---

## **Recursos do Projeto**
- **Serilog**: Para geração e gerenciamento de logs.
- **FluentValidator**: Para validação de dados e regras de negócios.
- **Entity Framework (ORM)**: Para mapeamento e interação com o banco de dados.
- **Unit of Work**: Padrão de design para gerenciar transações e persistência de dados de forma coesa.
- **Migrations**: Gerenciamento de alterações no banco de dados.

---

## **Como Executar o Projeto**

### **1. Configuração Inicial do Banco de Dados**
1. Verifique se a pasta `Migrations` no projeto está vazia. Caso contrário, delete todos os arquivos dessa pasta.
   
2. Execute os seguintes comandos no **Package Manager Console**:
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

---

### **3. Configuração do Log**
- O sistema gera logs diários com informações sobre os processos executados no projeto.
- O log será salvo no diretório:  
  `C://Users//User//Downloads//logs`.  
  **Nota**: É necessário criar a pasta manualmente nesse caminho ou alterar o diretório no código, caso deseje personalizá-lo.

**Formato do arquivo de log criado**:
- Arquivo diário com informações estruturadas.

---

### **4. Finalização**
Após seguir as etapas anteriores, o sistema será iniciado, e uma página com a interface **Swagger** será aberta automaticamente no navegador configurado no Visual Studio. Essa página permitirá explorar e testar os endpoints da API.

---

## **Estrutura do Projeto**

### **1. TestWebBackEndDeveloper (API)**
Contém os endpoints para acesso e execução das funcionalidades:
- **Controllers**: Controladores da aplicação.
- **Extensions**:  
  - Classe para gerar logs.  
  - Extensões para a classe `Program`.
- **Appsettings**: Configurações, incluindo conexão com o banco de dados.
- **Program**: Classe principal para inicialização.

---

### **2. TestWebBackEndDeveloper.Application**
Camada intermediária entre os controladores e o banco de dados. Responsável também por funções específicas, como envio de e-mails.
- **ExtensionError**: Contém a classe `Result` para controle de erros, usando FluentValidator.
- **Services**: Contém as classes de serviços e interfaces.
- **UnitOfWork**: Implementação do padrão **Unit of Work**, que gerencia transações e persistência de dados.

---

### **3. TestWebBackEndDeveloper.Domain**
Camada de domínio, responsável pelos dados principais do sistema.
- **Entity**: Contém as entidades do projeto.
- **Enum**: Contém enums utilizados no projeto.
- **General**: Contém classes genéricas, incluindo a `BaseEntity`, com propriedades comuns às entidades.

---

### **4. TestWebBackEndDeveloper.Infrastructure**
Camada responsável pela interação com o banco de dados.
- **Connection**: Configuração de conexão e mapeamento das entidades para o Entity Framework.
- **Migrations**: Diretório onde as migrations geradas serão armazenadas.
- **Repository**: Contém repositórios e suas interfaces.

---

### **5. TestWebBackEndDeveloper.Shared**
Biblioteca utilizada para validações e compartilhamento de recursos comuns:
- **Enums**: Classes de enums para erros.
- **Helpers**: Classe auxiliar para validação de erros.
- **Validator**: Regras de validação para as entidades.

---

Essa estrutura garante organização, modularidade e escalabilidade ao projeto.

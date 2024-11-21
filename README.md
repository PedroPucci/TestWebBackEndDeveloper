# TestWebBackEndDeveloper

# IDE's utilizadas
- Visual Studio 2022
- PostgreSQL

# O que tem no projeto
- SerialLog
- FluentValidator
- ORM Entity Framework
- Unit of Work
- Migrations

# Como executar o projeto
Quando baixar o projeto, é preciso rodar as migrations. Para isso execute os passos abaixo:

1. Verifique no projeto que a pasta Migrations esteja vazia, caso contrário delete todos os arquivos da pasta.
![image](https://github.com/user-attachments/assets/58d90e48-a7a3-4ee2-a1ef-3fbec12e0ea1)

2. Precisa executar os seguintes comandos, dentro de Package Manager Console:

  ![image](https://github.com/user-attachments/assets/16815e76-ed94-455a-8326-d25f7e88a2e1)

  Aqui deve escolher a library referente ao banco de dados, dentro de "Default project"
  ![image](https://github.com/user-attachments/assets/897f2db9-e5cc-4f51-a673-59bc392f8209)
Executar os seguintes comandos:
- add-migration PrimeiraMigracao
- update-database
Dessa forma o banco será criado no PostgreSQL

Utilizando o Visual Studio 2022
Com o projeto aberto, selecionar como projeto para executar, o projeto: TestWebBackEndDeveloper. Para fazer isso clique com o botão direito e selecione a opção "Set as Startup Project".
![image](https://github.com/user-attachments/assets/bab5bb84-782f-407a-a585-6def3ac808ec)

Em seguida, clicar no botão https que se localiza no menu superior.
![image](https://github.com/user-attachments/assets/b43741fd-2713-44e6-8385-d64f6c1d5bba)

- Observação: Caso tenha algum antivírus instalado, pode ser que aconteça um alerta na hora de executar o projeto, precisando fechar o mesmo.
- Observação: O projeto tem a execução de uma rotina de criação de logs, dessa forma será aberto o console para o log no caso pode fechar.
 
Para a criação do log

Na criação do log, foi feita para criar um arquivo diário com as informações que estão sendo processas no projeto.
Essa informação no projeto está criada no seguinte path: C://Users//User//Downloads//logs. Para que seja executado o log, precisa criar uma pasta nesse caminho. Porém, fica a critério caso queira trocar o path e/ou a pasta.
Formato do arquivo log criado:

![image](https://github.com/user-attachments/assets/a024ef70-dee5-45d5-9b67-0e77ca5eba90)

No final de todas as etapas anteriores, a pasta log com seu arquivo será criado e alimentado na medida que o sistema for sendo utilizado e será aberto no navegador de sua escolha dentro do Visual Studio uma pagina com o Swagger do projeto

# Organização do projeto

O projeto foi criado da seguinte forma:

1. TestWebBackEndDeveloper que é referente a API e que possui os endpoints para serem acessadas.
- Controllers
- Extensions com a classe para gerar o log e a classe de extensão da classe Program
- Appsettings que terá as informações para acessar o banco de dados
- A Classe Program

2. TestWebBackEndDeveloper.Application é a library que foi criada para ser responsável por ser a intermediária da controller com a camada de banco de dados do sistema; como também responsável por outras funções da própria aplicação, como por exemplo envio de email
- ExtensionError é a pasta que contém a classe Result para o controle de erros que foi feita com o FluentValidator
- Services é a pasta que contém as classes de serviços e suas interfaces
- UnitOfWork que contém os arquivos do Unit of Work. (é um padrão de design usado para gerenciar transações e a persistência de dados de forma coesa. Ele age como uma camada intermediária entre o repositório e o contexto de dados (como o Entity Framework DbContext) e ajuda a organizar e gerenciar mudanças nos objetos de domínio de forma transacional)

3. TestWebBackEndDeveloper.Domain é a library que foi criada para ser responsável pelo dados do projeto.
- Entity pasta que contém as entidades do projeto
- Enum pasta que contém os enums utilizados no projeto
- General pasta por conter classes mais genericas, dentro dela tem a classe BaseEntity (criada com o objetivo de ter as propriedades comuns das entidades)

4. TestWebBackEndDeveloper.Infrastracture é a library que foi criada para ser responsável pela camada de banco de dados
- Pasta Connection possui a classe de conexão ao banco de dados e a mesma classe responsável pela criação das tabelas e relacionamentos da entidades para o Entity Framework
- Migrations, depois que executar os comandos citados no início do documento, as migrations geradas irão ficar aqui
- Repository, pasta que contém os repositorios e as interfaces do projeto

5. TestWebBackEndDeveloper.Shared é a library que foi criada para utilizar o FluentValidator
- Enums, possui as classes de enum de erro
- Helpers, possui a classe de validação de erros
- Validator, possui as classes de regras de validação para as entidades

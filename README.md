# Desafio Calculo CDB | B3

#### Especificações do projeto:
- BackEnd: C# WebAPI .netframework 4.7.2
- FrontEnd: Angular + AngularMaterial | Angular CLI
- Visual Studio Community 2022 + ReSharper + SonarLint
- Visual Studio Code + SonarLint

#### Instruções para execução do projeto:
##### Back-End
- Abra o arquivo 'B3Api.sln'
- Após projeto ser carregado no Visual Studio, realize o processo de NuGet Restore na solution.
- Coloque em debug ou release ( fica a sua preferencia ) e pressione F5 para startar o projeto

##### Fron-End
- Abra a pasta 'FRONT'
- Execute o arquivo 'RunFrontEnd.bat'

O arquivo bat roda o seguinte comando:
> npm install & npm start

O link para acesso ao front é:
http://localhost:4200/

---
Para os testes unitários do front, deixei pronto um arquivo.
- Abra a pasta 'FRONT'
- Execute o arquivo 'RunFrontEndTest.bat'

O arquivo bat roda o seguinte comando:
>npm install & npm test

### Importante, teste unitário do front precisa que o back esteja rodando

---
Para os testes unitários do back, basta acessar o menu de test e executar.

---

### Considerações da implementação ( back ):
Parti do principio que estamos trabalhando com mercado financeiro, margem de erro é zero. Sendo assim optei por trabalhar com 2 objetos de valor ( Dinheiro & Percentual ). Ambos são readonly struct para melhor perfomance.

Tambem dividi o projeto do back em 3 camadas, sendo elas:
- API
- Modelo
- Negocio
- Teste Unitário

#### API
Tem como objetivo receber os requests externos e tambem retornar os resultados.
A API possui 2 modelos basicos onde gerencio o DTO de Request e Response, não quis vazar o objeto usado pelo negócio para o front.
Tambem foi configurado a utilização do CORS para aceitar solicitação vinda do localhost.

#### Modelo
Camada responsavel por gerenciar os modelos do projeto, onde contem os seguintes implementados:
- Cdb :
Struct readonly que representa "um mes" do ativo, nessa struct está tudo pertinente ao CDB.

- CdbAliquota
Classe estática com as constantes de aliquota de acordo com a tabela de IR regressiva.

- ETempoDeInvestimento
Enum que representa qual o periodo de tempo para determinar a aliquota correta.

- ETempoDeInvestimentoExtensao
Metodo extensor que tem como objetivo fazer um adapter do ETempoDeInvestimento para Percentual

- Dinheiro
Objeto de valor que representa dinheiro. Internamente é um float.
Aqui tambem foram implementados operadores para facilitar algumas contas.

- Percentual
Objeto de valor que representa porcentagem. Internamente é um float.

#### Negócio
Tem como objetivo realizar a regra de negócio passado no exercicio, como foi passado para ser constante a TaxaCDI e TB foi nessa camada que setei essas informações.
A implementação dessa camada conta com a classe 'CalculadoraCdb' que trabalha com objetos de valor.
Somente o "mes" não é objeto de valor, pois partindo do principio que ele deve ser sempre positivo, o tipo "uint" ja resolve o problema.
A classe conta com 2 implementações de metodo publico:

- CalcularCdb
Metodo que realiza o calculo seguindo a formula informada no exercicio e retorna somente 1 registro de CDB com o resultado.

- CalcularCdbComHistorico
Metodo que realiza o calculo seguindo a formula informada no exercicio, só que aqui é possivel acompanhar a evolução mes a mes da aplicação.

---

### Considerações da implementação ( front ):
- Foi criado o modulo e component CDB de forma Lazzy, afim de demonstrar o conhecimento.
- A implementação de solicitação HTTP está sendo feita com Axios
- Estilização do projeto foi feita utilizando Material
- A mascara dos inputs foi feita com ngx-mask
- O Locale do projeto foi alterado para pt-br
- A apresentação dos valores na tabela está sendo formatado via pipe
- Caso ocorra algum erro, um snack surgirá na parte inferior com o respectivo texto.
- Os testes unitários foram implementados realizando as chamadas na API, então é importante estar com o BackEnd rodando para executar os testes.
- A arquitetura do front foi pensada da seguinte forma:
Componente recebe injetado o serviço de cdb
Serviço de cdb recebe injetado o serviço da api
Serviço da API gerencia o Axios
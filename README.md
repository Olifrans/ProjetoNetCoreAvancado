# Projeto NetCore um pouco mais avançado com alguns padrões desenvolvimento.


## Abordagem e tecnologias:

Rest,
Injeção de dependência,
UnitOfWork,

## Libs e pacotes
FluentValidation, JWT, AutoMapper, AutoMapper.Extensions, Dapper, Dapper.Contrib, Swagger.
Dockerf

### Padrão UnitOfWork nos Repositories  - Para ter Controle de transações no BD
Concentrando todos dominios em um unico lugar para manter a consistencia de dados e concorrencia de BD
facilitando teste de integração

### Para Persitência de dados BD usei o Dapper
Obs: O Dapper não tem unidade de trabalho único (Controle de transações no BD), diferente dos demais.
Ex:
https://dapper-tutorial.net/

Tabelas: 
Order 
OrderItem
 
OrderItem -> OrderId
OrderItem2 -> OrderId
OrderItem3 -> OrderId



Proxima aula inicio:
https://www.youtube.com/watch?v=_4uyChyStq0&list=PLTy6F1LNIRHcuFRBO_QQ6oWbOozkNz8fa&index=14
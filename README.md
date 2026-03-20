# Sistema de Treinos de Academia

## Visão Geral

O **Sistema de Treinos de Academia** é uma API desenvolvida em **C#** utilizando **Entity Framework Core** e **SQL Server**, projetada para gerenciar de forma eficiente usuários, treinos e exercícios em academias. O projeto segue boas práticas de desenvolvimento, arquitetura em camadas e demonstra aplicação de conceitos avançados de design de APIs, DTOs, AutoMapper e relacionamentos complexos entre entidades.

## Objetivo do Projeto

O objetivo principal é construir uma API robusta e escalável que permita:
- Gestão completa de usuários, exercícios e treinos
- Operações CRUD eficientes e seguras
- Integração de treinos com exercícios, incluindo séries e repetições
- Aplicação de padrões de projeto e boas práticas de programação

## Principais Entidades

### Usuario
- `Id`: Identificador único do usuário
- `Nome`: Nome do usuário
- `Email`: Email do usuário
- `Senha`: Senha do usuário

### Treino
- `Id`: Identificador do treino
- `Nome`: Nome do treino
- `UsuarioId`: Referência ao usuário dono do treino
- `Usuario`: Relacionamento 1:N
- `TreinoExercicio`: Tabela ternária para identificação.

### Exercicio
- `Id`: Identificador do exercício
- `Nome`: Nome do exercício
- `Regiao`: Região do corpo que é efetivo

### TreinoExercicio (Relacionamento N:N)
- `TreinoId`: Identificador do treino
- `ExercicioId`: Identificador do exercício
- `Series`: Número de séries
- `Repeticoes`: Número de repetições

## Funcionalidades da API

### Usuários
- Criar, listar, buscar, atualizar e deletar usuários
- Leitura otimizada com `AsNoTracking`

### Exercícios
- Criar, listar, buscar, atualizar e deletar exercícios
- Leitura otimizada com `AsNoTracking`

### Treinos
- Criar treinos vinculados a usuários
- Listar treinos incluindo informações do usuário e exercícios (`Include` / `ThenInclude`)
- Buscar treino por Id com todos os relacionamentos
- Atualizar e deletar treinos

### TreinoExercicio
- Adicionar ou remover exercícios de um treino
- Atualizar séries e repetições de cada exercício

## Tecnologias e Conceitos Aplicados

- **Entity Framework Core**: DbContext, DbSet, Migrations, Update-Database
- **Consultas Otimizadas**: `AsNoTracking`, `Include`, `ThenInclude`, Eager Loading
- **DTOs**: Estruturas para entrada e saída de dados (Create/Update/Response)
- **AutoMapper**: Mapeamento entre entidades e DTOs
- **SQL Server**: Banco de dados relacional para armazenamento persistente

## Estrutura Recomendada

- `Controllers` — Lógica de roteamento e endpoints
- `Services` — Regras de negócio
- `Repository` — Acesso a dados
- `Models` — Entidades do domínio
- `DTOs` — Objetos de transferência de dados
- `Profiles` — Configurações do AutoMapper
- `Data` — DbContext e configuração do banco
- `Migrations` — Scripts de migração do banco

## Exemplos de Uso

- **GET Treinos**: Uso de `Include` + `ThenInclude` e `AsNoTracking` para leitura completa
- **POST/PUT**: Recebe DTO, mapeia com AutoMapper e persiste no banco
- **PATCH**: Atualização parcial de registros sem AutoMapper direto

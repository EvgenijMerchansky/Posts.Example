# Posts.Example

## Overview

Simple .NET Web API application for working with posts.

The project is built around a layered architecture with separation of responsibilities between API, command handling, query handling, services, database layer, shared models, and utilities.

It leverages:

- **ASP.NET Core Web API** for HTTP endpoints
- **Entity Framework Core** for database access
- **MediatR** for command/query handling
- **AutoMapper** for object mapping
- **FluentValidation** for request validation
- **SQL Server / LocalDB** for data storage
- **Docker Compose** for containerized local запуск

## Architecture Layers

### 1. API Layer

- **Posts.Example.CommandApi.Site**: entry point of the application
- exposes controllers
- configures DI, middleware, Swagger, AutoMapper, MediatR, validators, EF Core

### 2. Command Layer

- **Posts.Example.CommandService**
- contains commands and command handlers
- responsible for write operations:
  - create post
  - update post
  - delete post

### 3. Query Layer

- **Posts.Example.QueryService**
- contains queries and query handlers
- responsible for read operations:
  - get post by id
  - get posts list

### 4. Service Layer

- **Posts.Example.Services**
- contains business/service logic
- works with repositories and unit-of-work style flow
- includes:
  - `PostService`
  - `MockPostService`

### 5. Database Layer

- **Posts.Example.DBLayer**
- contains:
  - EF Core `PostsDbContext`
  - entities
  - repositories
  - repository interfaces

### 6. Shared Models

- **Posts.Example.Models**
- shared DTOs used across layers

### 7. Utilities

- **Posts.Example.Utilities**
- contains mapping profiles and supporting utilities

### 8. Tests

- **Posts.Example.CommandApi.Test**
- test project for API / command scenarios

## Folder Structure

```
Posts.Example/
│
├── doc/
│
├── pipelines/
│
├── infrastructure/
│   │
│   └── docker/
│       ├── docker-compose.yml
│       ├── Dockerfile
│       ├── sqlserver.env.example
│       └── posts-api.env.example
│
├── src/
│   │
│   ├── Client/
│   │   └── Posts.Example.Client
│   │
│   ├── CommandApi/
│   │   └── Posts.Example.CommandApi.Site/
│   │       ├── Controllers/
│   │       │   ├── BaseController.cs
│   │       │   └── PostsController.cs
│   │       ├── Extensions/
│   │       │   └── ServicesExtension.cs
│   │       ├── Validators/
│   │       │   ├── UpdatePostDtoValidator.cs
│   │       │   ├── CreatePostDtoValidator.cs
│   │       │   └── PostDtoValidator.cs
│   │       ├── appsettings.json
│   │       ├── Program.cs
│   │       └── Posts.Example.CommandApi.Site.csproj
│   │
│   ├── CommandService/
│   │   └── Posts.Example.CommandService/
│   │       ├── CommandHandlers/
│   │       │   ├── CreatePostCommandHadnler.cs
│   │       │   ├── DeletePostCommandHandler.cs
│   │       │   └── UpdatePostCommandHandler.cs
│   │       └── Commands/
│   │           ├── CreatePostCommand.cs
│   │           ├── DeletePostCommand.cs
│   │           └── UpdatePostCommand.cs
│   │
│   ├── QueryService/
│   │   └── Posts.Example.QueryService/
│   │       ├── Queries/
│   │       │   ├── GetPostQuery.cs
│   │       │   └── GetPostsQuery.cs
│   │       └── QueryHandlers/
│   │           ├── GetPostQueryHandler.cs
│   │           └── GetPostsQueryHadnler.cs
│   │
│   ├── DBLayer/
│   │   └── Posts.Example.DBLayer/
│   │       ├── EntityFramework/
│   │       │   └── PostsDbContext.cs
│   │       ├── Models/
│   │       │   └── Post.cs
│   │       └── Repositories/
│   │           ├── Interfaces/
│   │           │   ├── IBaseRepository.cs
│   │           │   └── IPostRepository.cs
│   │           ├── BaseRepository.cs
│   │           └── PostRepository.cs
│   │
│   ├── Shared/
│   │   ├── Posts.Example.Models/
│   │   │   └── Dtos/
│   │   │       └── Posts/
│   │   │           ├── UpdatePostDto.cs
│   │   │           ├── CreatePostDto.cs
│   │   │           └── PostDto.cs
│   │   │
│   │   ├── Posts.Example.Services/
│   │   │   └── Services/
│   │   │       ├── MockPostService.cs
│   │   │       └── PostService.cs
│   │   │
│   │   └── Posts.Example.Utilities/
│   │       └── Mapper/
│   │           └── MapperProfile.cs
│   │
│   └── Tests/
│       └── Posts.Example.CommandApi.Test/
│
├── .gitignore
├── LICENSE
├── README.md
└── Posts.Example.All.sln
```

## Design Approach

The project follows a **CQRS-style separation** of responsibilities:

- **Commands** are responsible for data modification
- **Queries** are responsible for data retrieval

This approach helps keep read and write logic isolated and easier to maintain.

The solution is also split into dedicated layers:

- **API layer** for HTTP endpoints and application bootstrap
- **Command layer** for write operations
- **Query layer** for read operations
- **Service layer** for business logic
- **Database layer** for EF Core context, entities, and repositories
- **Shared layer** for DTOs and reusable components
- **Utilities layer** for mapping and helper logic

## Database Strategy

The application uses **Entity Framework Core** with SQL Server.

For local development, the project can work with:

- **LocalDB** for non-Docker execution
- **SQL Server in Docker** for containerized execution

The database connection is configured differently depending on the environment:

- **local development** uses **User Secrets**
- **Docker development** uses local `.env` files

This allows keeping real connection strings out of tracked configuration files.

## Technology Stack

- **Framework**: ASP.NET Core Web API
- **Language**: C#
- **Runtime**: .NET 10
- **ORM**: Entity Framework Core
- **Validation**: FluentValidation
- **Mediator**: MediatR
- **Object Mapping**: AutoMapper
- **Database**: SQL Server
- **Containerization**: Docker, Docker Compose

## Request Flow

1. HTTP request comes to `PostsController`
2. Controller sends a command or query through MediatR
3. Handler calls the service layer
4. Service layer works with repositories
5. Repository uses EF Core to access the database
6. Response is returned back to the API client

## Getting Started

### Prerequisites

- .NET 10 SDK
- SQL Server LocalDB or SQL Server
- Docker
- Docker Compose
- PowerShell

## Local Development

For local development, it is recommended to keep connection strings out of `appsettings.json` and use **User Secrets** instead.

### Configure local secrets manually

Run from the repository root:

```
#PowerShell
dotnet user-secrets init --project .\src\CommandApi\Posts.Example.CommandApi.Site.csproj
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "YOUR_LOCAL_CONNECTION_STRING" --project .\src\CommandApi\Posts.Example.CommandApi.Site.csproj
```
## Run locally

```
dotnet build .\Posts.Example.All.sln
dotnet run --project .\src\CommandApi\Posts.Example.CommandApi.Site.csproj
```

Swagger is typically available at:

```
http://localhost:<port>/swagger
```

## Docker

The project can also be started in containers.

### Prepare Docker environment files

Go to: `infrastructure/docker/`

Copy `posts-api.env.example` to `posts-api.env` and `sqlserver.env.example` to `sqlserver.env`, then adjust values.

Build: `docker compose build`
Run: `docker compose up`
Build & Run: `docker compose up --build`

After startup, the API should be available at:

```
http://localhost:8081
```

## License

MIT License.

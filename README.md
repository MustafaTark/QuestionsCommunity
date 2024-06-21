# QuestionCommunity

## Overview
This repository contains a monolithic StackOverflow-like application built with .NET Core. The project implements Domain-Driven Design (DDD) and Command Query Responsibility Segregation (CQRS) principles, leveraging MediatR for request/response handling and ProblemDetails for standardized error responses.

## Features
- User registration and authentication
- Posting questions and answers
- Voting on questions and answers
- Commenting on questions and answers
- Tagging questions with relevant tags
- Search functionality for questions

## Architecture
The architecture of this StackOverflow clone is designed for scalability, maintainability, and testability. It includes the following components:

### Layers
#### Domain Layer
- Contains the core business logic and domain entities.
- Implements DDD principles to model the business domain.

#### Application Layer
- Implements CQRS principles by segregating commands (writes) and queries (reads).
- Uses MediatR to handle commands and queries.

#### Infrastructure Layer
- Handles data persistence and external service integrations.
- Configures the database context and repositories.

#### Presentation Layer
- Exposes APIs for interaction with the application.
- Uses ProblemDetails for standardized error responses.

### Key Patterns and Technologies
- **.NET Core**: The primary framework for building the application.
- **DDD (Domain-Driven Design)**: Provides a structured approach to designing the system by modeling the business domain.
- **CQRS (Command Query Responsibility Segregation)**: Segregates read and write operations to optimize performance and scalability.
- **MediatR**: Implements the mediator pattern for handling requests and notifications within the services.
- **ProblemDetails**: Provides a standardized way to handle and return error responses.

## Getting Started
To get started with the StackOverflow clone, follow these steps:

### Prerequisites
Ensure you have the following installed on your machine:
- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or any other supported database

### Installation
1. Clone the repository:
    ```bash
    git clone https://github.com/MustafaTark/QuestionsCommunity.git
    ```

2. Navigate to the project directory:
    ```bash
    cd stackoverflow-clone
    ```

3. Update the database connection string in `appsettings.json`:
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;"
    }
    ```

4. Apply database migrations:
    ```bash
    dotnet ef database update
    ```

5. Build and run the application:
    ```bash
    dotnet run
    ```

### Running the Application
Once the application is up and running, you can access it via `http://localhost:5000` (or the port configured in your setup).


## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgements
Special thanks to all the contributors and open-source projects that made this project possible.

# CustomerManagementAPI

CustomerManagementAPI is a .NET Core Web API designed for managing customer records efficiently. It provides endpoints for CRUD operations with support for both hard and soft delete options. The API is built using Entity Framework Core with SQL Server as the database backend.

## Features

- **CRUD Operations**: Create, Read, Update, and Delete customer records.
- **Soft Delete**: Option to soft delete customers, keeping historical data intact.
- **API Versioning**: Versioning of API endpoints to support backward compatibility.
- **Swagger Integration**: Interactive API documentation using Swagger UI.

## Technologies Used

- **.NET Core**: Framework for building cross-platform applications.
- **Entity Framework Core**: ORM for .NET Core to work with databases.
- **SQL Server**: Relational database management system.
- **Swagger**: Open-source tool for documenting APIs.
- **API Versioning**: Managing changes in the API without breaking existing clients.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) installed on your machine.
- SQL Server instance or connection string to a SQL Server database.

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/CustomerManagementAPI.git
      
2. Navigate to the project directory:
  ```bash
  cd CustomerManagementAPI
  ```

3. Restore dependencies and build the project:
  ```bash
     dotnet restore
     dotnet build
  ```

4. Update the database connection string in appsettings.json:
  ```bash
     {
        "ConnectionStrings": {
          "DefaultConnection": "YourConnectionStringHere"
          }
      }
  ```
5. Apply database migrations to create the database:
  ```
  dotnet ef database update
  ```
6. Run the application:
  ```
  dotnet run
  ```
7. Browse to https://localhost:5001/swagger to view and test the API using Swagger UI.
   
### API Endpoints

- **GET** `/api/customers`: Get all customers.
- **GET** `/api/customers/{id}`: Get customer by ID.
- **POST** `/api/customers`: Create a new customer.
- **PUT** `/api/customers/{id}`: Update an existing customer.
- **DELETE** `/api/customers/{id}`: Delete a customer (hard delete).
- **PATCH** `/api/customers/{id}/softdelete`: Soft delete a customer.

 ### Documentation

API documentation is generated using Swagger and can be accessed at `https://localhost:5001/swagger` after running the application.

### Contributing

Contributions are welcome! Please fork the repository and create a pull request with your proposed changes.



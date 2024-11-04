## Overview
This application is a .NET 8.0-based web API designed for managing products. It provides endpoints for retrieving, updating, and paginating product data. The application has integrated logging, testing, and API versioning.

## Tech Stack
- **.NET 8.0**: The primary framework used for building the application.
- **C#**: The programming language used for the application's development.
- **ASP.NET Core**: For building and running the web API.
- **MS SQL Server**: The database provider
- **Entity Framework**: Used for database operations.
- **AutoMapper**: For object-object mapping.
- **FluentResults**: Used with the Result pattern.
- **OpenAPI/Swagger**: For API documentation.
- **GitHub Actions**: For CI/CD
- **NUnit**: For unit testing.
 
## Architecture
The application follows the **Onion architecture**, structured as follows:
- `AlzaApp.Domain`: The main domain layer, has no dependencies.
  - Contains domain entities, data transfer objects and interfaces used by `AlzaApp.Persistence`.
- `AlzaApp.Core`: Depends on `AlzaApp.Domain`.
  - Contains interfaces and implemented services used by `AlzaApp.API` to communicate with the data layer.
- `AlzaApp.Persistence`: Depends on `AlzaApp.Domain`.
  - Contains database objects describing the database structure.
  - Implements the whole repository logic to communicate with the database.
- `AlzaApp.API`: Depends on `AlzaApp.Core`, `AlzaApp.Domain`, and `AlzaApp.Persistence`.
  - Is the entry point to the app.
  - Contains an API definition, registers endpoints.
- `AlzaApp.Test`: Depends on `AlzaApp.Core`, `AlzaApp.Domain`, and `AlzaApp.Persistence`.
  - Contains unit tests for the projects

![OnionArchitecture](https://github.com/user-attachments/assets/acb47f4f-179d-489a-836c-62fe34ab2117)

## Result pattern
This project implements the **Result** pattern to standardize the outcomes of operations. This pattern provides a unified way to represent the success or failure of an operation, encapsulating the results along with any errors or messages. The pattern helps eliminate null reference exceptions by ensuring that a result is always returned.

## Error handling
Error handling in this project is designed to ensure that any issues are clearly reported and effectively managed. The approach involves using the **Result** pattern to encapsulate and standardise error outcomes, ensuring consistent and predictable responses without relying on exceptions. Custom error classes contain structured error messages and error codes for the API response, what is reducing nullability issues.

## Entities Naming Convention
This project follows a **Contextual** naming for entities. This approach enhances readability and maintainability by clearly indicating the purpose of each entity in the context it serves.

**Key Naming Patterns**
- `DTO (Data Transfer Object)`: Used in the presentation layer to transfer data.
  - **Product*Dto*** for communication with the client.
- `DO (Database Object)`: Represents the database structure in the data layer.
  - **Product*Do*** for database interactions.
- `Domain Entity`: Used for communicating within the application
  - **Product** for business logic related to products.

As an example of usage, **ProductDo** additionally includes the *CreatedAt* and *UpdatedAt* properties, which are necessary to track creation and modification at the database level. In contrast, the **Product** domain entity includes only the *UpdatedAt* property, focusing on data related to business logic. **ProductDto**, on the other hand, completely excludes these properties because they are not needed for customer interaction. 

## Endpoints Description
Also available from the swagger page `/swagger`.

### Version 1 Endpoints

Base URL: `api/v1/`

1. **Get All Products**
- **Method**: `GET`
- **URL**: `/products`
- **Description**: Retrieves a list of all products.
- **Response**: 
  - `200 OK` with the list of products if successful.
  - `404 Not Found` if no products are found.

2. **Get Product by ID**
- **Method**: `GET`
- **URL**: `/products/{id:int}`
- **Description**: Fetches details of a specific product by its ID.
- **Response**: 
  - `200 OK` with the product details if successful.
  - `404 Not Found` if the product with the specified ID is not found.

3. **Update Product Description**
- **Method**: `PATCH`
- **URL**: `/products/{id:int}`
- **Description**: Updates the description of a product.
- **Parameters**:
  - `id` (int, required): The ID of the product to update.
  - `description` (string, required): The new description for the product.
- **Response**:
  - `200 OK` with the updated product details if successful.
  - `400 Bad Request` if the length of the description exceeds 1000 characters.
  - `404 Not Found` if the product with the specified ID is not found.

### Version 2 Endpoints

Base URL: `api/v2/`

1. **Get Paginated Products**
   - **Method**: `GET`
   - **URL**: `/products`
   - **Description**: Retrieves products in a paginated format.
   - **Parameters**:
     - `page` (int, required): The page number to retrieve.
     - `pageSize` (int, optional): The number of products per page.
   - **Response**: 
     - `200 OK` with the paginated list of products if successful.
     - `400 Bad Request` if the page or pageSize parameters are invalid.
     - `404 Not Found` if no products are found for the specified page.


## How to: Run
1. Navigate to the `AlzaApp.API` project.
2. Provide a connection string to your database with the following command:
```
dotnet user-secrets set "ConnectionStrings:DatabaseConnection" "Server={YourSqlServerName};Database=AlzaApp;User={DbUserName};Password={DbPassword};TrustServerCertificate=True"
```
(To connect to the db on production profiles, you should update the connection string directly in **appsettings.json**)

3. Initialize a database using `Update-Database` from the Entity Framework tools.
4. Run the application and go to the swagger page `/swagger` (Not available for production profiles).
5. Enjoy.

## How to: Test
1. Navigate to the `AlzaApp.Test` project.
2. Run the following command:
```
dotnet test
```
Or just use **Tests explorer** in your IDE.

# Car Rental API

Car Rental API is an application for managing a car rental service, built using Onion Architecture with ASP.NET Core. The application utilizes Identity, an SQL database, and JSON Web Token (JWT) for authentication.

## Required NuGet Packages
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.AspNetCore.Identity.UI
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
  These packages need to be installed for the entire project.

## Database Migration
To perform a database migration, set the startup project to `ProjektBackend.Infrastructure` in the Package Manager Console and then run the following commands:

```bash
add-migration Init
update-database
```

Make sure to delete the `Migrations` folder if it already exists.

## Database Connection String

```json
{
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\LOCALHOST;Database=Projekt;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true"
  }
}
```

Replace the `Server` field with the appropriate name for your machine, e.g., `localhost`.

## Project Structure

### API Layer
Contains controllers for handling HTTP requests.

#### Controllers:

**AdminController**
- Creates a user with the Administrator role.

**AuthorizationController**
- Registers new users.
- Logs in users and generates JWT tokens.

**CarController**
- Retrieves all cars.
- Retrieves car details.
- Creates new cars (Administrator only).
- Edits cars (Administrator only).
- Deletes cars.

**CategoryController**
- Retrieves all car categories.
- Retrieves category details.

**ClientController**
- Retrieves all clients (Administrator, User).
- Retrieves client details (Administrator, User).
- Creates new clients (Administrator).

**OrderController**
- Retrieves all orders (Administrator, User).
- Retrieves order details (Administrator, User).
- Creates new orders (Administrator).

### Application Layer
Contains services for business logic.

#### Services:

**CarService**
- Handles operations related to cars.

**CategoryService**
- Handles operations related to categories.

**ClientService**
- Handles operations related to clients.

**OrderService**
- Handles operations related to orders.

### Domain Layer
Contains entities and interfaces.

#### Entities:

**Cars**
- Car ID, brand, model, category, related orders.

**Categories**
- Category ID, category name, related cars.

**Clients**
- Client ID, first name, last name, email, related orders.

**Orders**
- Order ID, order date, user ID, client ID, car ID, pickup and return dates.

The entities consist of 4 main entities:
- Categories
- Cars
- Clients
- Orders

And 7 relationships:
- Categories - Cars: One-to-Many
- Cars - Categories: Many-to-One
- Cars - Orders: One-to-Many
- Clients - Orders: One-to-Many
- Orders - Users: Many-to-One
- Orders - Clients: Many-to-One
- Orders - Cars: Many-to-One

### Infrastructure Layer
Contains repository implementations and database configuration.

#### Repositories:

**CarRepository**
- Implements CRUD operations for cars.

**CategoryRepository**
- Implements CRUD operations for categories.

**ClientRepository**
- Implements CRUD operations for clients.

**OrderRepository**
- Implements CRUD operations for orders.

#### ApplicationDbContext
- Configures the database and relationships between entities.

### Models
Contains models used in the application.

**ApplicationUser**
- Extends the `IdentityUser` class with additional fields: FirstName, LastName.

**RegisterModel**
- Model for user registration.

**LoginModel**
- Model for user login.

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/dstudnicki/CarRentAPI.git
    ```

2. Navigate to the project directory:
    ```bash
    cd ProjektBackend
    ```

3. Install dependencies:
    ```bash
    dotnet restore
    ```

4. Configure the database in the `appsettings.json` file.

5. Run migrations:
    ```bash
    dotnet ef database update
    ```

6. Run the application:
    ```bash
    dotnet run
    ```

## Usage

### Registration
- Endpoint: `POST /Authorization/register`
- Body:
  ```json
  {
      "UserName": "string",
      "Email": "string",
      "Password": "string",
      "FirstName": "string",
      "LastName": "string"
  }
  ```

### Login
- Endpoint: `POST /Authorization/login`
- Body:
  ```json
  {
      "Email": "string",
      "Password": "string"
  }
  ```

### Creating a New Car
- Endpoint: `POST /Car`
- Header: `Authorization: Bearer {token}`
- Body:
  ```json
  {
      "Brand": "string",
      "Model": "string",
      "CategoryId": int
  }
  ```

### Retrieving All Cars
- Endpoint: `GET /Car`
- Header: `Authorization: Bearer {token}`

## Testing

To test the API, you can use tools like Postman or Swagger UI, available at `/swagger`.


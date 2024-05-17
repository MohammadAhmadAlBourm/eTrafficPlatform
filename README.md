# eTrafficPlatform

Welcome to the **eTrafficPlatform** project! This project is built using .NET Core Web API version 8 and follows the principles of Clean Architecture. The application implements several design patterns including Mediator, CQRS, and Unit of Work. Additionally, it leverages Fluent Validation for validating incoming requests. This README will provide an overview of the project structure, the technologies used, and instructions for setting up and running the project.

## Project Structure

The project is organized following Clean Architecture principles, ensuring separation of concerns and scalability. Here's an overview of the key components:

- **Controllers**: Handle incoming HTTP requests and route them to the appropriate handlers.
  - `TrafficController`: Manages CRUD operations for traffic data.
  - `TrafficEventController`: Manages CRUD operations for traffic events.
  - `DocumentController`: Handles the uploading of traffic data files in XML format, triggering events for parsing and saving the data to the database.

- **CQRS (Command Query Responsibility Segregation)**: Separates read (queries) and write (commands) operations to optimize performance and scalability.
  - Commands: Handle write operations (create, update, delete).
  - Queries: Handle read operations.

- **Mediator**: Facilitates communication between controllers and handlers without them needing to know about each other.
  
- **Unit of Work**: Manages database transactions to ensure data consistency.

- **Fluent Validation**: Ensures incoming requests are validated against predefined rules before processing.

- **Global Exception Handler**: Captures all unhandled exceptions and returns standardized error responses to the client.

## Technologies Used

- **.NET Core Web API 8**
- **MediatR**: For implementing the Mediator pattern.
- **CQRS**: For implementing the CQRS pattern.
- **UnitOfWork**: For implementing the Unit of Work pattern.
- **FluentValidation**: For request validation.
- **Entity Framework Core**: For data access and ORM.
- **Mapster**: For object-to-object mapping.
- **Serilog**: For logging.

## Setting Up the Project

### Prerequisites

- .NET Core SDK 8.0 or later
- SQL Server or another compatible database
- Visual Studio or any preferred code editor

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/eTrafficPlatform.git](https://github.com/MohammadAhmadAlBourm/eTrafficPlatform.git
   cd eTrafficPlatform
   ```

2. **Restore dependencies:**
   ```bash
   dotnet restore
   ```

3. **Update the database connection string:**
   Modify the `appsettings.json` file to include your database connection string.

4. **Apply database migrations:**
   ```bash
   dotnet ef database update
   ```

5. **Run the application:**
   ```bash
   dotnet run
   ```

## API Endpoints

### TrafficController

- `GET /api/traffic`: Get all traffic data.
- `GET /api/traffic/{sessionId}`: Get traffic data by ID.
- `POST /api/traffic`: Create new traffic data.
- `PUT /api/traffic`: Update traffic data by ID.
- `DELETE /api/traffic/{sessionId}`: Delete traffic data by ID.

### TrafficEventController

- `GET /api/traffic-event`: Get all traffic events.
- `GET /api/traffic-event/{id}`: Get traffic event by ID.
- `POST /api/traffic-event`: Create new traffic event.
- `PUT /api/traffic-event`: Update traffic event by ID.
- `DELETE /api/traffic-event/{id}`: Delete traffic event by ID.

### DocumentController

- `POST /api/fileupload`: Upload traffic data file in XML format. This triggers an event to parse the file and save the data to the database.

## Global Exception Handling

The application uses a global exception handler to catch and handle all exceptions, ensuring that clients receive consistent and meaningful error responses. There is no need to use try-catch blocks in controllers, as all exceptions are managed centrally.

## Contribution

Contributions are welcome! Please fork the repository and submit pull requests.

## License

This project is licensed under the MIT License.

---

Thank you for using eTrafficPlatform! If you have any questions or need further assistance, please feel free to contact us. Happy coding!

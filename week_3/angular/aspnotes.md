# ASP.NET Core Web API

## 1. Introduction to ASP.NET Core Web API

- **ASP.NET:** A framework for building web applications and APIs using C#.
- **Core:** The modern, cross-platform version of ASP.NET.
- **Web API:** An application that exposes endpoints so other applications can communicate with it.

## 2. Project Anatomy

| File / Folder | Purpose |
|---|---|
| `Program.cs` | Application entry point; configures and starts the application. |
| `appsettings.json` | Stores configuration such as connection strings and logging settings. |
| `Controllers/` | Contains API controllers and endpoints. |
| `Properties/` | Contains launch settings. |
| `.csproj` | Project configuration and dependencies. |
| `bin/` | Contains compiled output. |
| `obj/` | Contains intermediate build files. |

### Creating a Web API Project

```bash
dotnet new webapi -n PracticeProject
```

## 3. Program.cs

`Program.cs` is the entry point of an ASP.NET Core application. It configures services, middleware, endpoints, and starts the application.

```csharp
// Create the builder
var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();

var app = builder.Build();

// Configure middleware
app.UseHttpsRedirection();

app.UseAuthorization();

// Map controllers
app.MapControllers();

// Run the application
app.Run();
```

### Understanding the Code

1. `WebApplication.CreateBuilder(args)` – Creates the application builder.
2. `builder.Services.AddControllers()` – Registers controller-related services.
3. `builder.Build()` – Builds the application.
4. `app.UseHttpsRedirection()` – Redirects HTTP requests to HTTPS.
5. `app.UseAuthorization()` – Enables authorization middleware.
6. `app.MapControllers()` – Maps controller endpoints.
7. `app.Run()` – Starts the application.

## 4. Middleware

Middleware is software that processes HTTP requests and responses in the application pipeline.

Each middleware component can:
- Process an incoming HTTP request.
- Pass the request to the next middleware.
- Modify the HTTP response.
- Stop the request pipeline and return a response.

### Middleware Order

Middleware executes in the order in which it is registered.

Common middleware:

```csharp
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
```

- `UseAuthentication()` – Identifies who the user is.
- `UseAuthorization()` – Checks what the user is allowed to access.
- `MapControllers()` – Maps controller endpoints.

**Note:** Authentication must come before authorization when both are used.

### ASP.NET Core Request Pipeline

```text
Angular Frontend
       |
       | Sends HTTP Request
       v
Kestrel Web Server
       |
       | Receives HTTP Request
       v
Middleware Pipeline
       |
       | Processes Request
       v
Endpoint / Controller
       |
       | Executes Requested Operation
       v
HTTP Response
       |
       | Returns JSON Data
       v
Angular Frontend
```

### Important Terms

- **Kestrel:** The built-in, cross-platform web server used by ASP.NET Core.
- **Middleware:** Components that process HTTP requests and responses.
- **Endpoint:** The actual destination that handles a particular request.
- **Response:** The result returned by the server to the client.

## 5. Endpoints

An endpoint is a specific combination of a URL and an HTTP method that performs an operation.

Example:

| HTTP Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/tickets` | Get all tickets |
| GET | `/api/tickets/1` | Get a specific ticket |
| POST | `/api/tickets` | Create a ticket |
| PUT | `/api/tickets/1` | Update a ticket |
| DELETE | `/api/tickets/1` | Delete a ticket |

These are commonly known as API endpoints.

## 6. Controllers vs Minimal APIs

ASP.NET Core provides two ways to create API endpoints.

### A. Controllers

Controllers organize API endpoints into classes.

They are useful for larger applications where endpoints need proper organization.

Example:

```csharp
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetTickets()
    {
        return Ok("List of tickets");
    }
}
```

Here:
- `[ApiController]` – Adds API-specific behavior.
- `[Route("api/[controller]")]` – Defines the route.
- `ControllerBase` – Base class for API controllers.
- `[HttpGet]` – Handles HTTP GET requests.
- `Ok()` – Returns an HTTP 200 response.

### B. Minimal APIs

Minimal APIs allow us to create endpoints directly in `Program.cs` without creating controller classes.

Example:

```csharp
app.MapGet("/api/tickets", () =>
{
    return Results.Ok("List of tickets");
});
```

**Difference:**

- Controllers organize endpoints into classes.
- Minimal APIs define endpoints directly, usually in `Program.cs`.

## 7. Routing and Route Templates

**Routing** means deciding which endpoint should handle an incoming HTTP request.

A route template defines the URL pattern for an endpoint.

Example:

```csharp
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetTickets()
    {
        return Ok("All tickets");
    }
}
```

Here, `[controller]` is replaced by the controller name without the `Controller` suffix.

Therefore, the endpoint becomes:

```text
GET /api/tickets
```

### Route Parameters

Route parameters allow us to retrieve specific data using values passed in the URL.

Example:

```csharp
[HttpGet("{id}")]
public IActionResult GetTicket(int id)
{
    return Ok($"Ticket ID: {id}");
}
```

Request:

```text
GET /api/tickets/5
```

Output:

```text
Ticket ID: 5
```

Here, `id` is a route parameter.

## 8. Model Binding

Model binding automatically takes data from an HTTP request and assigns it to C# parameters or objects.

### Three Important Sources

**A. Route Binding**

Data comes from the URL path.

Example:

```text
GET /api/tickets/5
```

```csharp
public IActionResult GetTicket(int id)
```

Here, `id = 5`.

**B. Query String Binding**

Query parameters are passed after `?` in the URL.

Example:

```text
GET /api/tickets?status=open
```

```csharp
public IActionResult GetTickets(string status)
```

Here, `status = "open"`.

**C. Request Body Binding**

Multiple pieces of data can be passed in the request body, commonly in JSON format.

Example JSON:

```json
{
    "title": "Login Issue",
    "description": "Unable to log in"
}
```

C# model:

```csharp
public class Ticket
{
    public string Title { get; set; }
    public string Description { get; set; }
}
```

Controller:

```csharp
[HttpPost]
public IActionResult CreateTicket(Ticket ticket)
{
    return Ok(ticket);
}
```

## 9. HTTP Responses

An HTTP response is the information sent by the server back to the client after processing a request.

### Common HTTP Status Codes

| Status Code | Meaning |
|---|---|
| 200 | OK – Request successful |
| 201 | Created – Resource created successfully |
| 204 | No Content – Successful request without response body |
| 400 | Bad Request – Invalid request |
| 401 | Unauthorized – Authentication required |
| 403 | Forbidden – Access denied |
| 404 | Not Found – Resource not found |
| 500 | Internal Server Error – Server-side error |

## 10. IActionResult

`IActionResult` is an interface used by controller actions to represent an HTTP response.

It allows a controller method to return different types of HTTP responses.

Example:

```csharp
[HttpGet("{id}")]
public IActionResult GetTicket(int id)
{
    if (id <= 0)
    {
        return BadRequest("Invalid ticket ID");
    }

    if (id > 100)
    {
        return NotFound();
    }

    return Ok("Ticket found");
}
```

Here, the method can return different HTTP status codes depending on the condition.

### Typed Results

Typed results make the possible response types more explicit.

| Type | Purpose |
|---|---|
| `IActionResult` | Returns different HTTP action results. |
| `ActionResult<T>` | Returns a specific data type or an HTTP action result. |
| `IResult` | Represents an HTTP response, commonly used with Minimal APIs. |
| `Results<T1,T2>` | Declares a union of possible typed responses for Minimal APIs. |

Example of `ActionResult<T>`:

```csharp
[HttpGet("{id}")]
public ActionResult<Ticket> GetTicket(int id)
{
    if (id <= 0)
    {
        return BadRequest();
    }

    var ticket = new Ticket
    {
        Title = "Login Issue"
    };

    return Ok(ticket);
}
```

## 11. Returning JSON Responses

ASP.NET Core APIs commonly return data in JSON format.

When a C# object is returned from an API, ASP.NET Core converts it into JSON.

This conversion is called **Serialization**.

- **Serialization:** C# Object → JSON
- **Deserialization:** JSON → C# Object

ASP.NET Core uses `System.Text.Json` by default for JSON serialization.

Example:

C# Object:

```csharp
var ticket = new
{
    Id = 1,
    Title = "Login Issue"
};

return Ok(ticket);
```

JSON Response:

```json
{
    "id": 1,
    "title": "Login Issue"
}
```

## 12. Dependency Injection (DI)

Dependency Injection solves the problem of creating and managing dependencies manually.

Instead of creating dependencies ourselves, we ask ASP.NET Core to provide them.

Example:

```csharp
public class TicketsController : ControllerBase
{
    private readonly TicketService _service;

    public TicketsController(TicketService service)
    {
        _service = service;
    }
}
```

Here:
- `TicketService` is the dependency.
- The constructor receives that dependency.
- ASP.NET Core provides an instance automatically through DI.

### DI Container

A DI container is a system that manages the creation and lifetime of registered objects.

ASP.NET Core has a built-in DI container.

We register the services we need, and the container provides them whenever requested.

### How to Register Services?

Services are registered inside `Program.cs` using `builder.Services`.

```csharp
builder.Services.AddTransient<TicketService>();

builder.Services.AddScoped<TicketService>();

builder.Services.AddSingleton<TicketService>();
```

## 13. Service Lifetimes

ASP.NET Core provides three main service lifetimes.

### A. Transient

```csharp
builder.Services.AddTransient<TicketService>();
```

- A new instance is created every time the service is requested from the DI container.
- Suitable for lightweight, stateless services.

### B. Scoped

```csharp
builder.Services.AddScoped<TicketService>();
```

- One instance is created per DI scope.
- In a typical web API, one scope is created per HTTP request.
- All components requesting the same scoped service within that request receive the same instance.

### C. Singleton

```csharp
builder.Services.AddSingleton<TicketService>();
```

- Only one instance is created and shared for the lifetime of the application (per service provider).
- The same instance is used across multiple requests.
- Suitable for shared services that are thread-safe.

### Comparison

| Lifetime | Instance Creation |
|---|---|
| Transient | Every time requested |
| Scoped | Once per scope / HTTP request |
| Singleton | Once for the application lifetime |

## 14. Configuration

Configuration means storing the settings an application needs to work.

### appsettings.json

The main configuration file.

It commonly stores:
- Logging settings
- Connection strings
- Application settings
- Allowed hosts

Example:

```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=TicketDB;Trusted_Connection=True;"
    },
    "Logging": {
        "LogLevel": {
            "Default": "Information"
        }
    },
    "AllowedHosts": "*"
}
```

### Environment-Specific Configuration

ASP.NET Core supports different configuration files for different environments.

| File | Purpose |
|---|---|
| `appsettings.json` | Base settings |
| `appsettings.Development.json` | Local development settings |
| `appsettings.Production.json` | Live application settings |

Environment-specific settings can override values from the base configuration.

## 15. Environment Variables

Environment variables are external values used to configure an application without directly modifying its configuration files.

They are commonly used to store:
- Database connection strings
- API keys
- Environment names
- Deployment-specific settings

Example:

```text
ASPNETCORE_ENVIRONMENT=Development
```

Environment variables can override configuration values from `appsettings.json`.

**Important:** Sensitive information such as passwords and API keys should not be committed to GitHub.

## 16. Options Pattern

The Options Pattern maps a configuration section to a C# class.

It makes configuration easier to manage and access through strongly typed objects.

Example configuration:

```json
{
    "TicketSettings": {
        "MaxTickets": 100,
        "AllowCreation": true
    }
}
```

C# class:

```csharp
public class TicketSettings
{
    public int MaxTickets { get; set; }
    public bool AllowCreation { get; set; }
}
```

Registration in `Program.cs`:

```csharp
builder.Services.Configure<TicketSettings>(
    builder.Configuration.GetSection("TicketSettings"));
```

### Types of Options

| Type | Meaning |
|---|---|
| `IOptions<T>` | Provides configuration values; does not automatically reload changes. |
| `IOptionsSnapshot<T>` | Scoped; gets updated configuration values for subsequent requests. |
| `IOptionsMonitor<T>` | Supports monitoring configuration changes and notifications. |

## 17. API Documentation

### What is OpenAPI?

OpenAPI is a specification used to describe REST APIs in a standard format.

It describes:
- Available endpoints
- HTTP methods
- Request parameters
- Request body structure
- Response formats

It helps developers understand and integrate with APIs.

### What is Swagger?

Swagger is a collection of tools used to work with OpenAPI specifications.

The most commonly used tool is **Swagger UI**.

Swagger UI provides a graphical interface where developers can:
- View available API endpoints.
- Understand request and response structures.
- Test API endpoints directly from the browser.
- View HTTP methods and status codes.

### How to Add Swagger UI?

A commonly used package is `Swashbuckle.AspNetCore`.

Install it from the project terminal:

```bash
dotnet add package Swashbuckle.AspNetCore
```

Then configure it in `Program.cs`:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Register Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
```

After running the application, Swagger UI is generally available at:

```text
https://localhost:<port>/swagger
```

# Entity Framework Core (EF Core)

## 1. Introduction to Entity Framework Core

- EF Core (Entity Framework Core) is an **ORM (Object Relational Mapper)** for .NET.
- If we want to insert data into a SQL database using C#, EF Core allows us to perform the same operations using C# objects.
- EF Core converts our C# operations into SQL queries and communicates with the database.
- It reduces the need to write SQL manually for everyday database operations.

### Key Features

- Maps C# classes to database tables.
- Supports database migrations.
- Supports relationships between tables.
- Integrates with ASP.NET Core Dependency Injection.

### How EF Core Works

Example: Creating a new ticket in a Helpdesk application.

1. Angular sends a POST request.
2. The API controller receives the request.
3. The service processes the ticket.
4. DbContext communicates with the database through EF Core.
5. EF Core generates the SQL INSERT query.
6. SQL Server stores the ticket.

---

## 2. Entity

An **Entity** is a C# class that represents data stored in a database table.

For example:

```csharp
public class Ticket
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Status { get; set; }
}
```

### Entity Conventions

EF Core follows certain naming conventions to understand how C# classes should map to database tables and columns.

**Important:** Conventions provide defaults. We can override them using Data Annotations or Fluent API, which we'll study in the Relationships section.

---

## 3. DbSet

DbSet represents a collection of entities that EF Core can query, add, update and delete.

Example:

```csharp
public DbSet<Ticket> Tickets { get; set; }
```

| Operation | Purpose |
|---|---|
| Add() | Add a new entity |
| Remove() | Delete an entity |
| Find() | Find an entity by primary key |
| Where() | Filter records |
| ToListAsync() | Retrieve records as a list |

---

## 4. DbContext

DbContext is the main class in EF Core responsible for coordinating communication between the application and the database.

It acts as a bridge between:
- C# entities
- Database tables
- EF Core database operations

### How does DbContext connect to the actual database?

Through a **Connection String**.

A connection string is a configuration string that tells an application how to connect to a database.

Example:

```text
Server=localhost;Database=HelpdeskDB;Trusted_Connection=True;TrustServerCertificate=True;
```

### How do we configure DbContext in Program.cs?

There are three things required:

1. Install the EF Core SQL Server provider.
2. Store the connection string.
3. Register our DbContext with ASP.NET Core.

#### Step 1: Install the NuGet Packages

The SQL Server provider allows EF Core to communicate with Microsoft SQL Server.

Run these commands inside your HelpdeskApi project folder:

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

We'll also need EF Core tooling for migrations later:

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
```

#### Step 2: Add the Connection String

Open `appsettings.json` and add a ConnectionStrings section.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=HelpdeskDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

If your file already contains Logging and AllowedHosts, keep those sections too. Just add ConnectionStrings at the same level.

**Why use appsettings.json?**

Because we don't want to hardcode database connection details inside our C# classes.

For real deployments, credentials and secrets should be stored securely, not committed to source control.

#### Step 3: Register DbContext in Program.cs

Add the following namespace:

```csharp
using Microsoft.EntityFrameworkCore;
```

Then, after creating the builder:

```csharp
var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
```

---

## 5. Database Migrations

Migration allows EF Core to track changes in your C# entity classes and translate those changes into database schema updates.

### Important Migration Commands

| Command | Purpose |
|---|---|
| `dotnet ef migrations add InitialCreate` | Creates a migration based on your entities |
| `dotnet ef database update` | Applies migrations to the database |
| `dotnet ef migrations list` | Lists available migrations |
| `dotnet ef migrations remove` | Removes the latest migration if it hasn't been applied |
| `dotnet ef database update PreviousMigrationName` | Reverts the database to an earlier migration |

### Migration Files

After creating a migration, you will find two important files in the Migrations folder:

1. `InitialCreate.cs` – Contains the database schema changes for that migration.
2. `ApplicationDbContextModelSnapshot.cs` – Stores the latest model snapshot used by EF Core to detect future changes.

### Creating and Applying Migrations

Step 1: Create a migration.

```bash
dotnet ef migrations add InitialCreate
```

Step 2: Apply the migration to the database.

```bash
dotnet ef database update
```

### Rolling Back a Migration

To roll back the database to a previous migration:

```bash
dotnet ef database update PreviousMigrationName
```

To roll back all migrations:

```bash
dotnet ef database update 0
```

---

## 6. Relationships in EF Core

Relationships define how records in different database tables are connected.

### 6.1 One-to-Many Relationship

One-to-Many means one record in a table can be associated with multiple records in another table.

Example:

One User can have multiple Tickets.

### Important Database Terms

| Term | Meaning |
|---|---|
| Primary Key (PK) | Uniquely identifies each record in a table |
| Foreign Key (FK) | Connects one table to another |
| Principal Entity | The entity containing the referenced primary key |
| Dependent Entity | The entity containing the foreign key |

### Handling Existing Records When Adding a Foreign Key

Two possible approaches:

1. **Development project:** Delete existing test records before applying the migration.
2. **Real production project:** Create or identify valid users, backfill existing records with their IDs, and then enforce the foreign key.

### 6.2 Foreign Key

A Foreign Key is a property in one entity that references the Primary Key of another entity.

It helps establish relationships between database tables.

Example:

```csharp
public class Ticket
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }
}
```

Here, `UserId` is the foreign key referencing the User entity.

### 6.3 Data Annotations

Data Annotations are attributes that we write directly above properties or classes to configure entities.

For example, suppose a user's name must not exceed 50 characters.

```csharp
[MaxLength(50)]
public string Name { get; set; }
```

### Important Data Annotations

| Annotation | Purpose |
|---|---|
| `[Key]` | Specifies the primary key |
| `[Required]` | Makes a property required |
| `[MaxLength(50)]` | Sets maximum length |
| `[StringLength(100)]` | Sets string length limits |
| `[ForeignKey("User")]` | Specifies a foreign key relationship |
| `[Table("Users")]` | Specifies the database table name |
| `[Column("User_Name")]` | Specifies the database column name |

### 6.4 Fluent API

Fluent API lets us configure entities and relationships using C# methods inside `OnModelCreating()` in `ApplicationDbContext`.

Example:

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Ticket>()
        .HasOne(t => t.User)
        .WithMany(u => u.Tickets)
        .HasForeignKey(t => t.UserId);
}
```

**Data Annotations vs Fluent API**

- Data Annotations: Configure entities using attributes directly inside entity classes.
- Fluent API: Configure entities using methods inside `OnModelCreating()`.

---

## 7. Querying in EF Core

### 7.1 LINQ to Entities

LINQ (Language Integrated Query) allows us to query and manipulate data directly inside C# using methods such as `Where()`, `Select()`, `OrderBy()` and `FirstOrDefault()`.

In EF Core, LINQ queries are translated into SQL queries and executed against the database.

### Important LINQ Methods

| Method | Purpose | Example |
|---|---|---|
| Where() | Filter records | `Where(t => t.Status == "Open")` |
| Select() | Select specific columns | `Select(t => t.Title)` |
| OrderBy() | Sort ascending | `OrderBy(t => t.Title)` |
| OrderByDescending() | Sort descending | `OrderByDescending(t => t.CreatedAt)` |
| FirstOrDefaultAsync() | Get first matching record or null | `FirstOrDefaultAsync(t => t.Id == 1)` |
| AnyAsync() | Check whether records exist | `AnyAsync(t => t.Status == "Open")` |
| CountAsync() | Count records | `CountAsync()` |
| ToListAsync() | Retrieve results as a list | `ToListAsync()` |

### 7.2 Include() in EF Core

`Include()` is used for **Eager Loading**.

Eager Loading means retrieving related data along with the main entity in the same query operation.

#### Include() vs Normal Query

| Normal Query | Query with Include() |
|---|---|
| `db.Tickets` | `db.Tickets.Include(t => t.User)` |
| Loads ticket data | Loads ticket and related user data |
| Related navigation property may not be populated | Related User navigation property is populated |

Example:

```csharp
var tickets = await db.Tickets
    .Include(t => t.User)
    .ToListAsync();
```

### 7.3 Multiple Include()

Suppose a ticket also has a Category relationship in the future.

We could load both relationships:

```csharp
var tickets = await db.Tickets
    .Include(t => t.User)
    .Include(t => t.Category)
    .ToListAsync();
```

### 7.4 ThenInclude()

Suppose a User has an Address, and you want to load:

**Ticket → User → Address**

You can use:

```csharp
var tickets = await db.Tickets
    .Include(t => t.User)
        .ThenInclude(u => u.Address)
    .ToListAsync();
```

`ThenInclude()` loads another level of related data.

---

## 8. Tracking vs No-Tracking in EF Core

Whenever EF Core retrieves an entity from the database, it can keep track of that entity's changes.

This behavior is called **Change Tracking**.

### 8.1 Tracking Queries

By default, EF Core tracks entities retrieved through queries.

If we modify a tracked entity and call `SaveChangesAsync()`, EF Core detects the changes and updates the database.

Example:

```csharp
var ticket = await db.Tickets.FindAsync(1);

ticket.Status = "Closed";

await db.SaveChangesAsync();
```

### 8.2 No-Tracking Queries

Sometimes we only want to display data and don't intend to modify it.

For example, displaying a list of tickets on a dashboard.

In that situation, tracking is unnecessary.

We can use `AsNoTracking()`:

```csharp
var tickets = await db.Tickets
    .AsNoTracking()
    .ToListAsync();
```

### Tracking vs No-Tracking

| Tracking | No-Tracking |
|---|---|
| EF Core tracks entity changes | EF Core does not track entity changes |
| Useful when modifying data | Useful when only reading data |
| Uses Change Tracker | Avoids Change Tracker overhead |
| Default behavior | Must be explicitly configured |

---

## 9. Data Seeding

Data Seeding means inserting initial or predefined data into a database automatically.

EF Core also supports custom initialization logic using `UseSeeding()` and `UseAsyncSeeding()` in newer versions.

### HasData() vs UseSeeding()

| HasData() | UseSeeding() |
|---|---|
| Model-managed seed data | Custom initialization logic |
| Best for fixed, predefined records | More flexible |
| Changes are managed through migrations | Runs during database initialization operations |
| Requires explicit keys | Can use more flexible logic |

### HasData() Example

```csharp
modelBuilder.Entity<Ticket>().HasData(
    new Ticket
    {
        Id = 1,
        Title = "Login Issue",
        Status = "Open"
    }
);
```

### UseSeeding()

`UseSeeding()` allows us to write custom logic for inserting initial data during database initialization.

---

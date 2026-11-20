# C# Deep Dive – LINQ, Asynchronous Programming & Language Features

## 1. LINQ in ASP.NET Core

### What is LINQ?

LINQ (Language Integrated Query) allows us to query and manipulate data directly inside C# code using SQL-like operations.

- In ASP.NET Core, LINQ is commonly used with Entity Framework Core (EF Core).
- Entity Framework Core translates LINQ queries into SQL queries.
- LINQ is used for filtering, sorting, grouping and retrieving data.
- It works with collections as well as database data.

### Types of LINQ Syntax

1. **Query Syntax:** Uses SQL-like keywords such as `from`, `where` and `select`.
2. **Method Syntax:** Uses methods such as `Where()`, `Select()` and `OrderBy()`.

**Example:**

```csharp
// Query Syntax
var result = from s in students
             where s.Marks > 80
             select s;

// Method Syntax
var result = students
             .Where(s => s.Marks > 80)
             .ToList();
```

### Important LINQ Functions

| Function | Purpose |
|---|---|
| `Where()` | Filters data based on a condition. |
| `Select()` | Selects specific data or properties. |
| `OrderBy()` | Sorts data in ascending order. |
| `OrderByDescending()` | Sorts data in descending order. |
| `GroupBy()` | Groups data based on a property. |
| `Join()` | Combines two collections using a common key. |
| `Any()` | Checks whether at least one element satisfies a condition. |
| `All()` | Checks whether all elements satisfy a condition. |
| `First()` | Returns the first matching element. |
| `Single()` | Returns exactly one matching element. |
| `Count()` | Counts the number of elements. |
| `Sum()` | Calculates the total. |
| `Average()` | Calculates the average. |

### Deferred Execution

LINQ often uses Deferred Execution, which means the query is not executed immediately when it is written.

It executes only when we enumerate or consume the result.

**Example:**

```csharp
var students = db.Students.Where(s => s.Marks > 80);
```

The query is defined but not necessarily executed yet.

```csharp
var result = students.ToList();
```

- `ToList()` executes the query.
- The retrieved results are materialized and stored in a List.
- Other materialization methods include `ToArray()`.

### Lazy Loading and Eager Loading

These concepts are used in Entity Framework Core to load related data.

**Lazy Loading:**
- Related data is loaded only when it is accessed.
- Data is loaded when required.
- Can cause multiple database queries (N+1 problem).

**Eager Loading:**
- Related data is loaded along with the main data.
- Uses the `Include()` method.
- Helps retrieve related data in advance.

**Example:**

```csharp
var students = db.Students
                 .Include(s => s.Courses)
                 .ToList();
```

---

## 2. Asynchronous Programming in C#

Asynchronous programming allows an application to perform operations without blocking the current thread while waiting for a task to complete.

### Synchronous Approach

- The application starts the database operation.
- It waits until the database responds.
- It continues only after receiving the result.
- The current thread remains blocked while waiting.

### Asynchronous Approach

- The application starts the database operation.
- It does not block the current thread while waiting.
- The thread can handle other work.
- Once the database responds, processing continues.

### Task and Task<T>

`Task` represents an asynchronous operation that may complete in the future.

There are two main types:

| Type | Description |
|---|---|
| `Task` | Represents an asynchronous operation that does not return a result. |
| `Task<T>` | Represents an asynchronous operation that returns a result of type T. |

**Example:**

```csharp
// Task - No return value
public async Task SaveData()
{
    await Task.Delay(1000);
}

// Task<T> - Returns a value
public async Task<int> GetNumber()
{
    await Task.Delay(1000);
    return 10;
}
```

### Async and Await

`async` and `await` are keywords used to write asynchronous code.

**async:**
- Marks a method as asynchronous.
- Allows the use of `await` inside the method.

**await:**
- Waits for an asynchronous operation to complete.
- Does not block the current thread while waiting.
- Continues execution after the operation completes.

**Example:**

```csharp
public async Task<List<Student>> GetStudents()
{
    var students = await db.Students.ToListAsync();

    return students;
}
```

### Async All the Way

Once an operation becomes asynchronous, we should generally keep using asynchronous methods throughout the calling chain instead of blocking to get the results.

**Why?**
- Avoids unnecessary thread blocking.
- Improves application scalability.
- Prevents potential deadlocks caused by blocking asynchronous operations.

**Avoid:**

```csharp
var result = GetStudentsAsync().Result;
```

**Prefer:**

```csharp
var result = await GetStudentsAsync();
```

### CancellationToken

A `CancellationToken` allows a caller to communicate that an operation should stop if possible.

It is a cooperative cancellation mechanism, meaning the operation must observe the token and respond to cancellation.

**CancellationToken in ASP.NET Core:**

- ASP.NET Core can provide a cancellation token for an incoming HTTP request.
- If the client disconnects or the request is cancelled, the token can signal cancellation.
- It can be passed to database operations and other asynchronous methods.

**Example:**

```csharp
public async Task<List<Student>> GetStudents(
    CancellationToken cancellationToken)
{
    return await db.Students
                   .ToListAsync(cancellationToken);
}
```

---

## 3. C# Language Features

### 3.1 Generics

Generics allow us to write reusable code that works with different data types without writing separate code for each type.

**Uses:**
- Makes code reusable.
- Provides type safety.
- Reduces code duplication.
- Avoids unnecessary type conversions.

**Types of Generics:**
- Generic Classes
- Generic Methods
- Generic Interfaces

**Example – Generic Class:**

```csharp
public class Box<T>
{
    public T Value { get; set; }
}

Box<int> box1 = new Box<int>();
box1.Value = 10;

Box<string> box2 = new Box<string>();
box2.Value = "Hello";
```

Here, `T` represents a placeholder for a data type.

**Generic Constraints:**

The `where` keyword is used to restrict which types can be used with a generic class or method.

**Example:**

```csharp
public class Repository<T> where T : class
{
}
```

Here, `T` must be a reference type.

### 3.2 Delegates and Lambda Expressions

#### Delegates

A delegate is a type-safe reference to a method.

It allows us to store a method reference in a variable and call that method through the delegate.

**Uses:**
- Passing methods as arguments.
- Implementing callback methods.
- Supporting event handling.

#### Built-in Delegates

C# provides built-in delegate types, so we do not always need to declare our own.

| Delegate | Purpose |
|---|---|
| `Action` | Performs an operation; returns nothing. |
| `Func` | Performs an operation and returns a value. |
| `Predicate` | Checks a condition and returns a Boolean value. |

**Example:**

```csharp
Action<string> greet = name => Console.WriteLine(name);

Func<int, int> square = x => x * x;

Predicate<int> isEven = x => x % 2 == 0;

greet("Hello");
Console.WriteLine(square(5));
Console.WriteLine(isEven(10));
```

#### Lambda Expressions

A lambda expression is a shorter way to write an anonymous function (a function without a name).

It uses the `=>` operator, known as the lambda operator.

**Syntax:**

```csharp
(parameters) => expression
```

**Example:**

```csharp
Func<int, int> square = x => x * x;
```

Here, `x => x * x` is a lambda expression.

### 3.3 Extension Methods

Extension methods allow us to add new methods to an existing type without modifying its original code or inheriting from it.

**Rules:**

1. Must be declared inside a non-nested static class.
2. The extension method itself must be static.
3. The first parameter must have the `this` keyword.
4. The first parameter specifies the type being extended.
5. The namespace containing the extension class must be in scope.

**Example:**

```csharp
public static class StringExtensions
{
    public static string ToUpperCase(this string text)
    {
        return text.ToUpper();
    }
}
```

**Usage:**

```csharp
string name = "hello";

Console.WriteLine(name.ToUpperCase());
```

Here, `ToUpperCase()` is added as an extension method to the existing String type.

### 3.4 Pattern Matching

Pattern matching allows us to check the type, value or structure of an object and execute code based on the matched pattern.

It makes conditional statements easier to read and write.

**Types of Pattern Matching:**

#### 1. Type Pattern

Checks whether a variable is of a particular type.

```csharp
if (value is string)
{
    Console.WriteLine("Value is a string");
}
```

#### 2. Switch Pattern

Uses a switch expression or statement to match different patterns.

```csharp
string result = value switch
{
    int => "Integer",
    string => "String",
    bool => "Boolean",
    _ => "Unknown"
};
```

#### 3. Relational Pattern

Checks values using comparison operators such as `>`, `<`, `>=` and `<=`.

```csharp
int marks = 85;

string result = marks switch
{
    >= 90 => "Excellent",
    >= 75 => "Good",
    >= 50 => "Average",
    _ => "Fail"
};
```

#### 4. Property Pattern

Checks the properties of an object.

```csharp
if (student is { Marks: >= 80 })
{
    Console.WriteLine("Good performance");
}
```

---

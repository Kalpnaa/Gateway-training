# .NET Fundamentals

## 1. Introduction to .NET

.NET is an open-source, cross-platform framework developed by Microsoft for application and web development.

- **SDK:** A collection of tools used to write, create, build, and develop .NET applications.
- **Runtime:** Used for running .NET applications.

## 2. The .NET CLI: New, Build, and Run

The .NET SDK installs a command-line tool called `dotnet`. It is used to manage the development lifecycle.

- **dotnet new:** Creates a new project using a specified template.
  - Example: `dotnet new console -o MyFirstApp`
  - Creates a new console application in a folder named MyFirstApp.

- **dotnet build:** Compiles the project and its dependencies into Intermediate Language (IL) code. It generates output files like `.dll` in the `bin/` directory. It checks for errors without running the application.

- **dotnet run:** Builds the application (if required) and executes it. It is commonly used during development to test the application.

## 3. Standard Project Structure

When we create a new console application using `dotnet new console`, .NET generates the following structure:

    MyFirstApp/
    ├── MyFirstApp.csproj   # Project configuration file
    ├── Program.cs          # Entry point containing our code
    ├── obj/                # Temporary files used during compilation
    └── bin/                # Output files (.dll, .exe)

- **MyFirstApp.csproj:** An XML-based file that tells .NET how to handle the project. It contains target framework settings, NuGet package dependencies, and project properties.

  Example: `<TargetFramework>net8.0</TargetFramework>`

- **Program.cs:** The main source file where our C# application logic begins execution.

## 4. Top-Level Statements

Introduced in C# 9, top-level statements eliminate boilerplate code by allowing us to write executable code directly without explicitly creating a Program class or Main method.

### Traditional C# Structure (Before Top-Level Statements)

    using System;

    namespace MyFirstApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello, World!");
            }
        }
    }

### Modern C# Structure (With Top-Level Statements)

In modern .NET templates, Program.cs contains one line by default:

    Console.WriteLine("Hello, World!");

**How it works:**

- Behind the scenes, the compiler automatically generates the namespace, class, and Main method for us.
- We can access command-line arguments using the built-in `args` variable.
- We can use `await` directly.
- Top-level statements can be used in only one file within a project.

## 5. Types and Variables

### 1. Value Types

Value types directly store their values.

- **int:** `int age = 25;`
- **long:** `long salary = 1000000L;`
- **float:** `float num = 5.5f;`
- **double:** `double pi = 3.145;`
- **decimal:** `decimal bankbalance = 1500.50m;`
- **bool:** `bool value = true;`
- **char:** `char val = 'A';`

### 2. Reference Types

Reference types store references to objects.

- **string:** `string name = "Kalpana";`
- **object:** `object anything = "Hello";`
- **arrays:** `int[] arr = {1, 2, 3};`

### 3. var

- Automatically guesses the data type of a variable based on the assigned value.
- The data type is determined at compile time.

Example:

    var val = 60;

### 4. Constant

- A constant is a variable whose value cannot be changed after declaration.
- We use the `const` keyword.

Example:

    const double val = 9.06;

### 5. Nullable Types

- Used when a value-type variable can also contain null.

Example:

    int? age = null;
    char? var = 'A';

## 6. Type Conversion

### 1. Implicit Casting

- Happens automatically when moving data from a smaller-range compatible data type to a larger-range type.

Example:

    float smallnum = 5.5f;
    double largenum = smallnum;

### 2. Explicit Casting

- Manual conversion when moving data between types where information may be lost.
- Uses the casting operator.

Example:

    double pi = 3.1567;
    int ipi = (int)pi;

Output: `3`

### 3. Parse()

- When the text contains a valid number, we can convert its data type into a numeric format.
- Throws an exception if the input is invalid.

Example:

    string txt = "34";
    int age = int.Parse(txt);

### 4. TryParse()

- If the text is not a valid number, it returns false; otherwise, it converts the value and returns true.
- It does not throw an exception for invalid numeric input.

Example:

    string txt = "42";
    int.TryParse(txt, out int parsednumber);

### 5. Convert Class

- A class of built-in methods used to convert one data type into another.
- Some commonly used methods:

  - `Convert.ToInt32()`
  - `Convert.ToDouble()`
  - `Convert.ToString()`

Example:

    string txt = null;
    int res = Convert.ToInt32(txt);

- `Convert.ToInt32(null)` gives the result `0`, while `int.Parse(null)` throws an exception.

---

## Topics Covered

- [x] Introduction to .NET
- [x] SDK and Runtime
- [x] .NET CLI Commands
- [x] Standard Project Structure
- [x] Top-Level Statements
- [x] Types and Variables
- [x] Type Conversion
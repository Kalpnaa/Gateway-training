# .NET Fundamentals

## 1. Introduction to .NET

.NET is an open-source, cross-platform framework developed by Microsoft for application and web development.

- **SDK:** A collection of tools used to write, create, build, and develop .NET applications.
- **Runtime:** Used for running .NET applications.

## 2. The .NET CLI: New, Build, and Run

The .NET SDK installs a command-line tool called `dotnet`. It is used to manage the development lifecycle.

- **dotnet new:** Creates a new project using a specified template.
  - Example: `dotnet new console -o MyFirstApp`
  - Creates a new console application in a folder named `MyFirstApp`.

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

- When the text contains a valid number, we can convert it into a numeric data type.
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

## 7. Operators

### 1. Arithmetic Operators

- `+`, `-`, `*`, `%`

### 2. Comparison Operators

- `==` (Equal to), `!=` (Not equal to)
- `>` (Greater than), `<` (Less than)
- `>=` (Greater than or equal to), `<=` (Less than or equal to)

### 3. Logical Operators

- `&&` (AND): Returns true only if both sides are true.
- `||` (OR): Returns true if at least one side is true.
- `!` (NOT): Inverts the value (turns true to false and vice versa).

### 4. Ternary Operator

The ternary operator (`? :`) is a clean, single-line way to write a simple if-else statement. It decides between two values based on a condition.

Syntax: `condition ? value_if_true : value_if_false;`

### 5. Null-Coalescing Operator (`??`)

- When dealing with variables that could be empty (null), the `??` operator lets you define a fallback/default value if the primary variable is missing.

    string? guestName = null;

    // If guestName is null, use "Anonymous" instead
    string displayName = guestName ?? "Anonymous";

    Console.WriteLine(displayName); // Prints: Anonymous

### 6. Null-Conditional Operator (`?.`) (The Safe Navigator)

- If you try to read a property or call a method on something that is null, your program may crash. The `?.` operator safely checks if the item is null first. If it is null, it returns null instead of accessing the member.

    string? websiteInput = null;

    // Without the '?', this would crash because websiteInput is null
    int? characterCount = websiteInput?.Length;

    Console.WriteLine(characterCount); // Prints nothing (null), but does NOT crash!

## 8. Control Flow

### 1. Decision Making

- if/else
- switch
- switch expressions

Example:

    int layer = 3;

    string layerName = layer switch
    {
        1 => "Data Link",
        2 => "Network",
        3 => "Transport", // Matches here
        _ => "Unknown Layer" // The default fallback case
    };

### 2. Loops

- for
- foreach

Example:

    string[] names = { "Alice", "Bob", "Charlie" };

    foreach (string name in names)
    {
        Console.WriteLine($"Hello, {name}!");
    }

- while
- do while
- break and continue

## 9. Methods (Functions)

### 1. Parameters and Return Value

- **Parameter:** Input you pass into the method.
- **Return value:** The value a method sends back after execution.

### 2. Method Overloading

- Multiple methods with the same name but different parameter types or numbers of inputs.

Example:

    int Multiply(int a, int b) => a * b;
    double Multiply(double a, double b) => a * b;

### 3. Optional and Named Parameters

- **Optional parameters:** You can assign a default value to a parameter.
- **Named parameters:** When calling a method, you can explicitly state which value goes to which parameter by name using a colon (:).

### 4. ref vs out

- **ref (Reference):** The variable must already have a value before you pass it in. The method can read it and modify it.
- **out (Output):** The variable doesn't need a value beforehand. The method promises to assign a value to it before it finishes.

### 5. Expression-Bodied Methods

If a method contains only one line of code, you can remove the curly brackets {} and the return keyword. Instead, use the lambda arrow (=>).

    int SquareNew(int x) => x * x;

## 10. Strings

### 1. String Immutability

- Strings are immutable, which means their values cannot be changed after they are created. Any modification creates a new string.

### 2. String Interpolation

- Instead of combining strings using + symbols, modern C# uses string interpolation. Put a $ sign before your double quotes, and you can insert variables directly into the text using curly braces {}.

    string message = $"Welcome back, {user}! Your high score is {score}.";

### 3. String Methods

- **Split()** -> Splits a single string into an array based on a separator.

      string alpha = "a,b,c,d";
      string[] al = alpha.Split(',');

- **Substring()** -> Extracts a sub-section.

      string word = "Developer";
      string slice1 = word.Substring(0, 3);

- **Trim()** -> Cleans up whitespace.

      string messyInput = "   hello world!   ";
      string cleanInput = messyInput.Trim();

- **Contains()** -> Searches inside text.

      string text = "I love coding";
      bool hasCoding = text.Contains("coding");

- **Replace()** -> Swaps out text.

      string sentence = "I hate bugs.";
      string fixedSentence = sentence.Replace("hate", "love");

### 4. StringBuilder

- Because strings are immutable, modifying a string inside a loop creates extra string objects in memory.
- StringBuilder creates a flexible, editable workspace in memory where you can add, remove, or modify characters without creating a new string for every change.

Example:

    StringBuilder goodResult = new StringBuilder();

    for (int i = 0; i < 10; i++)
    {
        goodResult.Append(i); // Efficiently appends to the end
    }

## 11. Collections

### 1. Array

- Collection of items.
- Fixed size when created.

### 2. List

- Automatically expands or shrinks as you add or remove items.
- A dynamic, resizable array.
- `<T>` is the syntax for generics. Substitute T with int, string, etc.

Example:

    List<string> shoppingList = new List<string>();
    shoppingList.Add("Milk");

### 3. Dictionary

- Stores pairs of data containing a unique key and a specific value.

### 4. HashSet<T>

- An unordered collection that contains only unique elements.

Example:

    HashSet<int> uniqueIds = new HashSet<int>();

### 5. Looping Over Collections

- To extract data from collections, you can use for or foreach loops.

**A. Looping over an Array/List using an index counter**

    for (int i = 0; i < luckyNumbers.Length; i++)
    {
        Console.WriteLine($"Index {i} holds value: {luckyNumbers[i]}");
    }

**B. Sequentially iterating over a HashSet or List**

    foreach (int id in uniqueIds)
    {
        Console.WriteLine($"Processing ID: {id}");
    }

**C. Interacting with Dictionary key-value items**

    foreach (KeyValuePair<string, decimal> item in productCatalog)
    {
        Console.WriteLine($"Key: {item.Key} | Value: ${item.Value}");
    }

## 12. Exceptions

### 1. try/catch/finally

- **try:** Code that might cause an error goes inside this block.
- **catch:** If an exception occurs in the try block, the code inside catch executes.
- **finally:** Always runs.

### 2. Common Exceptions

- NullReferenceException
- IndexOutOfRangeException
- FormatException
- ArgumentNullException

### 3. Throwing Exceptions

- Throwing an exception when a certain condition occurs.

### 4. Creating Custom Exceptions

- Create your own custom exceptions by building a class that inherits from the core Exception class.

Example:

    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }

## 13. Dates and Times

### 1. DateTime

- Stores a date and time (like 2026-11-04 19:08:00), but it does not explicitly know its time zone.

### 2. DateTimeOffset

- Stores an exact date and time plus its offset (difference) from UTC/Greenwich time.

### 3. UTC Time

- The global standard baseline time. It has no local time zone shifts or daylight saving adjustments.

### 4. Local Time

- The time relative to the specific computer running the code.

### 5. TimeSpan

- While DateTimeOffset represents a specific calendar moment, a TimeSpan represents a duration of elapsed time (hours, minutes, seconds, or days).
- You can generate a TimeSpan by subtracting one point in time from another, or by creating a custom span manually.

---

## Topics Covered

- [x] Introduction to .NET
  - [x] SDK and Runtime
- [x] .NET CLI
  - [x] dotnet new
  - [x] dotnet build
  - [x] dotnet run
- [x] Standard Project Structure
  - [x] .csproj and Program.cs
  - [x] bin and obj folders
- [x] Top-Level Statements
  - [x] Traditional and modern C# structure
- [x] Types and Variables
  - [x] Value Types and Reference Types
  - [x] var keyword
  - [x] Constants
  - [x] Nullable Types
- [x] Type Conversion
  - [x] Implicit and Explicit Casting
  - [x] Parse() and TryParse()
  - [x] Convert Class
- [x] Operators
  - [x] Arithmetic Operators
  - [x] Comparison Operators
  - [x] Logical Operators
  - [x] Ternary Operator
  - [x] Null-Coalescing Operator (??)
  - [x] Null-Conditional Operator (?.)
- [x] Control Flow
  - [x] Decision Making (if/else, switch, switch expressions)
  - [x] Loops (for, foreach, while, do while)
  - [x] break and continue
- [x] Methods (Functions)
  - [x] Parameters and Return Values
  - [x] Method Overloading
  - [x] Optional and Named Parameters
  - [x] ref and out
  - [x] Expression-Bodied Methods
- [x] Strings
  - [x] String Immutability
  - [x] String Interpolation
  - [x] String Methods
  - [x] StringBuilder
- [x] Collections
  - [x] Arrays
  - [x] Lists
  - [x] Dictionaries
  - [x] HashSet
  - [x] Looping Over Collections
- [x] Exceptions
  - [x] try/catch/finally
  - [x] Common Exceptions
  - [x] Throwing Exceptions
  - [x] Custom Exceptions
- [x] Dates and Times
  - [x] DateTime
  - [x] DateTimeOffset
  - [x] UTC and Local Time
  - [x] TimeSpan
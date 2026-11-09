
1. Classes and Objects

• Classes and Objects: A class is a blueprint or template (e.g., Car). An object is an instance of that class created in memory (e.g., myTesla).
• Fields vs. Properties:
	• Fields are variables declared directly in a class (usually private to protect data).
	• Properties expose fields safely using get and set accessors.
• Auto-Properties: If you don't need custom logic, auto-implemented properties generate a hidden backing field automatically.
• The init Accessor: Introduced in C# 9, init allows a property to be set only during object creation. After that, it becomes strictly read-only.
• Constructors: Special methods used to initialize objects. They share the exact name of the class and have no return type.
• The this Keyword: Refers to the current instance of the class. It helps resolve ambiguity when a parameter name matches a class field name.
• Object Initializers: Allow you to assign values to any accessible fields or properties of an object at creation time without explicitly invoking a parameterized constructor.
csharp
public class Car
{
    // 1. Field
    private string _model; 

    // 2. Classic Property with validation
    public string Model 
    {
        get { return _model; }
        set { _model = string.IsNullOrWhiteSpace(value) ? "Unknown" : value; }
    }

    // 3. Auto-property
    public int Year { get; set; } 

    // 4. Init-only property (Immutable after creation)
    public string Vin { get; init; } 

    // 5. Constructor using 'this' to resolve ambiguity
    public Car(string model, string vin)
    {
        this.Model = model; 
        this.Vin = vin;
    }
}

// 6. Object Initializer syntax
Car myCar = new Car("Model S", "12345XYZ") 
{ 
    Year = 2026 // Assigned right at instantiation
};
Use code with caution.

2. Encapsulation

Encapsulation means hiding an object's internal state and requiring all interaction to occur through public methods and properties.

Access Modifiers

• public: Accessible from any code in the project or other assemblies referencing it.
• private: Accessible only within the same class. (Default for class members).
• protected: Accessible within the same class and by any derived (child) classes.
• internal: Accessible from any code within the same compilation assembly (.dll/.exe), but not from other assemblies.

Read-Only Properties & Value Validation

Encapsulation allows you to protect data by either completely removing the set block (making it read-only) or validating inputs before saving them.
csharp
public class BankAccount
{
    // Read-only property: external code can read, but never rewrite it directly
    public string AccountNumber { get; } 
    
    private decimal _balance;
    public decimal Balance 
    {
        get => _balance;
        // Data Validation in Setter
        set 
        {
            if (value < 0) 
                throw new ArgumentException("Balance cannot be negative.");
            _balance = value;
        }
    }

    public BankAccount(string accNum) => AccountNumber = accNum;
}
Use code with caution.

3. Inheritance

Inheritance allows a derived class (child) to reuse, extend, or modify the behavior of a base class (parent).
• The base Keyword: Used to access members of the base class from within a derived class (e.g., calling a base method or constructor).
• Constructor Chaining: When initializing a child class, its constructor must call the parent constructor first. This is explicitly managed using : base(...).
• Sealed Classes: Marking a class as sealed prevents other classes from inheriting from it. It boosts performance slightly and prevents unintended design extensions.
csharp
public class Vehicle // Base Class
{
    public string Brand { get; set; }
    public Vehicle(string brand) => Brand = brand; // Parent Constructor
}

public sealed class Truck : Vehicle // Derived Class & cannot be inherited further
{
    public double PayloadCapacity { get; set; }

    // Constructor Chaining: passes 'brand' up to the Vehicle constructor
    public Truck(string brand, double capacity) : base(brand)
    {
        PayloadCapacity = capacity;
    }
}
Use code with caution.

4. Polymorphism

Polymorphism means "many forms." It allows objects of different classes to be treated as objects of a common base class.
• Compile-time Polymorphism (Overloading): Multiple methods in the same class share the exact same name but have different signatures (different parameter types or counts).
• Runtime Polymorphism (Overriding): A child class provides a specific implementation of a method that is already defined in its parent class. The parent method must be marked virtual or abstract, and the child method must use override.
• Method Hiding (new keyword): If a child class defines a method with the exact same signature as a parent class method without overriding it, it hides the parent method. The new keyword explicitly signals this intent.
csharp
public class Calculator
{
    // Compile-time Polymorphism (Overloading)
    public int Add(int a, int b) => a + b;
    public double Add(double a, double b) => a + b;
}

public class Animal
{
    public virtual void MakeSound() => Console.WriteLine("Generic animal sound");
    public void Sleep() => Console.WriteLine("Sleeping...");
}

public class Dog : Animal
{
    // Runtime Polymorphism (Overriding)
    public override void MakeSound() => Console.WriteLine("Bark!");

    // Method Hiding (Hides Animal.Sleep)
    public new void Sleep() => Console.WriteLine("Dog sleeping lightly...");
}
Use code with caution.

5. Abstraction

Abstraction involves hiding background details and showing only essential features. It is achieved using abstract classes and interfaces.

Abstract Class vs. Interface


Feature	Abstract Class	Interface
Inheritance	A class can inherit only one abstract class.	A class can implement multiple interfaces.
State	Can contain fields, fields instances, and state.	Cannot contain instance fields (C# interfaces store no state).
Implementation	Can have fully implemented methods alongside abstract ones.	Traditionally declaration-only (though C# 8+ allows Default Implementations).
Access Modifiers	Members can be private, protected, internal, etc.	Members are implicitly public by default.

csharp
public interface IFlyable { void Fly(); }
public interface ISwimmable { void Swim(); }

public abstract class Bird
{
    public abstract void Eat(); // No body, must be implemented by child
    public void Breathe() => Console.WriteLine("Breathing..."); // Concrete implementation
}

// Implementing an Abstract class and Multiple Interfaces simultaneously
public class Duck : Bird, IFlyable, ISwimmable
{
    public override void Eat() => Console.WriteLine("Duck is eating grain.");
    public void Fly() => Console.WriteLine("Duck is flying.");
    public void Swim() => Console.WriteLine("Duck is swimming.");
}
Use code with caution.

6. Static Members

Static members belong to the class itself rather than to a specific object instance.
• Static Fields: Shared across every single instance of the class. If one object changes a static field, it changes for all.
• Static Methods: Executed without creating an instance of the class (e.g., Math.Sqrt()). They can only access other static members; they cannot access instance fields (this is unavailable).
• Static Classes: Can only contain static members. You cannot instantiate a static class using the new keyword.
csharp
public static class IdentityGenerator
{
    private static int _counter = 0; // Static field: shared globally

    public static int GetNextId()    // Static method
    {
        _counter++;
        return _counter;
    }
}
// Usage: int id = IdentityGenerator.GetNextId(); (No instantiation required)
Use code with caution.

7. Structs and Records


Struct vs. Class (Value vs. Reference Behavior)

• Class (Reference Type): Stored on the Heap. When you copy a class variable, you copy the reference (pointer) to the memory block. Editing the copy changes the original.
• Struct (Value Type): Stored on the Stack. When you copy a struct variable, you copy the actual values. Editing the copy does not alter the original. Structs cannot inherit other classes.

Records

Introduced in C# 9, a record can be a class or a struct. It is specifically built for simple, immutable data models. They automatically implement value-based equality checking (instead of reference checking) and clean ToString() outputs.
csharp
// Struct: Value type
public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
}

// Record: Concise, immutable data model with built-in value equality
public record UserRecord(string Username, string Email);

// Usage demonstration
UserRecord user1 = new UserRecord("dev1", "a@b.com");
UserRecord user2 = new UserRecord("dev1", "a@b.com"); 

bool areEqual = (user1 == user2); // Evaluates to TRUE because values are identical
Use code with caution.

8. Composition over Inheritance

• Inheritance is an "Is-A" relationship: A Dog is a Animal.
• Composition is a "Has-A" relationship: A Car has an Engine.

When to choose each?

• Inheritance: Use strictly when a tight, polymorphic relationship exists where the child truly matches every aspect of the parent's definition.
• Composition: Prefer this by default. It is highly flexible. You can swap internal behaviors out at runtime or easily test modules in isolation without bringing down a heavy parent class hierarchy.
csharp
public class Engine 
{
    public void Start() => Console.WriteLine("Engine Vroom!");
}

public class Car // Composition: Car 'has an' Engine
{
    private readonly Engine _engine = new Engine();

    public void Drive()
    {
        _engine.Start();
        Console.WriteLine("Car is moving.");
    }
}
Use code with caution.

9. SOLID Principles


Single Responsibility Principle (SRP)

A class should have one, and only one, reason to change.
• Example: Separate processing logic from reporting/printing logic.
csharp
public class Invoice { public void CalculateTotal() { /* ... */ } }
public class InvoicePrinter { public void Print(Invoice inv) { /* Print logic */ } }
Use code with caution.

Open/Closed Principle (OCP)

Software entities should be open for extension, but closed for modification.
• Example: Use inheritance or interfaces instead of modifying a core evaluation switch statement every time you add features.
csharp
public abstract class Shape { public abstract double Area(); }
public class Square : Shape { public double Side {get;set;} public override double Area() => Side * Side; }
// Adding a Circle requires adding a new class, not changing existing Shape logic!
Use code with caution.

Liskov Substitution Principle (LSP)

Derived classes must be completely substitutable for their base classes without breaking behavior.
• Example: A classic violation is making an Ostrich inherit from a Bird class that has a throwing Fly() method. Instead, separate the responsibilities.
csharp
public class Bird { public virtual void Eat() { /* ... */ } }
public class FlyingBird : Bird { public virtual void Fly() { /* ... */ } }
public class Ostrich : Bird { /* Safely inherits only what it can actually do */ }
Use code with caution.

Interface Segregation Principle (ISP)

Clients should not be forced to depend on interfaces they do not use.
• Example: Break bulky, bloated interfaces into tiny, focused ones.
csharp
// Bad: public interface IWorker { void Work(); void Eat(); }
// Good: Split them up!
public interface IWorkable { void Work(); }
public interface IEatable { void Eat(); }
Use code with caution.

Dependency Inversion Principle (DIP)

High-level modules should not depend on low-level modules. Both should depend on abstractions.
• Example: Do not hardcode a database client inside a business service class. Pass an interface via the constructor.
csharp
public interface ICamperDatabase { void Save(); }
public class CarRentalService
{
    private readonly ICamperDatabase _db;
    public CarRentalService(ICamperDatabase db) => _db = db; // Injected dependency abstraction
}
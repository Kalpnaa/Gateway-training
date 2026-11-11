# C# Object-Oriented Programming (OOP) – Complete Coderbyte Test Preparation Notes

These notes cover your complete Gateway OOP syllabus, including theory, C# syntax, code examples, output-based questions, tricky MCQ concepts, and coding patterns.

The goal is not just to understand OOP but to prepare you for the kind of questions that can appear in a Coderbyte assessment.

How to use these notes

- First understand the concept and terminology.
- Study the code examples carefully.
- Pay attention to the highlighted interview/MCQ traps.
- Practise predicting outputs without running the code.
- Revise the comparison tables before your test.

Coverage

All 9 syllabus areas

## 1. Classes and Objects

### 1.1 What is a class?

A class is a blueprint or template used to create objects. It defines the data (fields/properties) and behaviour (methods) of objects.

Example: A `Car` class defines properties such as Brand, Color and Speed, and methods such as Start() and Stop().

### 1.2 What is an object?

An object is an instance of a class.

- A class is a blueprint.
- An object is an actual entity created using that blueprint.
- Each object has its own instance fields and properties.

```
class Car
{
    public string Brand;
    public int Speed;

    public void Start()
    {
        Console.WriteLine("Car started");
    }
}

class Program
{
    static void Main()
    {
        Car car1 = new Car();

        car1.Brand = "BMW";
        car1.Speed = 100;

        car1.Start();

        Console.WriteLine(car1.Brand);
    }
}
```

Output:

```
Car started
BMW
```

Here:

- `Car` = class.
- `car1` = object reference variable.
- `new Car()` = creates an object.
- `Brand`, `Speed` = fields.
- `Start()` = method.

### 1.3 Fields

A field is a variable declared directly inside a class or struct.

```
class Student
{
    public string Name;
    public int Age;
}
```

Important:

- Fields store data.
- Fields can be instance or static.
- Fields without explicit initialization get default values.

| Data type       | Default value |
| --------------- | ------------- |
| int             | 0             |
| double          | 0.0           |
| bool            | false         |
| char            | '\0'          |
| string          | null          |
| Reference types | null          |

### 1.4 Properties

Properties provide controlled access to fields.

They use `get` and `set` accessors.

Auto-property

```
class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
}
```

C# automatically creates a hidden backing field.

Get and Set property

```
class Student
{
    private int age;

    public int Age
    {
        get { return age; }
        set { age = value; }
    }
}
```

- `get` retrieves the value.
- `set` modifies the value.
- `value` is an implicit parameter containing the assigned value.

Example:

```
Student s = new Student();
s.Age = 21;
Console.WriteLine(s.Age);
```

Auto-property with validation

```
class Student
{
    private int age;

    public int Age
    {
        get { return age; }
        set
        {
            if (value >= 18)
                age = value;
            else
                Console.WriteLine("Invalid age");
        }
    }
}
```

Read-only property

```
class Employee
{
    public int Id { get; }

    public Employee(int id)
    {
        Id = id;
    }
}
```

A get-only auto-property can be assigned inside the constructor or at initialization.

Init-only property

```
class Student
{
    public string Name { get; init; }
}
```

Usage:

```
Student s = new Student
{
    Name = "Kalpana"
};
```

`init` allows setting a property during object initialization but prevents normal reassignment afterwards.

### 1.5 Difference between get, set and init

| Accessor | Purpose                                                                 |
| -------- | ----------------------------------------------------------------------- |
| get      | Read property                                                           |
| set      | Read and modify property                                                |
| init     | Read and initialize property only during object creation/initialization |

### 1.6 Constructors

A constructor is a special method that initializes an object when it is created.

Rules:

1. Constructor name must match the class name.
2. It has no return type, not even `void`.
3. It is automatically called when an object is created.
4. Constructors can be overloaded.

Default constructor

```
class Student
{
    public Student()
    {
        Console.WriteLine("Default constructor");
    }
}
```

Parameterized constructor

```
class Student
{
    public string Name;
    public int Age;

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
```

Constructor overloading

```
class Student
{
    public string Name;
    public int Age;

    public Student()
    {
        Name = "Unknown";
        Age = 0;
    }

    public Student(string name)
    {
        Name = name;
        Age = 18;
    }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
```

Different constructors have different parameter lists.

### 1.7 The `this` keyword

`this` refers to the current instance of the class.

Common uses:

1\. Differentiate fields from parameters

```
class Student
{
    string name;

    public Student(string name)
    {
        this.name = name;
    }
}
```

- `this.name` = class field.
- `name` = constructor parameter.

2\. Call another constructor

```
class Student
{
    public string Name;
    public int Age;

    public Student() : this("Unknown", 18)
    {
    }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
```

This is called constructor chaining.

### 1.8 Object initializers

Object initializers allow assigning properties or accessible fields while creating an object.

```
class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
}

Student s = new Student
{
    Name = "Rahul",
    Age = 21
};
```

The constructor executes first, followed by the object initializer assignments.

Coderbyte important

Remember these distinctions:

- Constructor initializes an object.
- `this` refers to the current object.
- Properties provide controlled access to data.
- `init` prevents reassignment after initialization.
- Object initializers assign values during object creation.

## 2. Encapsulation

### 2.1 What is encapsulation?

Encapsulation is the process of combining data and methods into a single unit (class) and restricting direct access to internal data.

It protects data from unwanted modifications.

For example, a bank account should not allow anyone to directly change its balance.

### 2.2 Access modifiers

Access modifiers determine where a class member can be accessed.

| Modifier           | Accessibility                                               |
| ------------------ | ----------------------------------------------------------- |
| public             | Accessible from anywhere permitted by the type's visibility |
| private            | Accessible only within the containing type                  |
| protected          | Accessible within the containing type and derived types     |
| internal           | Accessible within the same assembly                         |
| protected internal | Same assembly OR derived types                              |
| private protected  | Same assembly AND derived types                             |

Your syllabus focuses on the first four, but remember the last two as well.

### 2.3 Example of access modifiers

```
class Employee
{
    public string Name;
    private int salary;
    protected int age;
    internal string Department;
}
```

- `Name`: accessible wherever Employee is accessible.
- `salary`: accessible only inside Employee.
- `age`: accessible inside Employee and derived classes.
- `Department`: accessible within the same assembly.

### 2.4 Encapsulation using private fields and public properties

```
class BankAccount
{
    private double balance;

    public double Balance
    {
        get { return balance; }
        private set { balance = value; }
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
        }
    }

    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
        }
    }
}
```

Usage:

```
BankAccount account = new BankAccount();

account.Deposit(5000);
account.Withdraw(1000);

Console.WriteLine(account.Balance);
```

Output:

```
4000
```

You cannot directly execute:

```
account.balance = 10000;
```

Because `balance` is private.

You also cannot execute `account.Balance = 10000` because its setter is private.

### 2.5 Read-only properties

```
class Employee
{
    public int EmployeeId { get; }

    public Employee(int id)
    {
        EmployeeId = id;
    }
}
```

The ID can be read from outside but cannot normally be assigned from outside after construction.

### 2.6 Benefits of encapsulation

1. Data security.
2. Controlled access.
3. Data validation.
4. Easier maintenance.
5. Reduced unwanted modifications.

MCQ trap

Question: Which access modifier provides the highest restriction among public, private, protected and internal?

Answer: `private`.

Question: Can a derived class directly access a private member of its base class?

Answer: No.

## 3. Inheritance

### 3.1 What is inheritance?

Inheritance allows one class to acquire the properties and methods of another class.

It promotes code reusability.

- Base class / Parent class: the class being inherited.
- Derived class / Child class: the class that inherits.

Example: A Manager is an Employee.

[Mastering inheritance in class diagrams | Gleek | Gleek](https://images.openai.com/static-rsc-4/kDNFzc3VqNngnMTbLZRs5a6J2r72jItEgN4XTdDUKyWQ1xPBJXlZJi5Txeq3lNanj_Ea68XlY6H3Kk8bqYfVlzwMHJUK_-POpHUyMRSXm15xeAR3KF0iarbJa7vdO3dziPf34OcyLeXlr7EpN86ZfW4q3xytCUU_74lvSrFsiFE?purpose=inline)

[gleek.io](https://www.gleek.io/blog/inheritance-class-diagrams?utm_source=chatgpt.com)

### 3.2 Basic inheritance

```
class Animal
{
    public void Eat()
    {
        Console.WriteLine("Eating");
    }
}

class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("Barking");
    }
}
```

Usage:

```
Dog d = new Dog();

d.Eat();
d.Bark();
```

Output:

```
Eating
Barking
```

The `:` symbol represents inheritance.

### 3.3 Types of inheritance

| Type         | Explanation                           |
| ------------ | ------------------------------------- |
| Single       | One child inherits one parent         |
| Multilevel   | A class inherits from a derived class |
| Hierarchical | Multiple children inherit one parent  |
| Multiple     | One class inherits multiple classes   |

Important C# concept:

C# supports:

- Single inheritance.
- Multilevel inheritance.
- Hierarchical inheritance.

C# does not support multiple inheritance through classes.

However, a class can implement multiple interfaces.

### 3.4 The `base` keyword

`base` refers to the immediate parent class.

It is used to:

1. Call a parent constructor.
2. Access parent class methods.
3. Access parent class members when hidden by child members.

Example:

```
class Animal
{
    public void Eat()
    {
        Console.WriteLine("Animal eats");
    }
}

class Dog : Animal
{
    public void EatDog()
    {
        base.Eat();
        Console.WriteLine("Dog eats");
    }
}
```

### 3.5 Constructor chaining in inheritance

When a derived object is created:

- The base class constructor executes first.
- Then the derived class constructor executes.

```
class Animal
{
    public Animal()
    {
        Console.WriteLine("Animal constructor");
    }
}

class Dog : Animal
{
    public Dog()
    {
        Console.WriteLine("Dog constructor");
    }
}
```

Output:

```
Animal constructor
Dog constructor
```

Parameterized base constructor

```
class Employee
{
    public Employee(string name)
    {
        Console.WriteLine("Employee: " + name);
    }
}

class Manager : Employee
{
    public Manager(string name) : base(name)
    {
        Console.WriteLine("Manager constructor");
    }
}
```

Usage:

```
Manager m = new Manager("Rahul");
```

Output:

```
Employee: Rahul
Manager constructor
```

### 3.6 The `sealed` keyword

`sealed` prevents further inheritance from a class.

```
sealed class Vehicle
{
}
```

This is invalid:

```
class Car : Vehicle
{
}
```

Because Vehicle is sealed.

You can also seal an overridden method to prevent further overriding.

```
class Animal
{
    public virtual void Sound()
    {
        Console.WriteLine("Animal sound");
    }
}

class Dog : Animal
{
    public sealed override void Sound()
    {
        Console.WriteLine("Bark");
    }
}
```

A further derived class cannot override `Sound()`.

Coderbyte important

- `base` refers to the parent class.
- `this` refers to the current object.
- Base constructors execute before derived constructors.
- C# does not support multiple class inheritance.
- `sealed` prevents inheritance or further overriding, depending on its use.

## 4. Polymorphism

### 4.1 What is polymorphism?

Polymorphism means one name, many forms.

It allows the same method name or interface to behave differently depending on the situation.

There are two main types:

1. Compile-time polymorphism (static polymorphism).
2. Runtime polymorphism (dynamic polymorphism).

### 4.2 Method overloading – Compile-time polymorphism

Method overloading means creating multiple methods with the same name but different parameter lists.

The difference can be in:

- Number of parameters.
- Type of parameters.
- Order of parameters.

```
class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    public double Add(double a, double b)
    {
        return a + b;
    }
}
```

Usage:

```
Calculator c = new Calculator();

Console.WriteLine(c.Add(10, 20));
Console.WriteLine(c.Add(10, 20, 30));
Console.WriteLine(c.Add(2.5, 3.5));
```

Output:

```
30
60
6
```

Important rules:

- Same method name is allowed.
- Parameters must differ.
- Changing only the return type is NOT enough for overloading.
- Changing only parameter names is NOT enough.

Invalid example:

```
int Add(int a, int b) { return a + b; }

double Add(int a, int b) { return a + b; }
```

This causes a compilation error.

### 4.3 Method overriding – Runtime polymorphism

Method overriding means a derived class provides its own implementation of a method defined in its base class.

Keywords:

- `virtual`: Allows a method to be overridden.
- `override`: Provides a new implementation in the derived class.

```
class Animal
{
    public virtual void Sound()
    {
        Console.WriteLine("Animal makes sound");
    }
}

class Dog : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Dog barks");
    }
}

class Cat : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Cat meows");
    }
}
```

Usage:

```
Animal a1 = new Dog();
Animal a2 = new Cat();

a1.Sound();
a2.Sound();
```

Output:

```
Dog barks
Cat meows
```

Very important:

Even though the reference type is `Animal`, the actual object type determines which overridden method executes.

This is runtime polymorphism.

### 4.4 Method hiding using `new`

Method hiding means a derived class hides a method from the base class using the `new` keyword.

Unlike overriding, method hiding does not provide runtime polymorphism through virtual dispatch.

```
class Animal
{
    public void Sound()
    {
        Console.WriteLine("Animal sound");
    }
}

class Dog : Animal
{
    public new void Sound()
    {
        Console.WriteLine("Dog barks");
    }
}
```

Usage:

```
Animal a = new Dog();
Dog d = new Dog();

a.Sound();
d.Sound();
```

Output:

```
Animal sound
Dog barks
```

Why?

- `a` has reference type `Animal`, so the base method is selected.
- `d` has reference type `Dog`, so the hidden derived method is selected.

### 4.5 Overloading vs overriding vs hiding

| Feature              | Overloading             | Overriding          | Hiding                  |
| -------------------- | ----------------------- | ------------------- | ----------------------- |
| Keyword              | None required           | virtual + override  | new                     |
| Parameters           | Different               | Same signature      | Usually same signature  |
| Inheritance required | No                      | Yes                 | Yes                     |
| Polymorphism         | Compile time            | Runtime             | Not virtual dispatch    |
| Selection            | Compile-time resolution | Runtime object type | Reference/member lookup |

### 4.6 Important output-based example

```
class Parent
{
    public virtual void Show()
    {
        Console.WriteLine("Parent");
    }
}

class Child : Parent
{
    public override void Show()
    {
        Console.WriteLine("Child");
    }
}

class Program
{
    static void Main()
    {
        Parent p = new Child();
        p.Show();
    }
}
```

Output:

```
Child
```

High-priority MCQ

Remember:

- Overloading = same method name, different parameters.
- Overriding = same signature, derived implementation, runtime dispatch.
- Hiding = `new` keyword, hides parent member.
- A method must be virtual, abstract or already overridden appropriately to be overridden.

## 5. Abstraction

### 5.1 What is abstraction?

Abstraction means hiding internal implementation details and showing only essential functionality.

Example: When you use an ATM, you select Withdraw. You do not need to understand the internal banking operations.

In C#, abstraction is mainly achieved using:

1. Abstract classes.
2. Interfaces.

### 5.2 Abstract classes

An abstract class is a class that cannot be instantiated directly.

It can contain:

- Abstract methods.
- Normal methods.
- Fields.
- Properties.
- Constructors.
- Static members.

Example:

```
abstract class Animal
{
    public abstract void Sound();

    public void Eat()
    {
        Console.WriteLine("Eating");
    }
}
```

Derived class:

```
class Dog : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Barking");
    }
}
```

Usage:

```
Dog d = new Dog();

d.Sound();
d.Eat();
```

Output:

```
Barking
Eating
```

Important:

- Abstract methods do not have a method body.
- A non-abstract derived class must implement inherited abstract methods.
- An abstract class can have constructors.
- An abstract class can contain both abstract and non-abstract methods.

Invalid:

```
Animal a = new Animal();
```

Because an abstract class cannot be instantiated.

### 5.3 Interfaces

An interface defines a contract that implementing classes must fulfil.

It specifies what functionality a class should provide.

Example:

```
interface IPayment
{
    void Pay(double amount);
}
```

Implementation:

```
class CreditCard : IPayment
{
    public void Pay(double amount)
    {
        Console.WriteLine("Paid using credit card: " + amount);
    }
}

class UPI : IPayment
{
    public void Pay(double amount)
    {
        Console.WriteLine("Paid using UPI: " + amount);
    }
}
```

Usage:

```
IPayment payment = new UPI();

payment.Pay(500);
```

Output:

```
Paid using UPI: 500
```

### 5.4 Implementing multiple interfaces

C# does not support multiple inheritance through classes, but it supports implementing multiple interfaces.

```
interface IPrintable
{
    void Print();
}

interface IScannable
{
    void Scan();
}

class Printer : IPrintable, IScannable
{
    public void Print()
    {
        Console.WriteLine("Printing");
    }

    public void Scan()
    {
        Console.WriteLine("Scanning");
    }
}
```

Usage:

```
Printer p = new Printer();

p.Print();
p.Scan();
```

Output:

```
Printing
Scanning
```

### 5.5 Interface vs abstract class

This is one of the most important OOP comparison questions.

| Feature          | Abstract class                      | Interface                                               |
| ---------------- | ----------------------------------- | ------------------------------------------------------- |
| Instantiation    | Cannot instantiate directly         | Cannot instantiate directly                             |
| Methods          | Abstract and concrete methods       | Contract members; can also have default implementations |
| Fields           | Can have instance fields            | Cannot declare instance fields                          |
| Constructors     | Yes                                 | No instance constructors                                |
| Access modifiers | Supports different access modifiers | Ordinary interface contract members are public          |
| Inheritance      | A class can inherit one base class  | A class can implement multiple interfaces               |
| Properties       | Supported                           | Supported                                               |
| Purpose          | Shared base functionality and state | Define a common contract                                |

When to use what?

Use an abstract class when:

- Related classes share common code.
- You need common state or fields.
- You want to provide partial implementation.

Use an interface when:

- Different classes need to follow the same contract.
- You need multiple capabilities.
- You want loose coupling.

### 5.6 Interface default implementations

Modern C# interfaces can contain default method implementations.

```
interface ILogger
{
    void Log(string message)
    {
        Console.WriteLine(message);
    }
}
```

A class can implement the interface without providing its own `Log` implementation.

The default interface implementation is accessed through the interface reference.

This is a useful advanced MCQ concept.

Remember

- Abstract class = partial implementation + shared state.
- Interface = contract + multiple implementation support.
- Abstract methods must be implemented by concrete derived classes.
- A class can implement multiple interfaces.

## 6. Static Members

### 6.1 What is static?

A static member belongs to the class itself rather than an individual object.

You can access static members using the class name without creating an object.

### 6.2 Static field

A static field is shared among all instances of a class.

```
class Student
{
    public static string College = "MBIT";

    public string Name;
}
```

Usage:

```
Student s1 = new Student();
Student s2 = new Student();

s1.Name = "Rahul";
s2.Name = "Amit";

Console.WriteLine(Student.College);
```

Output:

```
MBIT
```

Both objects share the same `College` field.

### 6.3 Static field example – Object counter

```
class Employee
{
    public static int Count = 0;

    public Employee()
    {
        Count++;
    }
}
```

Usage:

```
Employee e1 = new Employee();
Employee e2 = new Employee();
Employee e3 = new Employee();

Console.WriteLine(Employee.Count);
```

Output:

```
3
```

Why? Each time a new object is created, the constructor increments the shared static field.

### 6.4 Static methods

A static method can be called without creating an object.

```
class Calculator
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
}
```

Usage:

```
Console.WriteLine(Calculator.Add(10, 20));
```

Output:

```
30
```

Important rule:

A static method cannot directly access non-static instance members because it does not belong to a particular object.

Example:

```
class Student
{
    int age = 20;

    public static void Display()
    {
        // Console.WriteLine(age); // Error
    }
}
```

### 6.5 Static classes

A static class:

- Cannot be instantiated.
- Can contain only static members.
- Cannot be inherited.
- Cannot be used as a base class.

```
static class MathHelper
{
    public static int Square(int n)
    {
        return n * n;
    }
}
```

Usage:

```
Console.WriteLine(MathHelper.Square(5));
```

Output:

```
25
```

### 6.6 Static vs instance members

| Static                    | Instance                  |
| ------------------------- | ------------------------- |
| Belongs to class          | Belongs to object         |
| One shared copy           | Separate copy per object  |
| Accessed using class name | Accessed using object     |
| No object needed          | Object generally required |

Coderbyte traps:

1. Static methods cannot directly access instance variables.
2. Static members are shared by all objects.
3. A static class cannot be instantiated.
4. A static class cannot be inherited.
5. A normal class can contain both static and instance members.

## 7. Structs and Records

This topic is especially important for C# output-based and conceptual MCQs.

### 7.1 What is a struct?

A struct is a value type used to represent small data structures.

It is declared using the `struct` keyword.

```
struct Point
{
    public int X;
    public int Y;
}
```

Usage:

```
Point p1 = new Point();

p1.X = 10;
p1.Y = 20;

Console.WriteLine(p1.X);
```

Output:

```
10
```

### 7.2 Struct vs class

| Feature      | Struct                                           | Class                      |
| ------------ | ------------------------------------------------ | -------------------------- |
| Type         | Value type                                       | Reference type             |
| Assignment   | Copies value                                     | Copies reference           |
| Inheritance  | Cannot inherit from another class or struct      | Supports class inheritance |
| Interfaces   | Can implement interfaces                         | Can implement interfaces   |
| Constructors | Supports constructors with struct-specific rules | Supports constructors      |
| Null         | Non-nullable by default                          | Can be null                |
| Use          | Small data structures                            | Complex objects            |

### 7.3 Value type behaviour

When you assign one value-type variable to another, the value is copied.

```
struct Point
{
    public int X;
}

class Program
{
    static void Main()
    {
        Point p1 = new Point();
        p1.X = 10;

        Point p2 = p1;

        p2.X = 20;

        Console.WriteLine(p1.X);
        Console.WriteLine(p2.X);
    }
}
```

Output:

```
10
20
```

Changing `p2` does not affect `p1`.

### 7.4 Reference type behaviour

When you assign one reference-type variable to another, both variables refer to the same object.

```
class Student
{
    public int Age;
}

class Program
{
    static void Main()
    {
        Student s1 = new Student();
        s1.Age = 20;

        Student s2 = s1;

        s2.Age = 25;

        Console.WriteLine(s1.Age);
        Console.WriteLine(s2.Age);
    }
}
```

Output:

```
25
25
```

Both references point to the same object.

### 7.5 Important: Reference vs value behaviour diagram

Value type – separate copies

p1

# 10

p2

# 20

Reference type – same object

s1

s2

Same Student object

# Age = 25

### 7.6 What are records?

Records are types designed to represent data, with built-in value-based equality.

C# supports:

- `record class` – reference type.
- `record struct` – value type.

Example:

```
public record Student(string Name, int Age);
```

Usage:

```
Student s1 = new Student("Rahul", 20);
Student s2 = new Student("Rahul", 20);

Console.WriteLine(s1 == s2);
```

Output:

```
True
```

Why? Records compare their data values rather than simply checking whether both references point to the same object.

### 7.7 Record class vs normal class

```
class StudentClass
{
    public string Name { get; set; }
}

record StudentRecord(string Name);
```

Normal classes generally use reference identity for equality unless equality is customized.

Records provide value-based equality by default.

### 7.8 The `with` expression

Records support non-destructive modification through `with`.

```
public record Student(string Name, int Age);

Student s1 = new Student("Rahul", 20);

Student s2 = s1 with { Age = 21 };

Console.WriteLine(s1.Age);
Console.WriteLine(s2.Age);
```

Output:

```
20
21
```

A new record is created with the changed value.

Important: Records are not automatically deeply immutable. Properties and referenced objects can still have mutable state depending on their definitions.

### 7.9 Struct vs record vs class

| Feature                         | Class              | Struct               | Record class            | Record struct        |
| ------------------------------- | ------------------ | -------------------- | ----------------------- | -------------------- |
| Value/reference                 | Reference          | Value                | Reference               | Value                |
| Value-based equality by default | No                 | No                   | Yes                     | Yes                  |
| Inheritance                     | Yes                | No class inheritance | Yes, record inheritance | No class inheritance |
| `with` expression               | No general support | No general support   | Yes                     | Yes                  |
| Main use                        | Complex objects    | Small value data     | Data models             | Value data models    |

Very important MCQ

- Struct = value type.
- Class = reference type.
- Record class = reference type with value-based equality.
- Record struct = value type with value-based equality.
- Assigning a struct copies its value.
- Assigning a class variable copies its reference.

## 8. Composition Over Inheritance

### 8.1 What is composition?

Composition means creating a class by including objects of other classes.

It represents a HAS-A relationship.

Example:

- A Car HAS-A Engine.
- A House HAS-A Room.
- A Computer HAS-A Processor.

### 8.2 Composition example

```
class Engine
{
    public void Start()
    {
        Console.WriteLine("Engine started");
    }
}

class Car
{
    private Engine engine;

    public Car()
    {
        engine = new Engine();
    }

    public void StartCar()
    {
        engine.Start();
        Console.WriteLine("Car started");
    }
}
```

Usage:

```
Car car = new Car();

car.StartCar();
```

Output:

```
Engine started
Car started
```

Here:

- Car HAS-A Engine.
- Car uses the Engine's functionality.
- Engine is not the parent class of Car.

### 8.3 What is inheritance?

Inheritance represents an IS-A relationship.

Example:

- Dog IS-A Animal.
- Manager IS-A Employee.
- Car IS-A Vehicle.

```
class Vehicle
{
    public void Start()
    {
        Console.WriteLine("Vehicle started");
    }
}

class Car : Vehicle
{
}
```

Here Car inherits the functionality of Vehicle.

### 8.4 Composition vs inheritance

| Feature      | Inheritance                          | Composition                           |
| ------------ | ------------------------------------ | ------------------------------------- |
| Relationship | IS-A                                 | HAS-A                                 |
| Meaning      | Child inherits parent functionality  | Class contains another object         |
| Reusability  | Through inheritance                  | Through object collaboration          |
| Coupling     | Can create tighter coupling          | Often provides more flexibility       |
| Flexibility  | Less flexible when hierarchy changes | Components can be replaced or changed |
| Example      | Dog IS-A Animal                      | Car HAS-A Engine                      |

### 8.5 Why prefer composition over inheritance?

Composition is often preferred because:

1. It reduces tight coupling.
2. It makes code more flexible.
3. Components can be reused independently.
4. It avoids unnecessary inheritance hierarchies.
5. It makes testing easier.

### 8.6 Dependency injection – a useful related concept

Instead of creating an Engine inside Car, we can pass it through the constructor.

```
class Engine
{
    public void Start()
    {
        Console.WriteLine("Engine started");
    }
}

class Car
{
    private Engine engine;

    public Car(Engine engine)
    {
        this.engine = engine;
    }

    public void StartCar()
    {
        engine.Start();
    }
}
```

Usage:

```
Engine e = new Engine();
Car c = new Car(e);

c.StartCar();
```

Now Car does not create its own Engine. It receives one from outside.

This is constructor dependency injection.

Coderbyte question: What is the relationship between a Car and an Engine?

Answer: HAS-A relationship, implemented using composition.

## 9. SOLID Principles

SOLID is a set of five object-oriented design principles that help developers create maintainable, flexible and reusable software.

# SOLID

# S

Single

# O

Open

# L

Liskov

# I

Interface

# D

Dependency

Five principles:

1. S – Single Responsibility Principle
2. O – Open/Closed Principle
3. L – Liskov Substitution Principle
4. I – Interface Segregation Principle
5. D – Dependency Inversion Principle

### 9.1 S – Single Responsibility Principle (SRP)

Definition: A class should have only one responsibility or one reason to change.

Bad example:

```
class Employee
{
    public void CalculateSalary()
    {
        Console.WriteLine("Calculating salary");
    }

    public void SaveToDatabase()
    {
        Console.WriteLine("Saving employee");
    }

    public void GenerateReport()
    {
        Console.WriteLine("Generating report");
    }
}
```

This class handles multiple responsibilities.

Better example:

```
class Employee
{
    public void CalculateSalary()
    {
        Console.WriteLine("Calculating salary");
    }
}

class EmployeeRepository
{
    public void SaveToDatabase()
    {
        Console.WriteLine("Saving employee");
    }
}

class EmployeeReport
{
    public void GenerateReport()
    {
        Console.WriteLine("Generating report");
    }
}
```

Now each class has a separate responsibility.

Remember: One class = one main responsibility.

### 9.2 O – Open/Closed Principle (OCP)

Definition: Software entities should be open for extension but closed for modification.

Meaning:

- You should be able to add new functionality.
- You should avoid repeatedly modifying existing tested code.

Bad example:

```
class Payment
{
    public void Pay(string type)
    {
        if (type == "UPI")
            Console.WriteLine("UPI payment");

        else if (type == "Card")
            Console.WriteLine("Card payment");
    }
}
```

Adding a new payment type requires changing the existing class.

Better example:

```
interface IPayment
{
    void Pay();
}

class UPI : IPayment
{
    public void Pay()
    {
        Console.WriteLine("UPI payment");
    }
}

class Card : IPayment
{
    public void Pay()
    {
        Console.WriteLine("Card payment");
    }
}

class Cash : IPayment
{
    public void Pay()
    {
        Console.WriteLine("Cash payment");
    }
}
```

Now new payment methods can be added by implementing the interface without modifying existing payment implementations.

Remember: Extend functionality without modifying existing tested code unnecessarily.

### 9.3 L – Liskov Substitution Principle (LSP)

Definition: Objects of a derived class should be usable wherever objects of the base class are expected, without breaking expected behaviour.

In simple words, a child class should behave consistently with the expectations of its parent class.

Bad example:

```
class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Flying");
    }
}

class Sparrow : Bird
{
}

class Penguin : Bird
{
    public override void Fly()
    {
        throw new Exception("Penguins cannot fly");
    }
}
```

Problem: Penguin inherits a behaviour that it cannot correctly provide.

Better design:

```
class Bird
{
    public void Eat()
    {
        Console.WriteLine("Eating");
    }
}

interface IFlyable
{
    void Fly();
}

class Sparrow : Bird, IFlyable
{
    public void Fly()
    {
        Console.WriteLine("Sparrow flying");
    }
}

class Penguin : Bird
{
}
```

Now only birds capable of flying implement `IFlyable`.

Remember: A derived class should not break the expected behaviour of its base class.

### 9.4 I – Interface Segregation Principle (ISP)

Definition: Clients should not be forced to implement interfaces they do not need.

In simple words, prefer small, specific interfaces instead of one large interface.

Bad example:

```
interface IWorker
{
    void Work();
    void Eat();
}

class Robot : IWorker
{
    public void Work()
    {
        Console.WriteLine("Robot working");
    }

    public void Eat()
    {
        throw new NotImplementedException();
    }
}
```

Problem: A robot does not need to eat, but it is forced to implement `Eat()`.

Better example:

```
interface IWorkable
{
    void Work();
}

interface IEatable
{
    void Eat();
}

class Human : IWorkable, IEatable
{
    public void Work()
    {
        Console.WriteLine("Human working");
    }

    public void Eat()
    {
        Console.WriteLine("Human eating");
    }
}

class Robot : IWorkable
{
    public void Work()
    {
        Console.WriteLine("Robot working");
    }
}
```

Remember: Smaller, specific interfaces are better than one unnecessarily large interface.

### 9.5 D – Dependency Inversion Principle (DIP)

Definition: High-level modules should not depend directly on low-level modules. Both should depend on abstractions.

In simple words, depend on interfaces or abstractions instead of concrete classes.

Bad example:

```
class EmailService
{
    public void Send()
    {
        Console.WriteLine("Sending email");
    }
}

class Notification
{
    private EmailService email = new EmailService();

    public void Notify()
    {
        email.Send();
    }
}
```

Problem: Notification is tightly coupled to EmailService.

Better example:

```
interface IMessageService
{
    void Send();
}

class EmailService : IMessageService
{
    public void Send()
    {
        Console.WriteLine("Sending email");
    }
}

class SMSService : IMessageService
{
    public void Send()
    {
        Console.WriteLine("Sending SMS");
    }
}

class Notification
{
    private IMessageService service;

    public Notification(IMessageService service)
    {
        this.service = service;
    }

    public void Notify()
    {
        service.Send();
    }
}
```

Usage:

```
IMessageService service = new SMSService();

Notification notification = new Notification(service);

notification.Notify();
```

Output:

```
Sending SMS
```

The Notification class depends on `IMessageService`, not directly on EmailService or SMSService.

Remember: Depend on abstractions, not concrete implementations.

### 9.6 SOLID quick revision table

| Principle | Main idea                               | Keyword to remember |
| --------- | --------------------------------------- | ------------------- |
| SRP       | One responsibility per class            | Responsibility      |
| OCP       | Extend without modifying existing code  | Extension           |
| LSP       | Derived classes should be substitutable | Substitution        |
| ISP       | Small, specific interfaces              | Segregation         |
| DIP       | Depend on abstractions                  | Dependency          |

### 9.7 SOLID differences that are commonly confused

- SRP vs ISP: SRP focuses on classes having one responsibility; ISP focuses on interfaces not forcing unnecessary methods on clients.
- OCP vs DIP: OCP focuses on extending functionality without modifying existing code; DIP focuses on depending on abstractions rather than concrete classes.
- LSP vs OCP: LSP ensures derived classes behave correctly; OCP allows adding new functionality without changing existing code.

# 10. Most Important C# OOP Output-Based Questions

These are particularly useful because Coderbyte assessments can test whether you understand how C# actually executes code, not just definitions.

Try predicting the output before reading the answer.

### Question 1 – Constructor execution order

```
class A
{
    public A()
    {
        Console.WriteLine("A");
    }
}

class B : A
{
    public B()
    {
        Console.WriteLine("B");
    }
}

class Program
{
    static void Main()
    {
        B obj = new B();
    }
}
```

Answer: A, then B

Explanation: Base constructor executes before derived constructor.

### Question 2 – Method overriding

```
class A
{
    public virtual void Show()
    {
        Console.WriteLine("A");
    }
}

class B : A
{
    public override void Show()
    {
        Console.WriteLine("B");
    }
}

A obj = new B();
obj.Show();
```

Answer: B

Explanation: Runtime polymorphism uses the actual object type.

### Question 3 – Method hiding

```
class A
{
    public void Show()
    {
        Console.WriteLine("A");
    }
}

class B : A
{
    public new void Show()
    {
        Console.WriteLine("B");
    }
}

A obj = new B();
obj.Show();
```

Answer: A

Explanation: Method hiding is resolved using the reference type.

### Question 4 – Static variable

```
class Test
{
    public static int Count = 0;

    public Test()
    {
        Count++;
    }
}

Test t1 = new Test();
Test t2 = new Test();
Test t3 = new Test();

Console.WriteLine(Test.Count);
```

Answer: 3

Explanation: Static variables are shared between objects.

### Question 5 – Value type

```
int a = 10;
int b = a;

b = 20;

Console.WriteLine(a);
```

Answer: 10

Explanation: Value types copy their values.

### Question 6 – Reference type

```
class Student
{
    public int Age;
}

Student s1 = new Student();
s1.Age = 20;

Student s2 = s1;
s2.Age = 30;

Console.WriteLine(s1.Age);
```

Answer: 30

Explanation: Both references point to the same object.

### Question 7 – Constructor overloading

```
class Student
{
    public Student()
    {
        Console.WriteLine("Default");
    }

    public Student(int age)
    {
        Console.WriteLine("Parameterized");
    }
}

Student s = new Student(20);
```

Answer: Parameterized

Explanation: Constructor is selected based on the arguments.

### Question 8 – Overloading

```
class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}

Calculator c = new Calculator();

Console.WriteLine(c.Add(2, 3, 4));
```

Answer: 9

Explanation: The three-parameter overload is selected.

# 11. Important C# OOP Interview and MCQ Theory

Revise this section before your assessment.

| Question                                                 | Correct answer                           |
| -------------------------------------------------------- | ---------------------------------------- |
| What is the blueprint of an object?                      | Class                                    |
| What is an instance of a class?                          | Object                                   |
| Which keyword creates an object?                         | `new`                                    |
| Which keyword refers to the current object?              | `this`                                   |
| Which keyword accesses parent members?                   | `base`                                   |
| Which keyword allows overriding?                         | `virtual`                                |
| Which keyword implements overriding?                     | `override`                               |
| Which keyword hides a parent method?                     | `new`                                    |
| Which keyword prevents inheritance?                      | `sealed`                                 |
| Which keyword defines an abstract class?                 | `abstract`                               |
| Can an abstract class be instantiated?                   | No                                       |
| Can an abstract class have constructors?                 | Yes                                      |
| Can an interface have multiple implementations?          | Yes                                      |
| Can a class implement multiple interfaces?               | Yes                                      |
| Can a class inherit multiple classes?                    | No                                       |
| Which keyword declares static members?                   | `static`                                 |
| Are static members shared?                               | Yes                                      |
| Can static methods directly access instance variables?   | No                                       |
| Is a struct a value type?                                | Yes                                      |
| Is a class a reference type?                             | Yes                                      |
| Are records value types?                                 | Depends on record class or record struct |
| Which principle means one responsibility?                | SRP                                      |
| Which principle means extension without modification?    | OCP                                      |
| Which principle ensures substitutability?                | LSP                                      |
| Which principle promotes smaller interfaces?             | ISP                                      |
| Which principle promotes abstraction-based dependencies? | DIP                                      |
| HAS-A relationship represents what?                      | Composition                              |
| IS-A relationship represents what?                       | Inheritance                              |


### Three coding patterns worth memorising

Pattern 1: Inheritance + overriding

```
class Employee
{
    public string Name;
    public int Salary;

    public Employee(string name, int salary)
    {
        Name = name;
        Salary = salary;
    }

    public virtual int CalculateBonus()
    {
        return Salary / 10;
    }
}

class Manager : Employee
{
    public Manager(string name, int salary)
        : base(name, salary)
    {
    }

    public override int CalculateBonus()
    {
        return Salary / 5;
    }
}
```

Pattern 2: Encapsulation + validation

```
class BankAccount
{
    private double balance;

    public double Balance
    {
        get { return balance; }
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
            balance += amount;
    }
}
```

Pattern 3: Abstract class + derived classes

```
abstract class Shape
{
    public abstract double CalculateArea();
}

class Circle : Shape
{
    public double Radius;

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return 3.14 * Radius * Radius;
    }
}
```

# 13. Final Revision Checklist

Use this to track your preparation.

OOP preparation tracker

0/42 completed

1\. Classes and Objects

Class vs object

Fields and properties

get, set and init

Constructors and constructor overloading

this keyword

Object initializers

2\. Encapsulation

Four access modifiers

Private fields and public properties

Read-only properties

Setter validation

3\. Inheritance

Base and derived classes

Single, multilevel and hierarchical inheritance

base keyword

Constructor chaining

sealed keyword

4\. Polymorphism

Method overloading

Method overriding

virtual and override

Method hiding using new

Predict output of polymorphic code

5\. Abstraction

Abstract classes and methods

Interfaces

Multiple interface implementation

Abstract class vs interface

6\. Static Members

Static fields

Static methods

Static classes

Static vs instance members

7\. Structs and Records

Struct vs class

Value vs reference behaviour

Record class vs record struct

Value-based equality

with expression

8\. Composition

HAS-A vs IS-A

Composition example

Dependency injection

Composition over inheritance

9\. SOLID

SRP

OCP

LSP

ISP

DIP

Reset checklist




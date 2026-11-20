
// LINQ--------------------------
// using System;
// using System.Linq;
// using System.Collections.Generic;

// class Employee
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
//     public string Department { get; set; }
//     public int Salary { get; set; }
// }

// class Program
// {
//     static void Main()
//     {
//         List<Employee> employees = new List<Employee>
//         {
//             new Employee { Id = 1, Name = "Rahul", Department = "IT", Salary = 40000 },
//             new Employee { Id = 2, Name = "Priya", Department = "HR", Salary = 30000 },
//             new Employee { Id = 3, Name = "Amit", Department = "IT", Salary = 50000 },
//             new Employee { Id = 4, Name = "Neha", Department = "HR", Salary = 35000 },
//             new Employee { Id = 5, Name = "Raj", Department = "IT", Salary = 45000 }
//         };

//         //query syntax
//         // var result = from e in employees
//         //              where e.Salary > 40000
//         //              select e;

//         // foreach (var emp in result)
//         // {
//         //     Console.WriteLine(emp.Name);
//         // }

//         //method syntax
//         // var result = employees.Where(e => e.Salary > 40000);

//         // foreach (var emp in result)
//         // {
//         //     Console.WriteLine(emp.Name);
//         // }


//         var names = employees.Select(e => e.Name);

//         foreach (var name in names)
//         {
//             Console.WriteLine(name);
//         }

//         var result = employees.OrderBy(e => e.Salary);
//         foreach (var name in result)
//         {
//             Console.WriteLine(name);
//         }

//         var result = employees
//         .OrderBy(e => e.Department)
//         .ThenBy(e => e.Salary);
//         foreach (var name in result)
//         {
//             Console.WriteLine(name);
//         }

//         var result = employees.GroupBy(e => e.Department);

//         foreach (var group in result)
//         {
//             Console.WriteLine(group.Key);

//             foreach (var emp in group)
//             {
//                 Console.WriteLine(emp.Name);
//             }
//         }

//         bool result = employees.Any(e => e.Salary > 45000);

//         Console.WriteLine(result);
//         bool result = employees.All(e => e.Salary > 20000);

//         Console.WriteLine(result);

//         var emp = employees.First(e => e.Department == "IT");

//         Console.WriteLine(emp.Name);

//         var emp = employees.First(e => e.Department == "IT");

//         Console.WriteLine(emp.Name);


//         var emp = employees.Single(e => e.Name == "Priya");

//         Console.WriteLine(emp.Name);



//     }
// }


//Aynshoronous Programming


using System;
using System.Threading.Tasks;

// class Program
// {
//     static async Task DownloadFile()
//     {
//         await Task.Delay(2000);
//         Console.WriteLine("File downloaded!");
//     }

//     static async Task Main()
//     {
//         await DownloadFile();
//         Console.WriteLine("Done");
//     }
// }

static async Task GetData(CancellationToken token)
{
    Console.WriteLine("Fetching data...");

    await Task.Delay(5000, token);

    Console.WriteLine("Data received");
}

static async Task Main()
{
    using CancellationTokenSource cts = new();

    cts.CancelAfter(2000);

    try
    {
        await GetData(cts.Token);
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("Operation cancelled");
    }
}
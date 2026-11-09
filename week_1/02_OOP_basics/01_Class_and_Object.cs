// class Student
// {
//     public string name;
//     public int rollNumber;

//     public void DisplayDetails()
//     {
//         Console.WriteLine("Name: " + name);
//         Console.WriteLine("Roll Number: " + rollNumber);
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Student s1 = new Student();

//         s1.name = "Kalpana";
//         s1.rollNumber = 101;

//         s1.DisplayDetails();
//         Student s2 = new Student();

//         s2.name = "Varsha";
//         s2.rollNumber = 102;

//         s2.DisplayDetails();
//     }
// }

using System;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        Student s1 = new Student();

s1.Name = "Kalpana";
s1.Age = 21;

Console.WriteLine(s1.Name);
Console.WriteLine(s1.Age);
    }
}

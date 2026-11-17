
function CalculateTotal(a:number, b:number):number{
  return a+ b;
}

console.log(CalculateTotal(10, 20));
console.log(CalculateTotal(15, 30));



interface Employee {
  id:number,
  name:string,
  salary:number,
  department?:string
}

function GetEmployeeInfo(emp: Employee): string {
  return `Name: ${emp.name}, Salary: ${emp.salary}`
}

const employee: Employee = {
  id: 101,
  name: "Riya",
  salary: 50000
};

console.log(GetEmployeeInfo(employee));



function GetFirstElement<T>(arr: T[]): T {
  // Write your code here
  return arr[0]
}

console.log(GetFirstElement([10, 20, 30]));
console.log(GetFirstElement(["Hello", "World"]));
console.log(GetFirstElement([true, false]));



function FormatValue(value: string | number): string | number {
  // Write your code here
  if(typeof value === "string")
  {
     return value.toUpperCase();
  }
  else
  {
    return value*value;
  }
}

console.log(FormatValue("hello"));
console.log(FormatValue(10));



enum Role {
  Admin ,
  User ,
  Guest 
}

function GetAccess(role: Role): string {
  if (role === Role.Admin) {
    return "Full Access";
  } else if (role === Role.User) {
    return "Limited Access";
  } else {
    return "Read Only";
  }
}

console.log(GetAccess(Role.Admin));
console.log(GetAccess(Role.User));
console.log(GetAccess(Role.Guest));



interface User {
  id: number;
  name: string;
  email: string;
}

function UpdateUser(user: User, updates: Partial<User>): User {
  // Write your code here
  return { ...user,...updates}
}

const user: User = {
  id: 1,
  name: "Riya",
  email: "riya@gmail.com"
};

console.log(UpdateUser(user, { name: "Riya Sharma" }));



class Animal {
   name:string;
  constructor(name:string)
  {
    this.name = name;
  }
  makeSound():string
  {
    return "Animal makes a sound"
    
  }
}

class Dog extends Animal {
  // Write your code here
  override makeSound():string
  {
    return "Dog barks"
    
  }

}

const animal = new Animal("Animal");
const dog = new Dog("Tommy");

console.log(animal.makeSound());
console.log(dog.makeSound());




abstract class Shape {
  color: string;

  constructor(color:string)
  {
    this.color = color;
  }

  abstract calculateArea(): number;
}

class Rectangle extends Shape {
  // Write your code here
   height : number;
   width : number;
   constructor(height:number,width:number,color:string)
  {
    super(color),
    this.height = height;
    this.width = width;
  }
   override calculateArea(): number {
       return this.width * this.height;
   }
}

const rectangle = new Rectangle("Blue", 20, 10);

console.log(rectangle.calculateArea());







interface Car {
  brand: string;
  speed: number;
}

interface Bike {
  brand: string;
  hasGear: boolean;
}

function GetVehicleInfo(vehicle: Car | Bike): string {
  // Write your code here
  if("speed" in vehicle)
  {
    return "Car speed: 120"
  }
  else if ("hasGear" in vehicle)
  {
    if(vehicle.hasGear)
    {
        return "Bike gears: Yes"
    }
    else{
        return "Bike gears: No"
    }
  }
}

const car: Car = { brand: "BMW", speed: 120 };
const bike: Bike = { brand: "Hero", hasGear: true };

console.log(GetVehicleInfo(car));
console.log(GetVehicleInfo(bike));


interface User {
  name: string;
  address?: {
    city?: string;
  };
}

function GetCity(user: User): string {
  // Write your code here
  return user.address?.city ?? "unkown";
}

const user1: User = {
  name: "Kalpana",
  address: { city: "Ahmedabad" }
};

const user2: User = {
  name: "Rahul"
};

console.log(GetCity(user1));
console.log(GetCity(user2));

interface User {
  readonly id: number;
  name: string;
}

function UpdateUser(user: User): User {
   user.name = "Updated"
}

const user: User = {
  id: 101,
  name: "Kalpana"
};

console.log(UpdateUser(user));


function GetUserInfo(user: [string, number]): string {
  // Write your code here
   return `$user[0] is $user{1}years old`
}

console.log(GetUserInfo(["Kalpana", 21]));
## 1. Variables and scope

Variables store data in JavaScript. They can be declared using `var`, `let`, and `const`.

### 1.1 `var`, `let`, and `const`

| Feature                     | `var`                           | `let`                     | `const`                   |
| --------------------------- | ------------------------------- | ------------------------- | ------------------------- |
| Scope                       | Function                        | Block                     | Block                     |
| Re-declaration              | Allowed                         | Not allowed in same scope | Not allowed in same scope |
| Reassignment                | Allowed                         | Allowed                   | Not allowed               |
| Hoisting                    | Yes, initialized as `undefined` | Yes, but in TDZ           | Yes, but in TDZ           |
| Must initialize immediately | No                              | No                        | Yes                       |

```
var age = 20;
age = 21;        // Allowed
var age = 22;    // Allowed

let marks = 90;
marks = 95;      // Allowed
// let marks = 98; // Error in same scope

const name = "Kalpana";
// name = "Mira";  // Error
```

Important: `const` prevents reassignment of the variable, not modification of an object or array stored in it.

```
const student = { name: "Mira" };
student.name = "Riya";  // Allowed

const numbers = [1, 2];
numbers.push(3);        // Allowed
```

### 1.2 Scope

Scope determines where a variable can be accessed.

Global scope: Declared outside functions and blocks.

```
let college = "MBIT";

function display() {
    console.log(college);
}
```

Function scope: Variables declared with `var` inside a function are accessible throughout that function.

```
function test() {
    var x = 10;
    console.log(x); // 10
}
// console.log(x); // Error
```

Block scope: Variables declared with `let` and `const` inside `{ }` are accessible only within that block.

```
if (true) {
    let a = 10;
    const b = 20;
    var c = 30;
}

// console.log(a); // Error
// console.log(b); // Error
console.log(c);    // 30
```

### 1.3 Hoisting

Hoisting means JavaScript processes declarations before executing code in their scope.

```
console.log(a); // undefined
var a = 10;
```

This behaves conceptually like:

```
var a;
console.log(a);
a = 10;
```

For `let` and `const`:

```
// console.log(x); // ReferenceError
let x = 10;
```

They are hoisted too, but cannot be accessed before initialization. This period is called the Temporal Dead Zone (TDZ).

Remember:

- `var` → hoisted and initialized with `undefined`.
- `let` and `const` → hoisted but inaccessible before declaration.
- Function declarations are also hoisted, so they can generally be called before their declaration.

## 2. JavaScript types

JavaScript is a dynamically typed language. A variable can hold values of different types at different times.

```
let value = 10;
value = "Hello"; // Allowed
```

### 2.1 Primitive types

Primitive values are simple, immutable values.

| Type      | Example         |
| --------- | --------------- |
| String    | `"Hello"`       |
| Number    | `25`, `10.5`    |
| BigInt    | `123n`          |
| Boolean   | `true`, `false` |
| Undefined | `let x;`        |
| Null      | `null`          |
| Symbol    | `Symbol("id")`  |

```
let name = "Mira";
let age = 20;
let isStudent = true;
let result;
let data = null;
let largeNumber = 12345678901234567890n;
```

Note: `typeof null` returns `"object"` due to a historical JavaScript quirk.

### 2.2 Objects (non-primitive)

Objects store collections of properties and are mutable.

Examples:

- Objects
- Arrays
- Functions

```
let student = {
    name: "Mira",
    age: 20
};

let marks = [80, 90, 95];

function greet() {
    console.log("Hello");
}
```

Primitive vs object assignment:

```
let a = 10;
let b = a;
b = 20;

console.log(a); // 10
```

Primitive values are copied.

```
let obj1 = { name: "Mira" };
let obj2 = obj1;

obj2.name = "Riya";

console.log(obj1.name); // Riya
```

Objects are assigned by reference: both variables refer to the same object.

### 2.3 Truthy and falsy values

JavaScript converts values to Boolean in conditions.

Falsy values:

- `false`
- `0`, `-0`
- `0n`
- `""` (empty string)
- `null`
- `undefined`
- `NaN`

Almost everything else is truthy.

Examples of truthy values:

- `"0"` (non-empty string)
- `"false"` (non-empty string)
- (empty array)
- `{}` (empty object)

```
if ("Hello") {
    console.log("Executed");
}
```

Output: `Executed`

### 2.4 `==` vs `===`

| `==`                                 | `===`                   |
| ------------------------------------ | ----------------------- |
| Loose equality                       | Strict equality         |
| Performs type conversion when needed | No type conversion      |
| Compares after coercion              | Compares value and type |

```
console.log(5 == "5");  // true
console.log(5 === "5"); // false

console.log(0 == false);  // true
console.log(0 === false); // false
```

Best practice: Prefer `===` and `!==` to avoid unexpected type conversion.

## 3. Functions

Functions are reusable blocks of code that perform a task.

### 3.1 Function declaration

A function declared using the `function` keyword.

```
function add(a, b) {
    return a + b;
}

console.log(add(5, 3)); // 8
```

Function declarations are hoisted and can be called before their declaration.

### 3.2 Function expression

A function stored in a variable.

```
const add = function(a, b) {
    return a + b;
};

console.log(add(5, 3)); // 8
```

The variable declaration follows its own hoisting rules; the function expression cannot be called before it is assigned.

### 3.3 Arrow functions (ES6)

Shorter syntax for writing functions.

```
const add = (a, b) => {
    return a + b;
};
```

For a single expression, implicit return is possible:

```
const add = (a, b) => a + b;

const square = n => n * n;
```

For no parameters:

```
const greet = () => "Hello";
```

Arrow function differences:

- Does not have its own `this`.
- Does not have its own `arguments` object.
- Cannot be used as a constructor with `new`.
- Does not have its own `super` or `new.target`.

### 3.4 Default parameters

Provide default values when arguments are missing or `undefined`.

```
function greet(name = "Guest") {
    return `Hello ${name}`;
}

console.log(greet());       // Hello Guest
console.log(greet("Mira")); // Hello Mira
```

A default is used for `undefined`, not for `null`.

### 3.5 Rest parameter (`...`)

Collects multiple arguments into a single array.

```
function sum(...numbers) {
    return numbers.reduce((total, n) => total + n, 0);
}

console.log(sum(10, 20, 30)); // 60
```

Remember: Rest parameter must be the last parameter.

```
function display(name, ...marks) {
    console.log(name, marks);
}
```

### 3.6 Spread operator (`...`)

Expands an array or object into individual elements or properties.

Array example:

```
let a = [1, 2, 3];
let b = [...a, 4, 5];

console.log(b); // [1, 2, 3, 4, 5]
```

Object example:

```
let student = { name: "Mira", age: 20 };

let updated = { ...student, age: 21 };

console.log(updated);
```

Rest collects values; spread expands values.

### 3.7 Closures

A closure occurs when an inner function remembers and accesses variables from its outer function, even after the outer function has finished executing.

```
function counter() {
    let count = 0;

    return function() {
        count++;
        return count;
    };
}

const increment = counter();

console.log(increment()); // 1
console.log(increment()); // 2
console.log(increment()); // 3
```

Here, the inner function remembers `count`.

Uses: Data privacy, counters, function factories and maintaining state.

### 3.8 Callbacks

A callback is a function passed as an argument to another function and called later.

```
function greet(name, callback) {
    console.log("Hello " + name);
    callback();
}

function message() {
    console.log("Welcome!");
}

greet("Mira", message);
```

Output:

```
Hello Mira
Welcome!
```

Callbacks are commonly used in event handling and asynchronous operations.

## 4. Arrays

An array stores multiple values in a single variable. Arrays are ordered, zero-indexed and mutable.

```
const fruits = ["Apple", "Mango", "Banana"];

console.log(fruits[0]);    // Apple
console.log(fruits.length); // 3
```

### 4.1 Important array methods

| Method      | Purpose                                     | Returns                   |
| ----------- | ------------------------------------------- | ------------------------- |
| `map()`     | Transforms every element                    | New array                 |
| `filter()`  | Selects elements matching a condition       | New array                 |
| `reduce()`  | Combines elements into one result           | Single value              |
| `find()`    | Finds the first matching element            | Element or `undefined`    |
| `some()`    | Checks whether at least one element matches | Boolean                   |
| `every()`   | Checks whether all elements match           | Boolean                   |
| `sort()`    | Sorts array elements                        | Sorted array (same array) |
| `forEach()` | Executes a function for each element        | `undefined`               |

1\. `map()` — Transform elements

```
const numbers = [1, 2, 3, 4];

const doubled = numbers.map(n => n * 2);

console.log(doubled); // [2, 4, 6, 8]
```

2\. `filter()` — Select elements

```
const numbers = [1, 2, 3, 4, 5];

const even = numbers.filter(n => n % 2 === 0);

console.log(even); // [2, 4]
```

3\. `reduce()` — Calculate a single result

It takes an accumulator and the current element.

```
const numbers = [10, 20, 30];

const total = numbers.reduce((sum, n) => sum + n, 0);

console.log(total); // 60
```

Here, `0` is the initial accumulator value.

4\. `find()` — Find the first matching element

```
const numbers = [10, 20, 30, 40];

const result = numbers.find(n => n > 20);

console.log(result); // 30
```

5\. `some()` — At least one element matches

```
const numbers = [1, 3, 5, 8];

console.log(numbers.some(n => n % 2 === 0)); // true
```

6\. `every()` — All elements must match

```
const numbers = [2, 4, 6, 8];

console.log(numbers.every(n => n % 2 === 0)); // true
```

7\. `sort()` — Sort elements

By default, `sort()` converts elements to strings and sorts them lexicographically.

```
const numbers = [10, 5, 20, 2];

numbers.sort();

console.log(numbers); // [10, 2, 20, 5]
```

For numeric ascending order:

```
numbers.sort((a, b) => a - b);
// [2, 5, 10, 20]
```

For numeric descending order:

```
numbers.sort((a, b) => b - a);
// [20, 10, 5, 2]
```

Important: `sort()` modifies the original array. For a non-mutating copy, use:

```
const sorted = [...numbers].sort((a, b) => a - b);
```

8\. `forEach()` — Perform an action for each element

```
const numbers = [1, 2, 3];

numbers.forEach(n => {
    console.log(n);
});
```

Output:

```
1
2
3
```

`forEach()` does not return a new array. Use `map()` when you need a transformed array.

### 4.2 Quick comparison

| Method      | Main question                                  |
| ----------- | ---------------------------------------------- |
| `map()`     | What should each element become?               |
| `filter()`  | Which elements should remain?                  |
| `reduce()`  | What single result should I calculate?         |
| `find()`    | What is the first matching element?            |
| `some()`    | Does at least one match?                       |
| `every()`   | Do all match?                                  |
| `sort()`    | How should elements be ordered?                |
| `forEach()` | What action should I perform for each element? |

## 5. Objects

Objects store data as key-value pairs called properties.

### 5.1 Object literals

An object literal is the simplest way to create an object.

```
const student = {
    name: "Mira",
    age: 20,
    course: "Computer Engineering"
};

console.log(student.name);    // Mira
console.log(student["age"]);  // 20
```

You can add, update and delete properties.

```
student.city = "Anand";  // Add
student.age = 21;        // Update
delete student.course;   // Delete
```

### 5.2 Destructuring

Destructuring extracts values from arrays or properties from objects into variables.

Object destructuring:

```
const student = {
    name: "Mira",
    age: 20
};

const { name, age } = student;

console.log(name); // Mira
console.log(age);  // 20
```

Renaming variables:

```
const { name: studentName } = student;

console.log(studentName); // Mira
```

Default value:

```
const { city = "Anand" } = student;
```

Array destructuring:

```
const colors = ["Red", "Blue", "Green"];

const [first, second] = colors;

console.log(first);  // Red
console.log(second); // Blue
```

Skipping elements:

```
const [a, , c] = [10, 20, 30];

console.log(a, c); // 10 30
```

### 5.3 Object spread

The spread operator (`...`) copies properties into another object.

```
const student = {
    name: "Mira",
    age: 20
};

const updatedStudent = {
    ...student,
    age: 21,
    city: "Anand"
};
```

It creates a shallow copy, not a deep copy. Nested objects can still be shared.

If two properties have the same key, the later property overwrites the earlier one.

### 5.4 Optional chaining (`?.`)

Optional chaining safely accesses nested properties without causing an error when an intermediate value is `null` or `undefined`.

```
const student = {
    name: "Mira",
    address: {
        city: "Anand"
    }
};

console.log(student.address?.city);   // Anand
console.log(student.contact?.phone); // undefined
```

Without optional chaining, accessing a property of an undefined value can cause a `TypeError`.

It can also be used with methods:

```
student.display?.();
```

If `display` is missing or nullish, it will not be called.

### 5.5 Object methods

`Object.keys()` — Returns an array of property names.

```
const student = { name: "Mira", age: 20 };

console.log(Object.keys(student));
// ["name", "age"]
```

`Object.values()` — Returns an array of property values.

```
console.log(Object.values(student));
// ["Mira", 20]
```

`Object.entries()` — Returns an array of key-value pairs.

```
console.log(Object.entries(student));
// [["name", "Mira"], ["age", 20]]
```

| Method             | Returns         |
| ------------------ | --------------- |
| `Object.keys()`    | Keys            |
| `Object.values()`  | Values          |
| `Object.entries()` | Key-value pairs |

## 6. Classes

Classes provide a structured way to create objects using a common blueprint. JavaScript classes were introduced in ES6.

### 6.1 Class and constructor

A constructor is a special method called automatically when an object is created using `new`.

```
class Student {
    constructor(name, age) {
        this.name = name;
        this.age = age;
    }
}

const s1 = new Student("Mira", 20);

console.log(s1.name); // Mira
```

`this` refers to the current object instance when used in this constructor.

### 6.2 Methods

Methods are functions defined inside a class.

```
class Student {
    constructor(name) {
        this.name = name;
    }

    display() {
        console.log("Student: " + this.name);
    }
}

const s1 = new Student("Mira");
s1.display(); // Student: Mira
```

### 6.3 Getters and setters

- Getter: Reads or calculates a property.
- Setter: Sets or updates a property, potentially with validation.

```
class Student {
    constructor(name) {
        this._name = name;
    }

    get name() {
        return this._name;
    }

    set name(value) {
        if (value.length > 0) {
            this._name = value;
        }
    }
}

const s1 = new Student("Mira");

console.log(s1.name); // Mira

s1.name = "Riya";
console.log(s1.name); // Riya
```

Access them like properties, not like ordinary methods:

```
s1.name;       // Getter
s1.name = "A"; // Setter
```

### 6.4 Inheritance: `extends` and `super`

Inheritance allows a child class to reuse and extend the functionality of a parent class.

- `extends` creates the inheritance relationship.
- `super()` calls the parent constructor.
- `super.method()` calls a parent class method.

```
class Person {
    constructor(name) {
        this.name = name;
    }

    display() {
        console.log(this.name);
    }
}

class Student extends Person {
    constructor(name, course) {
        super(name);
        this.course = course;
    }

    showCourse() {
        console.log(this.course);
    }
}

const s1 = new Student("Mira", "Computer Engineering");

s1.display();    // Mira
s1.showCourse(); // Computer Engineering
```

Important:

- A derived class must call `super()` before accessing `this` in its constructor.
- A class can extend another class using `extends`.
- If a child class defines a method with the same name as the parent method, it can override that method.

## 7. Modules

Modules allow JavaScript code to be divided into separate files and reused through imports and exports.

### 7.1 Named exports

A file can export multiple named values.

math.js

```
export const pi = 3.14;

export function add(a, b) {
    return a + b;
}
```

Import them:

app.js

```
import { pi, add } from "./math.js";

console.log(pi);
console.log(add(5, 3));
```

You can also rename an imported value:

```
import { add as sum } from "./math.js";
```

### 7.2 Default exports

A module can have one default export.

greet.js

```
export default function greet() {
    console.log("Hello!");
}
```

Import it:

```
import greet from "./greet.js";

greet();
```

Notice that curly braces are not required for default imports.

### 7.3 Named vs default exports

| Named export                               | Default export                   |
| ------------------------------------------ | -------------------------------- |
| Multiple named exports allowed             | One default export per module    |
| Imported using `{ }`                       | Imported without `{ }`           |
| Import name normally matches exported name | Importer can choose its own name |
| `export const x = 10`                      | `export default value`           |

Important: A module can have both named and default exports.

Modules are commonly used to organize large applications, separate functionality and reuse code.

## 8. Asynchronous JavaScript

JavaScript normally executes code in a single main thread. Asynchronous operations allow tasks such as network requests and timers to complete without blocking the main execution flow.

### 8.1 Synchronous vs asynchronous

Synchronous: Executes one statement at a time; the next statement waits for the previous one to finish.

```
console.log("First");
console.log("Second");
console.log("Third");
```

Output:

```
First
Second
Third
```

Asynchronous: Some operations complete later, allowing other code to continue executing.

```
console.log("Start");

setTimeout(() => {
    console.log("Delayed");
}, 1000);

console.log("End");
```

Output:

```
Start
End
Delayed
```

### 8.2 Event loop (concept)

The event loop coordinates synchronous code and asynchronous callbacks.

Important components:

1. Call Stack: Keeps track of functions currently executing.
2. Web APIs / Runtime APIs: Handle operations such as timers and browser events outside the JavaScript call stack.
3. Callback Queue (Task Queue): Holds callbacks for tasks such as completed timers.
4. Microtask Queue: Holds promise reaction callbacks.
5. Event Loop: Checks whether the call stack is empty and schedules queued work.

Simplified event loop flow

Synchronous JavaScript

Runs on the call stack

Call stack becomes empty

Microtask queue

Promise callbacks run first

Task / callback queue

For example, timer callbacks

Conceptual flow: the runtime and event loop coordinate when queued work can execute. Microtasks are processed before the next task.

Example:

```
console.log("A");

setTimeout(() => console.log("B"), 0);

Promise.resolve().then(() => console.log("C"));

console.log("D");
```

Output:

```
A
D
C
B
```

Why?

- `A` and `D` execute synchronously.
- The Promise callback goes into the microtask queue.
- The timer callback goes into the task queue.
- Microtasks execute before the next task.

### 8.3 Callbacks in asynchronous operations

A callback can execute after an operation completes.

```
setTimeout(() => {
    console.log("Executed after 1 second");
}, 1000);
```

One problem with deeply nested callbacks is callback hell — code becomes difficult to read and maintain.

Promises and async/await help manage this.

### 8.4 Promises

A Promise represents the eventual completion or failure of an asynchronous operation.

Three states:

1. Pending: Operation is still running.
2. Fulfilled: Operation completed successfully.
3. Rejected: Operation failed.

```
const myPromise = new Promise((resolve, reject) => {
    let success = true;

    if (success) {
        resolve("Task completed");
    } else {
        reject("Task failed");
    }
});
```

- `resolve()` fulfills the Promise.
- `reject()` rejects the Promise.

Handling a Promise:

```
myPromise
    .then(result => {
        console.log(result);
    })
    .catch(error => {
        console.log(error);
    })
    .finally(() => {
        console.log("Finished");
    });
```

- `.then()` handles successful results.
- `.catch()` handles rejection/errors.
- `.finally()` executes after settlement, regardless of success or failure.

Promise chaining:

```
Promise.resolve(5)
    .then(n => n * 2)
    .then(result => result + 5)
    .then(result => console.log(result)); // 15
```

Each `.then()` can return a value or another Promise.

### 8.5 Async and await

`async` and `await` provide a cleaner way to work with Promises.

- An `async` function always returns a Promise.
- `await` pauses execution inside that async function until the Promise settles.
- It does not block the entire JavaScript thread.

```
function getData() {
    return Promise.resolve("Data received");
}

async function displayData() {
    const result = await getData();
    console.log(result);
}

displayData();
```

Output:

```
Data received
```

### 8.6 Error handling with try/catch

`try/catch` handles errors so the program can respond instead of terminating unexpectedly.

```
async function getData() {
    try {
        const result = await Promise.reject("Something went wrong");
        console.log(result);
    } catch (error) {
        console.log("Error:", error);
    } finally {
        console.log("Operation finished");
    }
}

getData();
```

- `try` contains code that may throw an error.
- `catch` handles the error.
- `finally` executes whether an error occurs or not.

Important: For a rejected Promise, use `.catch()` or `try/catch` with `await` to handle the rejection.

### 8.7 Fetch API

`fetch()` is used to make HTTP requests and retrieve resources, commonly from APIs.

It returns a Promise.

GET request:

```
async function getUsers() {
    try {
        const response = await fetch("https://api.example.com/users");

        if (!response.ok) {
            throw new Error("HTTP error: " + response.status);
        }

        const data = await response.json();

        console.log(data);
    } catch (error) {
        console.log("Error:", error.message);
    }
}

getUsers();
```

Important points:

- `fetch(url)` sends the request and returns a Promise.
- `response.ok` is true for HTTP status codes in the 200–299 range.
- `response.status` provides the HTTP status code.
- `response.json()` reads and parses the response body as JSON and returns a Promise.
- `catch()` or `try/catch` handles network errors and thrown errors.

POST request:

```
async function createUser() {
    try {
        const response = await fetch("https://api.example.com/users", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                name: "Mira",
                age: 20
            })
        });

        if (!response.ok) {
            throw new Error("Request failed");
        }

        const data = await response.json();
        console.log(data);

    } catch (error) {
        console.log(error.message);
    }
}

createUser();
```

Remember:

- `method` specifies GET, POST, PUT, DELETE, etc.
- `headers` provide request metadata.
- `JSON.stringify()` converts a JavaScript object into a JSON string.
- `body` contains the request data.

Important MCQ point: `fetch()` does not automatically reject its Promise for HTTP errors such as 404 or 500. You should check `response.ok` or `response.status`.

## 9. DOM basics

DOM stands for Document Object Model.

The browser converts an HTML document into a tree-like structure of objects. JavaScript can access and modify this structure.

Example DOM tree

document

html

head

title

body

h1, p, button

### 9.1 Selecting elements

JavaScript provides methods to select HTML elements.

Assume this HTML:

```
<h1 id="title">Hello</h1>
<p class="message">Welcome</p>
<button>Click me</button>
```

`getElementById()` — Selects an element by ID.

```
const title = document.getElementById("title");
```

`getElementsByClassName()` — Selects elements by class name. Returns a live HTMLCollection.

```
const messages = document.getElementsByClassName("message");
```

`getElementsByTagName()` — Selects elements by tag name.

```
const paragraphs = document.getElementsByTagName("p");
```

`querySelector()` — Selects the first element matching a CSS selector.

```
const title = document.querySelector("#title");
const message = document.querySelector(".message");
const button = document.querySelector("button");
```

`querySelectorAll()` — Selects all matching elements and returns a static NodeList.

```
const allParagraphs = document.querySelectorAll("p");
```

### 9.2 Updating page content

JavaScript can modify text, HTML and CSS styles.

`textContent` — Changes or reads text content.

```
document.getElementById("title").textContent = "Welcome!";
```

`innerHTML` — Changes or reads HTML content.

```
document.getElementById("title").innerHTML = "<b>Hello!</b>";
```

Important: Avoid putting untrusted user input into `innerHTML`, as it can introduce cross-site scripting (XSS). Prefer `textContent` for plain text.

Changing CSS styles:

```
const title = document.querySelector("#title");

title.style.color = "blue";
title.style.backgroundColor = "yellow";
```

Changing classes:

```
title.classList.add("active");
title.classList.remove("active");
title.classList.toggle("active");
title.classList.contains("active");
```

### 9.3 Handling events

An event is an action that occurs in the browser, such as clicking a button, typing, submitting a form or loading a page.

Common events:

| Event       | Meaning                          |
| ----------- | -------------------------------- |
| `click`     | Element clicked                  |
| `dblclick`  | Double-click                     |
| `mouseover` | Pointer moves over element       |
| `mouseout`  | Pointer leaves element           |
| `keydown`   | Keyboard key pressed             |
| `keyup`     | Keyboard key released            |
| `input`     | Input value changes              |
| `change`    | Input value is committed/changed |
| `submit`    | Form submitted                   |
| `load`      | Resource or page loaded          |

Using `addEventListener()`

```
<button id="btn">Click Me</button>
<p id="result"></p>
```

```
const button = document.getElementById("btn");
const result = document.getElementById("result");

button.addEventListener("click", function() {
    result.textContent = "Button clicked!";
});
```

### 9.4 Event object

The event handler receives an event object containing information about the event.

```
button.addEventListener("click", function(event) {
    console.log(event.target);
    console.log(event.type);
});
```

- `event.target` identifies the element where the event originated.
- `event.type` gives the event type.

Preventing default behaviour:

```
form.addEventListener("submit", function(event) {
    event.preventDefault();
    console.log("Form submission handled by JavaScript");
});
```

`preventDefault()` prevents the browser's default action, such as the normal form submission.

Removing an event listener:

```
function handleClick() {
    console.log("Clicked");
}

button.addEventListener("click", handleClick);
button.removeEventListener("click", handleClick);
```

The same function reference must be used to remove the listener.

### 9.5 Example: Complete DOM interaction

HTML:

```
<h2 id="heading">JavaScript</h2>
<button id="changeBtn">Change Text</button>
```

JavaScript:

```
const heading = document.getElementById("heading");
const button = document.getElementById("changeBtn");

button.addEventListener("click", () => {
    heading.textContent = "DOM Updated!";
    heading.style.color = "green";
});
```

When the button is clicked, the heading text and color change without reloading the page.

# Final JavaScript revision sheet

These are the important differences and common MCQ traps to remember.

| Concept              | Remember                                                   |
| -------------------- | ---------------------------------------------------------- |
| `var`                | Function-scoped; can be redeclared                         |
| `let`                | Block-scoped; can be reassigned                            |
| `const`              | Block-scoped; cannot be reassigned                         |
| Hoisting             | Declarations are processed before execution                |
| TDZ                  | `let`/`const` cannot be accessed before initialization     |
| Primitive            | Value is copied                                            |
| Object               | Reference is copied                                        |
| Falsy                | `false`, `0`, `-0`, `0n`, `""`, `null`, `undefined`, `NaN` |
| `==`                 | Allows type coercion                                       |
| `===`                | Strict comparison                                          |
| Arrow function       | No own `this`                                              |
| Rest                 | Collects arguments into an array                           |
| Spread               | Expands iterable/object properties                         |
| Closure              | Inner function remembers outer variables                   |
| `map()`              | Returns transformed array                                  |
| `filter()`           | Returns matching elements                                  |
| `reduce()`           | Returns accumulated result                                 |
| `find()`             | First matching element                                     |
| `some()`             | At least one matches                                       |
| `every()`            | All match                                                  |
| `forEach()`          | Returns `undefined`                                        |
| `sort()`             | Mutates original array                                     |
| `?.`                 | Safe optional property access                              |
| `Object.keys()`      | Keys                                                       |
| `Object.values()`    | Values                                                     |
| `Object.entries()`   | Key-value pairs                                            |
| `extends`            | Inheritance                                                |
| `super()`            | Calls parent constructor                                   |
| Named export         | Imported using `{ }`                                       |
| Default export       | Imported without `{ }`                                     |
| Promise              | Pending, fulfilled or rejected                             |
| `async`              | Function returns a Promise                                 |
| `await`              | Waits for Promise settlement inside async function         |
| `fetch()`            | Returns a Promise; check `response.ok`                     |
| DOM                  | JavaScript representation of HTML                          |
| `querySelector()`    | First matching element                                     |
| `querySelectorAll()` | All matching elements                                      |
| `addEventListener()` | Attaches an event handler                                  |
| `preventDefault()`   | Prevents default browser action                            |




 # React

React is a JavaScript library used to build user interfaces (UI).

It helps us create interactive web applications using reusable components.

### How React works with the MERN stack

```text
React Frontend
Login • Dashboard • Tickets • Profile
          |
     HTTP Requests
          |
Express + Node.js
Routes • Controllers • Services • Authentication
          |
       MongoDB
   Stores application data
```

React handles the frontend, Express and Node.js handle the backend, and MongoDB stores the data.

## Important features of React

1. **Component-based architecture:** The UI is divided into smaller components.
2. **Reusable UI:** We can create a component once and use it in multiple places.
3. **State management:** React helps manage data that changes over time.
4. **Virtual DOM:** React efficiently updates the UI when data changes.
5. **One-way data flow:** Data generally flows from parent components to child components.
6. **Rich ecosystem:** React supports many useful libraries for routing, forms, API calls, etc.

## What is a Single Page Application (SPA)?

A Single Page Application (SPA) is a web application that loads a single HTML page initially.

When users navigate between different sections, React updates the required components without reloading the entire browser page.

**Example:**

In a HelpDesk application, when we move from the Dashboard to Tickets, only the required UI changes. The entire browser page does not reload.

# 1. Getting Started with React

## A. What is Vite?

Vite is a frontend development tool that provides:

- A fast development server.
- Tools to build optimized files for production.
- Fast updates while developing the application.

### Creating a React project using Vite

Run the following commands:

```bash
npm create vite@latest helpdesk-frontend -- --template react-ts
```

This creates a new React project using TypeScript.

Move into the project folder:

```bash
cd helpdesk-frontend
```

Install the required dependencies:

```bash
npm install
```

Start the development server:

```bash
npm run dev
```

Vite provides a local URL where we can open and test our React application.

## B. React project structure

| File/Folder | Purpose |
|---|---|
| src/ | Contains the main application code. |
| App.tsx | Main application component. |
| main.tsx | Entry point that renders the React application. |
| App.css | Styling for the App component. |
| index.css | Global CSS styling. |
| public/ | Stores static files such as images. |
| package.json | Contains project dependencies and scripts. |
| vite.config.ts | Contains Vite configuration. |
| index.html | Main HTML document loaded by the browser. |

# 2. Components in React

A component is a reusable piece of UI.

We divide an application into smaller components to make the code easier to manage and reuse.

For example, a HelpDesk application can have:

- Login component
- Dashboard component
- TicketList component
- Profile component

React components are generally created inside the `src` folder. We can organize them in a folder such as `src/components`.

With TypeScript, component files use the `.tsx` extension.

### Example

```tsx
function App() {
    return (
        <div>
            <h1>Welcome to HelpDesk</h1>
            <p>Manage your support tickets easily.</p>
        </div>
    );
}

export default App;
```

### Understanding the code

- `function App()` defines a React component.
- `return` contains the UI that should be displayed.
- JSX describes what should appear on the screen.
- `export default App` allows other files to import this component.

**Important:** React component names should always start with an uppercase letter.

# 3. JSX

JSX stands for JavaScript XML.

It allows us to write HTML-like syntax inside JavaScript or TypeScript.

React uses JSX to describe the UI.

### Important JSX rules

1. **Return a single parent element:** All JSX elements must be wrapped inside one parent element. We can also use fragments (`<> </>`).
2. **Use className instead of class:** React uses `className` to assign CSS classes.
3. **Use curly braces for JavaScript expressions:** For example, `{count}`.
4. **Use camelCase for most attributes and event names:** For example, `onClick` instead of `onclick`.
5. **Close every JSX element:** For example, `<input />` and `<img />`.

### React vs Angular

| Concept | React | Angular |
|---|---|---|
| Nature | UI library | Frontend framework |
| Language | JavaScript / TypeScript | TypeScript |
| UI syntax | JSX | HTML templates |
| Components | Functional components | Components |
| Data binding | Props and state | Property and event binding |
| Routing | React Router | Angular Router |
| HTTP requests | Fetch / Axios | HttpClient |
| Forms | Libraries such as React Hook Form | Reactive / Template-driven forms |

# 4. Data in Components

React components mainly work with two important concepts:

1. Props
2. State

## A. Props

Props stands for properties.

Props are used to pass data from a parent component to a child component.

For example:

- Parent component: App
- Child component: Profile

The App component can pass a user's name to the Profile component using props.

**Important points:**
- Props allow components to communicate.
- Props are read-only.
- A child component should not directly modify the props it receives.

## B. State

State is data managed by a component that can change over time.

Whenever state changes, React updates the UI where that state is used.

For example, in a HelpDesk application:
- Number of notifications.
- Search input.
- Selected ticket status.
- Logged-in user information.

### useState Hook

React provides a Hook called `useState()` to manage state inside functional components.

Syntax:

```tsx
const [state, setState] = useState(initialValue);
```

| Part | Meaning |
|---|---|
| state | Current value |
| setState | Function used to update the value |
| initialValue | Starting value of the state |

### Example: Counter

```tsx
import { useState } from "react";

function Counter() {
    const [count, setCount] = useState(0);

    return (
        <div>
            <h2>Count: {count}</h2>

            <button onClick={() => setCount(count + 1)}>
                Increase
            </button>
        </div>
    );
}

export default Counter;
```

**Understanding the example:**

- `useState(0)` initializes the count to zero.
- `count` stores the current value.
- `setCount()` updates the count.
- When the button is clicked, the count increases by one.
- React updates the UI automatically.

### State with different data types

We can store different types of data using state.

**1. String state**

```tsx
const [name, setName] = useState("Rahul");
```

Used to store text.

**2. Boolean state**

```tsx
const [isLoggedIn, setIsLoggedIn] = useState(false);
```

Used to store true or false values.

**3. Array state**

```tsx
const [tickets, setTickets] = useState<string[]>([]);
```

Used to store a list of values.

**4. Object state**

```tsx
const [user, setUser] = useState({
    name: "Rahul",
    role: "Employee"
});
```

Used to store related information together.

## C. Lifting State Up

Sometimes, two or more components need to use the same state.

Where should we store that state?

We store it in their nearest common parent component and pass the required data to child components through props.

This process is called **Lifting State Up**.

### Example

Suppose our HelpDesk application has two components:

- `TicketSearch` – accepts a search value.
- `TicketList` – displays tickets matching that search value.

Both components need access to the same search value.

Instead of maintaining separate states, we store the search value in their common parent and pass it to both components.

### Props vs State

| Props | State |
|---|---|
| Passed from parent to child | Managed by a component |
| Read-only | Updated using a setter function |
| Used to pass data between components | Used to manage changing data |
| Example: Ticket title received from parent | Example: Notification count |

# 5. Side Effects in React

A React component mainly renders the UI based on its props and state.

However, applications also need to perform tasks outside the normal rendering process.

These tasks are called **side effects**.

Examples:
- Fetching data from an API.
- Starting a timer.
- Adding event listeners.
- Subscribing to external services.

## useEffect Hook

`useEffect()` is a React Hook used to perform side effects inside functional components.

It has three important parts:

1. **Effect function:** Contains the side effect.
2. **Cleanup function:** Removes or stops the previous effect when necessary.
3. **Dependency array:** Determines when the effect should run again.

### Three important ways to use useEffect

**Case 1: Without a dependency array**

```tsx
useEffect(() => {
    console.log("Component rendered");
});
```

- Runs after every render.
- Runs again whenever the component re-renders.

**Case 2: With an empty dependency array**

```tsx
useEffect(() => {
    console.log("Component mounted");
}, []);
```

- Runs after the component initially mounts.
- Does not run again because of ordinary state or prop changes.

**Case 3: With values in the dependency array**

```tsx
useEffect(() => {
    console.log("Count changed");
}, [count]);
```

- Runs after the initial mount.
- Runs again whenever `count` changes.

## Practical Example: Timer using useEffect

Let's create a timer that increases the count every second.

```tsx
import { useEffect, useState } from "react";

function Timer() {
    const [count, setCount] = useState(0);

    useEffect(() => {
        const timer = setInterval(() => {
            setCount((prev) => prev + 1);
        }, 1000);

        return () => {
            clearInterval(timer);
        };
    }, []);

    return (
        <div>
            <h2>Timer: {count}</h2>
        </div>
    );
}

export default Timer;
```

### Understanding the code

- `useState(0)` initializes the timer at zero.
- `useEffect()` starts the timer after the component mounts.
- `setInterval()` executes a function every 1000 milliseconds (one second).
- `setCount()` updates the count.
- `prev` represents the previous state value.
- `clearInterval()` stops the timer during cleanup.
- `[]` means the effect does not re-run because of ordinary re-renders.

### Why use setCount((prev) => prev + 1)?

We use the functional update because it receives the latest state value.

This avoids problems caused by using an older state value (stale state).

## Cleanup Function

Some side effects create resources that should be released when they are no longer needed.

The cleanup function helps us stop or remove them.

| Side Effect | Cleanup |
|---|---|
| setInterval() | clearInterval() |
| setTimeout() | clearTimeout() |
| Event listener | removeEventListener() |
| API request | Abort the request when appropriate |
| Subscription | Unsubscribe |

### Important concepts and common mistakes

**A. Don't use useEffect for derived state**

If a value can be calculated directly from existing props or state, calculate it during rendering instead of creating another state and updating it through `useEffect()`.

**B. Avoid infinite loops**

Updating state inside an effect can cause repeated renders if the dependencies are not handled correctly.

**C. Include dependencies**

Include the reactive values used inside the effect in its dependency array.

**D. StrictMode**

React StrictMode helps identify potential problems during development.

In development, it may run an effect's setup and cleanup an additional time to check whether the effect is written correctly.

# 6. Rendering in React

Rendering means displaying data and UI elements on the screen.

React provides JavaScript methods such as `map()` to display lists dynamically.

## A. Rendering Lists using map()

Suppose we have multiple tickets and want to display them.

We can use the JavaScript `map()` function.

```tsx
const tickets = ["Login issue", "Payment issue", "Network issue"];

function TicketList() {
    return (
        <div>
            {tickets.map((ticket) => (
                <p key={ticket}>{ticket}</p>
            ))}
        </div>
    );
}
```

The `map()` function goes through each item and returns a new array of JSX elements.

## B. Keys in React

Keys are special attributes that help React identify individual elements in a list.

They help React understand which items were added, removed or updated.

### Rules for keys

1. Keys should be unique among sibling elements.
2. Keys should be stable.
3. Avoid array indexes when the list can change.
4. Do not generate random keys during rendering.
5. Prefer unique database IDs when available.

Example:

```tsx
{tickets.map((ticket) => (
    <p key={ticket._id}>{ticket.title}</p>
))}
```

## C. Conditional Rendering

Conditional rendering means displaying different UI elements based on a condition.

React supports different ways to implement it.

**1. If-else**

```tsx
if (isLoggedIn) {
    return <h2>Welcome back!</h2>;
} else {
    return <h2>Please login</h2>;
}
```

**2. Ternary operator**

```tsx
{isLoggedIn ? <h2>Welcome</h2> : <h2>Please login</h2>}
```

**3. Logical AND (&&)**

```tsx
{isLoggedIn && <h2>Welcome back!</h2>}
```

The second element is displayed only when the condition is true.

### Important points

| Concept | Remember |
|---|---|
| map() | Used to render arrays |
| key | Helps React identify list elements |
| Stable key | Prefer unique database IDs |
| Ternary ? : | Selects between two UI outputs |
| Logical && | Displays something when a condition is true |
| if-else | Handles more complex conditions |

Additional points:

- `map()` returns a new array; it does not modify the original array.
- React expects a unique key among sibling elements.
- Keys are not available as normal component props.
- Conditional rendering uses normal JavaScript expressions.
- We can use multiple conditions with if-else if, nested ternaries or separate variables.

# 7. Shared State in React

When an application grows, multiple components may need access to the same information.

Two important concepts help us manage shared data and logic:

1. Context API
2. Custom Hooks

## A. Prop Drilling

Prop drilling means passing data through multiple intermediate components just to reach a component that actually needs it.

For example:

```text
App
 |
Dashboard
 |
Profile
```

Suppose App has user information, but only Profile needs it.

We may have to pass the user information through Dashboard even though Dashboard does not need it.

This is called prop drilling.

**Solution: React Context API**

## B. Context API

Context API allows us to share data between components without manually passing props through every intermediate component.

It is useful for information such as:

- Logged-in user details.
- Authentication information.
- Application theme.
- Language preferences.

### How Context works

There are three main steps:

1. Create a context.
2. Provide a value using a Provider.
3. Access that value using `useContext()`.

Example:

```text
AuthContext.Provider
        |
      App
        |
   Dashboard
        |
      Profile
        |
  Reads user using
    useContext()
```

Dashboard does not need to receive the user through props if it does not use that information.

## Creating Context step by step

Let's understand it using a HelpDesk authentication example.

### Step 1: Create a Context

Create a file:

`src/context/AuthContext.tsx`

```tsx
import { createContext } from "react";

interface User {
    name: string;
    role: string;
}

interface AuthContextType {
    user: User | null;
}

export const AuthContext = createContext<AuthContextType | null>(null);
```

**Explanation:**

- `createContext()` creates a Context object.
- `User` defines the structure of user information.
- `AuthContextType` defines what information the context contains.
- `user` can contain user details or `null` if nobody is logged in.
- `null` is the default context value.

### Step 2: Create a Provider

Now update `AuthContext.tsx`.

```tsx
import { createContext, useState } from "react";
import type { ReactNode } from "react";

interface User {
    name: string;
    role: string;
}

interface AuthContextType {
    user: User | null;
    login: (user: User) => void;
    logout: () => void;
}

export const AuthContext = createContext<AuthContextType | null>(null);

export function AuthProvider({ children }: { children: ReactNode }) {
    const [user, setUser] = useState<User | null>(null);

    const login = (userData: User) => {
        setUser(userData);
    };

    const logout = () => {
        setUser(null);
    };

    return (
        <AuthContext.Provider value={{ user, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
}
```

**Understanding the important parts:**

- `AuthProvider` is a component that provides authentication data.
- `children` represents the components wrapped inside the Provider.
- `useState()` stores the currently logged-in user.
- `login()` updates the user information.
- `logout()` clears the user information.
- `value={{ user, login, logout }}` makes these values available to components inside the Provider.

Notice that Context can share functions as well as data.

### Step 3: Wrap the application with Provider

Open `src/main.tsx`.

```tsx
import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import { AuthProvider } from "./context/AuthContext";

ReactDOM.createRoot(
    document.getElementById("root")!
).render(
    <React.StrictMode>
        <AuthProvider>
            <App />
        </AuthProvider>
    </React.StrictMode>
);
```

Now every component inside App can access the authentication context.

### Step 4: Consume Context using useContext

Suppose we have a Profile component.

```tsx
import { useContext } from "react";
import { AuthContext } from "../context/AuthContext";

function Profile() {
    const auth = useContext(AuthContext);

    if (!auth) {
        throw new Error("Profile must be inside AuthProvider");
    }

    return (
        <div>
            <h2>Welcome {auth.user?.name ?? "Guest"}</h2>
            <p>Role: {auth.user?.role ?? "Not logged in"}</p>
        </div>
    );
}

export default Profile;
```

**Explanation:**

- `useContext(AuthContext)` reads the nearest matching Provider's value.
- `auth.user` accesses the logged-in user's information.
- `?.` is optional chaining. It prevents errors when the user is null.
- `??` provides a fallback value when the expression is null or undefined.

The Profile component can now access user information directly.

### Updating Context data

We can also update shared state through functions provided by the Context.

For example:

- `login()` updates the user information.
- `logout()` clears the user information.

These functions can be called from any component that accesses the Context.

### Important Context API concepts

| Concept | Explanation |
|---|---|
| createContext() | Creates a Context object |
| Provider | Makes a value available to child components |
| useContext() | Reads the nearest Provider value |
| children | Components wrapped inside the Provider |
| value | Data and functions shared through Context |

## C. Custom Hooks

Sometimes, we need the same stateful logic in multiple components.

Instead of repeating the same logic everywhere, we can create our own reusable function called a **Custom Hook**.

Custom Hooks allow us to reuse React logic between components.

For example, we can create a custom Hook for fetching tickets from an API.

`useTickets()` can contain the logic for fetching ticket data and handling loading and error states.

### Rules of Hooks

1. Only call Hooks at the top level of a component or custom Hook.
2. Do not call Hooks inside loops, conditions or nested functions.
3. Call Hooks only inside React function components or custom Hooks.

### Context API vs Custom Hooks

| Context API | Custom Hooks |
|---|---|
| Shares values across components | Reuses stateful logic |
| Helps avoid prop drilling | Helps avoid repeated logic |
| Uses Provider and useContext | Uses a reusable function |
| Can provide shared state | Each call generally has independent state |
| Example: AuthContext | Example: useTickets |

# 8. Routing in React

Routing is the process of displaying the appropriate component based on the current URL.

For example:

- `/login` → Login page
- `/dashboard` → Dashboard page
- `/tickets` → Ticket list
- `/profile` → Profile page

React Router allows navigation between pages without performing a full browser page reload.

## A. React Router

React Router is a routing library used to manage navigation and URLs in React applications.

Install it:

```bash
npm install react-router
```

There are four important components:

### 1. BrowserRouter

It wraps the application and enables routing using the browser's History API.

### 2. Routes

It contains the collection of routes that React Router can match.

### 3. Route

It defines which component should be displayed for a particular URL.

### 4. Link

It allows users to navigate to another route without a full page reload.

## B. NavLink

NavLink is similar to Link, but it also provides information about whether the destination route is currently active.

It is useful for:
- Navigation menus.
- Sidebars.
- Highlighting the current page.

**Remember:**

- Link → Navigation.
- NavLink → Navigation plus active-state information.

## C. Programmatic Navigation using useNavigate

Sometimes, we need to navigate users after performing an action.

For example:

- After successful login → Dashboard.
- After creating a ticket → Ticket Details.
- After logout → Login.

We can use the `useNavigate()` Hook.

It allows us to navigate users through code instead of clicking a Link.

## D. Dynamic Routing and useParams

Suppose we have thousands of tickets.

Instead of creating a separate route for every ticket, we can create one dynamic route.

Example:

```text
/tickets/101
/tickets/102
/tickets/103
```

We can define a route like:

```tsx
/tickets/:id
```

Here, `:id` is a dynamic route parameter.

We use the `useParams()` Hook to read the dynamic value from the URL.

For example, `/tickets/101` gives us the ticket ID `101`.

## E. Nested Routing and Outlet

Nested routing allows us to create child routes inside a parent route.

For example, a dashboard may contain:

- Dashboard Overview
- My Tickets
- Assigned Tickets
- Profile

`Outlet` is a component that displays the matching child route inside the parent layout.

This allows us to reuse the same dashboard layout for multiple pages.

## F. Protected Routes

A protected route is a route that can only be accessed when certain conditions are satisfied.

For example:

- Only logged-in users can access the Dashboard.
- Only administrators can access the Admin page.

If a user is not authorized, we can redirect them to the Login page or another appropriate page.

## G. Handling Unknown Routes

Sometimes, users enter a URL that does not exist.

We can create a wildcard route using `*`.

It can display a custom 404 Not Found page.

### Common routing concepts

| Concept | Remember |
|---|---|
| BrowserRouter | Enables browser routing |
| Routes | Groups route definitions |
| Route | Maps a path to a component |
| Link | Provides internal navigation |
| NavLink | Navigation with active-state information |
| useNavigate | Programmatic navigation |
| useParams | Reads dynamic route parameters |
| Outlet | Displays matching child routes |
| Navigate | Redirects to another route |
| * | Matches unknown routes |

# 9. Forms in React

Forms are used to collect information from users.

For example, a HelpDesk application may have:

- Login form.
- Registration form.
- Create Ticket form.
- Update Profile form.

### Basic form example

```tsx
function Login() {
    return (
        <form>
            <input type="email" placeholder="Email" />

            <input type="password" placeholder="Password" />

            <button type="submit">Login</button>
        </form>
    );
}
```

## A. Controlled and Uncontrolled Components

**Controlled component:**

An input whose value is managed by React state.

Whenever the user enters something, the state is updated.

**Uncontrolled component:**

An input whose current value is managed by the DOM rather than directly through React state.

We can access its value using a React Ref.

### Difference

| Controlled | Uncontrolled |
|---|---|
| Value is managed by React state | Value is managed by the DOM |
| Uses useState | Commonly uses useRef |
| Updates are handled through state | Value can be accessed through a ref |

## B. Handling Forms using useState

We can use `useState()` to store input values and handle form submission.

However, manually managing separate state variables, change handlers and validation logic can become difficult when forms are large.

**Solution: React Hook Form**

## C. React Hook Form

React Hook Form is a library that simplifies form handling in React applications.

It helps us manage:

- Form input values.
- Form submission.
- Input registration.
- Validation.
- Error messages.

Install it:

```bash
npm install react-hook-form
```

### useForm()

React Hook Form provides a Hook called `useForm()`.

Some important properties are:

| Property | Purpose |
|---|---|
| register | Connects an input field to React Hook Form |
| handleSubmit | Handles form submission and validation |
| errors | Stores validation errors for individual fields |

Example:

```tsx
import { useForm } from "react-hook-form";

function Login() {
    const {
        register,
        handleSubmit,
        formState: { errors }
    } = useForm();

    const onSubmit = (data: any) => {
        console.log(data);
    };

    return (
        <form onSubmit={handleSubmit(onSubmit)}>
            <input
                type="email"
                {...register("email", { required: true })}
            />

            {errors.email && <p>Email is required</p>}

            <button type="submit">Login</button>
        </form>
    );
}
```

## D. What is Zod?

Zod is a TypeScript-first schema validation library.

It allows us to define the structure of data and validate whether the data follows the required rules.

For example:

- Name must contain at least 8 characters.
- Email must have a valid email format.
- Password must follow certain rules.

Install Zod:

```bash
npm install zod
```

### Important Zod methods

| Method | Purpose | Example |
|---|---|---|
| min() | Minimum length or value | z.string().min(3) |
| max() | Maximum length or value | z.string().max(50) |
| email() | Validates email format | z.email() |
| regex() | Validates a pattern | z.string().regex(...) |
| int() | Checks whether a number is an integer | z.number().int() |
| optional() | Allows undefined | z.string().optional() |
| nullable() | Allows null | z.string().nullable() |
| refine() | Adds custom validation | z.string().refine(...) |

## E. Integrating Zod with React Hook Form

We can use Zod and React Hook Form together.

- React Hook Form manages the form.
- Zod defines the validation rules.
- zodResolver connects Zod with React Hook Form.

Install the resolver:

```bash
npm install @hookform/resolvers
```

Example:

```tsx
import { useForm } from "react-hook-form";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";

const schema = z.object({
    name: z.string().min(8, "Name must have at least 8 characters"),
    email: z.email("Enter a valid email")
});

type FormData = z.infer<typeof schema>;

function Register() {
    const {
        register,
        handleSubmit,
        formState: { errors }
    } = useForm<FormData>({
        resolver: zodResolver(schema)
    });

    const onSubmit = (data: FormData) => {
        console.log(data);
    };

    return (
        <form onSubmit={handleSubmit(onSubmit)}>
            <input {...register("name")} />
            {errors.name && <p>{errors.name.message}</p>}

            <input {...register("email")} />
            {errors.email && <p>{errors.email.message}</p>}

            <button type="submit">Register</button>
        </form>
    );
}
```

### Important concepts and common mistakes

**A. preventDefault()**

Normally, submitting an HTML form causes the browser to perform its default form-submission behavior, which may reload or navigate the page.

When handling submission manually, we need to prevent this default behavior.

With React Hook Form, `handleSubmit()` handles the form submission process.

**B. Don't forget to register inputs**

```tsx
<input {...register("email")} />
```

Registering an input connects it to React Hook Form.

**C. Client-side validation vs Backend validation**

Zod validates the form on the frontend, but the Express backend must validate incoming data independently.

A user can bypass frontend validation and send requests directly to an API.

Therefore, backend validation is also necessary.

**D. Division of responsibility**

| Technology | Responsibility |
|---|---|
| React Hook Form | Form state and submission |
| Zod | Data validation |
| zodResolver | Connects Zod to React Hook Form |
| Express | Backend request handling |
| Backend validation | Enforces server-side data rules |

**E. What is z.infer?**

`z.infer` generates a TypeScript type from a Zod schema.

This avoids writing the same data structure separately for validation and TypeScript.

# 10. Talking to APIs

A React application usually needs to communicate with a backend to retrieve or send data.

For example, our HelpDesk frontend needs to:

- Retrieve all tickets.
- Create a new ticket.
- Update ticket information.
- Delete a ticket.
- Login and receive authentication information.

We use HTTP requests to communicate with the backend.

## A. Fetch API

JavaScript provides a built-in function called `fetch()` to make HTTP requests.

It allows us to communicate with backend APIs.

### Example: GET request

```tsx
const getTickets = async () => {
    const response = await fetch("http://localhost:3000/api/tickets");

    if (!response.ok) {
        throw new Error("Failed to fetch tickets");
    }

    const data = await response.json();

    return data;
};
```

### Handling errors

There is an important thing to remember about Fetch:

`fetch()` does not automatically throw an error for HTTP responses such as 404 or 500.

We need to check `response.ok`.

If it is false, we should handle the error ourselves.

### POST request using Fetch

When creating a new ticket, we need to send data to the backend.

```tsx
const createTicket = async () => {
    const response = await fetch(
        "http://localhost:3000/api/tickets",
        {
            method: "POST",

            headers: {
                "Content-Type": "application/json"
            },

            body: JSON.stringify({
                title: "Login issue",
                description: "Unable to login"
            })
        }
    );

    if (!response.ok) {
        throw new Error("Ticket creation failed");
    }

    return await response.json();
};
```

### Understanding the three important properties

- `method`: Specifies the HTTP method, such as GET, POST, PUT or DELETE.
- `headers`: Provides information about the request, such as the content type.
- `body`: Contains the data being sent to the backend.

`JSON.stringify()` converts a JavaScript object into a JSON string.

## B. Axios

Axios is a popular HTTP client library used to communicate with APIs.

Unlike Fetch, Axios is not built into JavaScript. We need to install it.

```bash
npm install axios
```

### Fetch vs Axios

| Feature | Fetch | Axios |
|---|---|---|
| Installation | Built-in | Requires installation |
| JSON parsing | Manual using .json() | Automatic for JSON responses |
| HTTP 4xx/5xx | Check response.ok | Rejects by default |
| Request interceptors | Not built in | Supported |
| Response interceptors | Not built in | Supported |
| Request cancellation | AbortController | AbortController support |

Both are useful.

Axios is often convenient for applications that make many API requests.

## C. Creating an Axios Instance

Instead of repeatedly writing the backend URL in every API call, we can create a common Axios instance.

Create a file:

`src/lib/api.ts`

Example:

```tsx
import axios from "axios";

const api = axios.create({
    baseURL: "http://localhost:3000/api",
    headers: {
        "Content-Type": "application/json"
    }
});

export default api;
```

Now we can use the same instance throughout our application.

Example:

```tsx
const response = await api.get("/tickets");
```

Instead of writing the complete backend URL every time, we only need to specify the endpoint.

## D. Axios Interceptors

Interceptors allow us to run common logic before a request is sent or after a response is received.

There are two types:

**1. Request Interceptor**

It runs before an HTTP request is sent.

This is useful for authentication.

Remember that we learned about JWT?

After login, the backend provides a token. Protected API requests need to send that token.

We can use a request interceptor to attach the authorization header to outgoing requests.

Example:

```tsx
api.interceptors.request.use((config) => {
    const token = localStorage.getItem("token");

    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }

    return config;
});
```

**2. Response Interceptor**

It runs after the backend sends a response.

It can handle common responses centrally.

For example, if the backend returns `401 Unauthorized`, a response interceptor can trigger the application's session-expiration or reauthentication flow.

**Security note:** Storing JWTs in localStorage is not automatically secure. If an attacker can execute JavaScript in the application through an XSS vulnerability, the token may be stolen. Token storage should be chosen carefully. HttpOnly, Secure and appropriate SameSite cookies are another common approach.

# 11. React Query (TanStack Query)

TanStack Query, previously known as React Query, is a library used to manage server state in React applications.

Server state means data that comes from the backend, such as:

- Tickets.
- User information.
- Notifications.
- Employee details.

It helps us manage API requests, loading states, errors and caching.

Install it:

```bash
npm install @tanstack/react-query
```

### Setting up QueryClientProvider

Before using React Query, we need to configure a Query Client and wrap our application with `QueryClientProvider`.

Example in `main.tsx`:

```tsx
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

const queryClient = new QueryClient();

ReactDOM.createRoot(
    document.getElementById("root")!
).render(
    <QueryClientProvider client={queryClient}>
        <App />
    </QueryClientProvider>
);
```

This makes the Query Client available to the components inside App.

## A. useQuery – Fetching Data

`useQuery()` is used to retrieve data from an API.

Suppose we want to display all tickets in our HelpDesk dashboard.

```tsx
import { useQuery } from "@tanstack/react-query";
import api from "../lib/api";

const fetchTickets = async () => {
    const response = await api.get("/tickets");

    return response.data;
};

function TicketList() {

    const {
        data,
        isLoading,
        isError,
        error
    } = useQuery({
        queryKey: ["tickets"],
        queryFn: fetchTickets
    });

    if (isLoading) {
        return <p>Loading tickets...</p>;
    }

    if (isError) {
        return <p>{error.message}</p>;
    }

    return (
        <div>
            {data.map((ticket: any) => (
                <p key={ticket._id}>
                    {ticket.title}
                </p>
            ))}
        </div>
    );
}

export default TicketList;
```

### Understanding the important parts

**1. queryKey**

```tsx
queryKey: ["tickets"]
```

It uniquely identifies the query in the cache.

Think of it as the name or identifier of the cached data.

**2. queryFn**

```tsx
queryFn: fetchTickets
```

This is the function that actually fetches the data.

**3. data**

Contains the successful response returned by `queryFn`.

**4. isLoading**

Indicates that the query is loading for the first time without available data.

**5. isError**

Indicates that the query failed.

**6. error**

Contains information about the error.

### Understanding Query Keys

Query keys are very important because React Query uses them to identify and store different sets of data.

Suppose we want to retrieve tickets based on their status.

For open tickets:

```tsx
useQuery({
    queryKey: ["tickets", "Open"],
    queryFn: () => fetchTicketsByStatus("Open")
});
```

For resolved tickets:

```tsx
useQuery({
    queryKey: ["tickets", "Resolved"],
    queryFn: () => fetchTicketsByStatus("Resolved")
});
```

These are separate cache entries because their query keys are different.

A query key should include the variables that affect the data being fetched.

For example:

```tsx
queryKey: ["tickets", status, page]
```

This allows React Query to distinguish between tickets with different statuses and pages.

## B. useMutation – Creating and Updating Data

`useMutation()` is used when we want to change data on the backend.

Examples:

- Creating a ticket.
- Updating ticket details.
- Changing ticket status.
- Deleting a ticket.

These operations are called mutations.

### Example: Creating a Ticket

```tsx
import { useMutation } from "@tanstack/react-query";
import api from "../lib/api";

function CreateTicket() {

    const mutation = useMutation({
        mutationFn: async (ticketData: {
            title: string;
            description: string;
        }) => {
            const response = await api.post(
                "/tickets",
                ticketData
            );

            return response.data;
        }
    });

    const handleCreate = () => {
        mutation.mutate({
            title: "Login issue",
            description: "Unable to login"
        });
    };

    return (
        <div>
            <button
                onClick={handleCreate}
                disabled={mutation.isPending}
            >
                Create Ticket
            </button>

            {mutation.isPending && <p>Creating...</p>}

            {mutation.isSuccess && <p>Ticket created!</p>}

            {mutation.isError && <p>Creation failed!</p>}
        </div>
    );
}

export default CreateTicket;
```

### Understanding the properties

| Property | Meaning |
|---|---|
| mutationFn | Function that performs the API operation |
| mutate() | Starts the mutation |
| isPending | Mutation is currently running |
| isSuccess | Mutation completed successfully |
| isError | Mutation failed |
| error | Contains error details |

**Remember the difference:**

- `useQuery()` → Retrieves data.
- `useMutation()` → Creates, updates or deletes data.

## C. Cache Invalidation

Cache invalidation is one of the most important React Query concepts.

Let's understand it with an example.

Suppose:

1. An employee opens the ticket dashboard.
2. React Query fetches 10 tickets.
3. The tickets are stored in the cache.
4. The employee creates a new ticket.
5. The backend successfully saves the new ticket.

But there is a problem.

The cached ticket list still contains only the previous 10 tickets.

How do we refresh it?

We use **cache invalidation**.

Cache invalidation tells React Query that particular cached data is now stale and should be refreshed when appropriate.

### Example

```tsx
import {
    useMutation,
    useQueryClient
} from "@tanstack/react-query";

import api from "../lib/api";

function CreateTicket() {

    const queryClient = useQueryClient();

    const mutation = useMutation({
        mutationFn: async (ticketData: {
            title: string;
            description: string;
        }) => {
            const response = await api.post(
                "/tickets",
                ticketData
            );

            return response.data;
        },

        onSuccess: () => {
            queryClient.invalidateQueries({
                queryKey: ["tickets"]
            });
        }
    });

    return (
        <button
            onClick={() => mutation.mutate({
                title: "Login issue",
                description: "Unable to login"
            })}
        >
            Create Ticket
        </button>
    );
}
```

### Understanding the new parts

**1. useQueryClient()**

```tsx
const queryClient = useQueryClient();
```

It gives us access to the existing Query Client.

**2. invalidateQueries()**

```tsx
onSuccess: () => {
    queryClient.invalidateQueries({
        queryKey: ["tickets"]
    });
}
```

After successfully creating a ticket:

- React Query marks matching ticket queries as stale.
- Active queries are normally refetched in the background.
- The dashboard receives updated ticket data.

**Important:** Invalidation does not directly delete cached data. It marks the data as stale so that it can be refreshed.

### Query vs Mutation vs Invalidation

| Concept | Purpose |
|---|---|
| useQuery | Fetches data |
| useMutation | Changes server data |
| invalidateQueries | Marks cached data as stale and triggers appropriate refetching |

## D. staleTime and gcTime

These are two important React Query concepts related to caching.

### 1. staleTime

`staleTime` controls how long fetched data is considered fresh.

Example:

```tsx
useQuery({
    queryKey: ["tickets"],
    queryFn: fetchTickets,
    staleTime: 60000
});
```

Here, the data is considered fresh for 60 seconds.

During this time, React Query does not normally refetch it just because of events such as component mounting or window focus.

### 2. gcTime

`gcTime` controls how long inactive cached data stays in memory before it can be garbage-collected.

Example:

```tsx
useQuery({
    queryKey: ["tickets"],
    queryFn: fetchTickets,
    gcTime: 300000
});
```

Here, inactive cached data is kept for five minutes before it can be removed.

### Remember the difference

- `staleTime` → Controls how long data stays fresh.
- `gcTime` → Controls how long inactive cached data is retained.

In TanStack Query v5, `gcTime` is the name used instead of the older v4 `cacheTime`.

# 12. Common React Mistakes to Avoid

1. Forgetting to use `key` while rendering lists using `map()`.
2. Using array indexes as keys when the list can change.
3. Updating state directly instead of using the state setter.
4. Calling Hooks inside conditions, loops or nested functions.
5. Forgetting to clean up timers and event listeners.
6. Creating unnecessary state for values that can be calculated directly.
7. Forgetting to include required dependencies in `useEffect()`.
8. Using Context API for every small piece of state when local state would be sufficient.
9. Forgetting to register inputs when using React Hook Form.
10. Depending only on frontend validation without backend validation.
11. Forgetting to check `response.ok` when using Fetch.
12. Forgetting `JSON.stringify()` when sending a JSON body through Fetch.
13. Forgetting to configure `QueryClientProvider`.
14. Using `useQuery()` for creating or deleting records instead of `useMutation()`.
15. Using the same query key for different data.
16. Forgetting cache invalidation after successful mutations.
17. Exposing private backend secrets through Vite environment variables.

**Important security point:** Vite environment variables prefixed with `VITE_` are exposed to frontend code. Never store private backend secrets, database passwords or API secret keys in them.

---

# Quick Revision – Important React Concepts

| Concept | Main Purpose |
|---|---|
| JSX | Write HTML-like UI syntax in JavaScript |
| Components | Divide UI into reusable parts |
| Props | Pass data from parent to child |
| useState | Manage changing data |
| Lifting State Up | Share state through a common parent |
| useEffect | Handle side effects |
| Cleanup | Remove or stop side effects |
| map() | Display lists dynamically |
| Keys | Identify list elements |
| Conditional Rendering | Display UI based on conditions |
| Context API | Share data without prop drilling |
| Custom Hooks | Reuse stateful logic |
| React Router | Manage navigation |
| useNavigate | Navigate through code |
| useParams | Read dynamic URL values |
| Outlet | Display nested child routes |
| Protected Routes | Restrict access to certain pages |
| React Hook Form | Manage forms |
| Zod | Validate data using schemas |
| Fetch / Axios | Communicate with backend APIs |
| Interceptors | Handle common request and response logic |
| useQuery | Fetch and cache server data |
| useMutation | Create, update or delete server data |
| invalidateQueries | Mark cached data as stale |
| staleTime | Control data freshness |
| gcTime | Control inactive cache retention |
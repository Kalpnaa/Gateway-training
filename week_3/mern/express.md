# Express.js

Express.js is a lightweight web framework built on top of Node.js that makes it easier to build web servers and REST APIs.

- **Node.js:** Allows JavaScript to run outside the browser.
- **Express.js:** Provides tools to handle HTTP requests, responses, routes, and middleware.

## 1. Express.js Architecture

```text
Frontend (React / Angular)
        |
        | Sends HTTP request
        v
Express.js Server
        |
        | Receives and handles requests
        v
Routes → Controllers → Services
        |
        | Processes application logic
        v
Database (MongoDB)
        |
        | Stores and retrieves data
```

### Installation and Setup

```bash
npm install express

npm install -D typescript tsx @types/node @types/express

npx tsc --init
```

## 2. Application Structure

A typical Express.js application can be organized into the following folders and files:

```text
src/
│
├── routes/
├── controllers/
├── services/
├── database/
├── app.ts
└── server.ts
```

### A. Routes

Routes define the URL endpoints and HTTP methods through which clients communicate with our backend.

**Common API endpoints:**

| HTTP Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/tickets` | Get all tickets |
| GET | `/api/tickets/:id` | Get one ticket |
| POST | `/api/tickets` | Create a ticket |
| PUT | `/api/tickets/:id` | Update a ticket |
| DELETE | `/api/tickets/:id` | Delete a ticket |

**Express Router**

`express.Router()` allows us to create separate route handlers and organize API endpoints.

```typescript
import { Router } from "express";

const router = Router();

router.get("/", (req, res) => {
    res.json({ message: "Get all tickets" });
});

export default router;
```

### B. Controllers

Controllers handle incoming HTTP requests and outgoing HTTP responses.

Their responsibilities include:

- Reading data from `req.params`, `req.query`, and `req.body`.
- Calling the appropriate service.
- Returning the appropriate HTTP status code and response.

### C. Services

Services contain the actual business logic of the application.

They perform operations such as processing data, validating business rules, and interacting with the database.

### D. App

Our `app.ts` file brings the different parts of the application together.

It:

- Creates the Express application.
- Registers middleware.
- Registers routes.
- Configures other application-level settings.

### E. Server

Our `server.ts` file starts the application and listens for incoming HTTP requests.

### Responsibilities of Each Component

| Component | Main Responsibility |
|---|---|
| App | Configure Express application |
| Server | Start HTTP server |
| Router | Define API endpoints |
| Controller | Handle HTTP requests and responses |
| Service | Execute business logic |

## 3. Requests and Responses

- **Request:** Data sent by the client to the backend.
- **Response:** Data sent by the backend to the client.

### A. Request Parameters (`req.params`)

- Used to capture dynamic values directly from the URL path.
- Route parameters are strings by default, even if they look like numbers.
- Commonly used to identify a specific resource when fetching, updating, or deleting it.

Example:

```typescript
router.get("/tickets/:id", (req, res) => {
    const id = req.params.id;
    res.json({ ticketId: id });
});
```

URL:

```text
GET /tickets/101
```

Here, `101` is the route parameter.

### B. Query Parameters (`req.query`)

Query parameters are used to pass optional information through the URL.

They are commonly used for:

- Filtering
- Sorting
- Searching
- Pagination

We can access these values using:

```typescript
const status = req.query.status;
const priority = req.query.priority;
```

Example:

```text
GET /tickets?status=Open&priority=High
```

### C. Request Body (`req.body`)

- Contains data sent by the client to the backend.
- Commonly used with POST, PUT, and PATCH requests.
- Used when creating or updating resources.

Example:

```json
{
    "title": "Laptop not working",
    "priority": "High"
}
```

### Difference Between Params, Query, and Body

| Feature | `req.params` | `req.query` | `req.body` |
|---|---|---|---|
| Location | URL path | URL after `?` | Request body |
| Purpose | Identify resource | Filter or search | Send data |
| Example | `/tickets/101` | `?status=Open` | `{ "title": "Laptop" }` |
| Common methods | GET, PUT, DELETE | GET | POST, PUT, PATCH |

## 4. HTTP Status Codes

HTTP status codes indicate the result of an HTTP request.

| Status Code | Meaning | Example |
|---|---|---|
| 200 | OK | Tickets fetched successfully |
| 201 | Created | New ticket created |
| 204 | No Content | Ticket deleted successfully |
| 400 | Bad Request | Required fields missing |
| 401 | Unauthorized | User not authenticated |
| 403 | Forbidden | User doesn't have permission |
| 404 | Not Found | Ticket doesn't exist |
| 409 | Conflict | Duplicate ticket number |
| 500 | Internal Server Error | Unexpected backend error |

### Sending Responses

Express provides different methods to send responses:

```typescript
res.json({ message: "Success" });

res.status(200);

res.send("Response message");

res.end();
```

| Method / Property | Purpose |
|---|---|
| `req.params` | Access route parameters |
| `req.query` | Access query parameters |
| `req.body` | Access request body |
| `res.status()` | Set HTTP status code |
| `res.json()` | Send JSON response |
| `res.send()` | Send response content |
| `res.end()` | End the response |

## 5. Middleware

Middleware is a function that executes during the request-response cycle.

It has access to three important things:

- `req` – Incoming request.
- `res` – Outgoing response.
- `next` – Function that passes control to the next middleware or route handler.

### What Can Middleware Do?

1. Execute some code.
2. Read or modify the request and response.
3. End the request-response cycle.
4. Call `next()` to pass control forward.

### Types of Middleware

**A. Built-in Middleware**

Provided by Express itself.

Examples:

- `express.json()` – Parses incoming JSON request bodies.
- `express.urlencoded()` – Parses URL-encoded request bodies.
- `express.static()` – Serves static files such as HTML, CSS, and images.

**B. Third-party Middleware**

Developed by external developers and installed through npm.

Examples:

1. **Morgan:** HTTP request logging.
2. **CORS:** Allows a server to specify which other origins can access its resources.
3. **Helmet:** Sets various HTTP response headers to help improve application security.

**C. Custom Middleware**

We can create our own middleware to implement application-specific functionality.

Example:

```typescript
const logger = (req, res, next) => {
    console.log(`${req.method} ${req.url}`);
    next();
};
```

### Middleware Execution Order

Middleware functions are executed in the order in which they are registered.

### Ways to Register Middleware

| Type | Method | Purpose |
|---|---|---|
| Application-level | `app.use()` | Applies middleware to the application |
| Router-level | `router.use()` | Applies middleware to a particular router |
| Route-specific | `router.post("/", middleware, handler)` | Applies middleware to a specific route |

## 6. Error Handling

Error handling is the process of identifying errors, managing them, and sending appropriate responses to the client without crashing the application.

### Types of Errors in Express

| Error Type | Example |
|---|---|
| Operational Errors | Ticket not found, invalid input |
| Programming Errors | Accessing an undefined property |
| External Errors | Database connection failure |

- **Operational errors:** Expected failures that an application should handle gracefully.
- **Programming errors:** Usually indicate a bug that developers need to fix.
- **External errors:** Occur when a dependency or external service fails.

### A. Synchronous Error Handling

Synchronous operations execute immediately without waiting for a Promise.

Express automatically catches errors thrown by synchronous route handlers and passes them to error-handling middleware.

However, we should use centralized error handling instead of handling every error separately.

### B. Error-Handling Middleware

Error-handling middleware is used to handle errors centrally.

It has four parameters:

```typescript
(err, req, res, next)
```

Example:

```typescript
app.use((err, req, res, next) => {
    console.error(err);

    res.status(500).json({
        message: "Internal Server Error"
    });
});
```

**Important:** Error-handling middleware must have four parameters, including `next`.

### C. Handling Asynchronous Errors

Asynchronous error handling is particularly important when working with:

- Databases
- External APIs
- Other asynchronous operations

We can use `try-catch` to handle errors from awaited operations.

```typescript
router.get("/tickets", async (req, res, next) => {
    try {
        const tickets = await getTickets();
        res.json(tickets);
    } catch (error) {
        next(error);
    }
});
```

### Important Error-Handling Concepts

| Concept | Meaning |
|---|---|
| `throw new Error()` | Creates and throws an error |
| `next(error)` | Forwards an error to error-handling middleware |
| `try-catch` | Handles errors from awaited operations |
| Error Middleware | Centralized error processing |
| AppError | Custom error class used to represent application-specific errors |

### Common Error Status Codes

| Status Code | Meaning |
|---|---|
| 400 | Bad Request |
| 404 | Resource or route not found |
| 500 | Internal Server Error |

## 7. CORS (Cross-Origin Resource Sharing)

CORS is a browser security mechanism that allows a server to specify which origins can access its resources.

### Why Do We Need CORS?

Suppose we have:

- React frontend running on `localhost:5173`.
- Express backend running on `localhost:3000`.

Both applications run on localhost, but they use different ports.

Therefore, they have different origins.

When React tries to access the Express API, the browser checks whether the backend permits that origin.

If the server doesn't allow it, the browser blocks frontend JavaScript from accessing the response.

### What is an Origin?

An origin consists of three parts:

1. Protocol
2. Domain / Hostname
3. Port

Example:

```text
http://localhost:5173
```

Here:

- Protocol: `http`
- Hostname: `localhost`
- Port: `5173`

### What is Same-Origin Policy?

The Same-Origin Policy is a browser security rule that restricts how a webpage can interact with resources from another origin.

Two URLs have the same origin only when their protocol, hostname, and port are the same.

### How Does CORS Work?

```text
React Frontend
localhost:5173
       |
       | HTTP request with Origin header
       v
Express Backend
localhost:3000
       |
       v
Checks CORS configuration
       |
       v
Returns CORS response headers
       |
       v
Browser checks permission
       |
       ├── Allowed
       |      |
       |      v
       |   Frontend can read the response
       |
       └── Blocked
              |
              v
          Frontend cannot read the response
```

### Important CORS Headers

| Header | Purpose |
|---|---|
| `Access-Control-Allow-Origin` | Specifies allowed origin |
| `Access-Control-Allow-Methods` | Specifies allowed HTTP methods |
| `Access-Control-Allow-Headers` | Specifies allowed request headers |
| `Access-Control-Allow-Credentials` | Allows credentialed cross-origin requests |

### What is a Preflight Request?

This is an important interview question.

Not every cross-origin request needs a preflight request.

For certain requests, the browser first sends an HTTP `OPTIONS` request to check whether the actual request is permitted.

This is called a **preflight request**.

For example, suppose React wants to send a POST request with:

- `Content-Type: application/json`
- `Authorization: Bearer <token>`

The browser may send an OPTIONS request first to check whether the server allows the requested method and headers.

If the server permits the request, the browser sends the actual POST request.

### Installing CORS

```bash
npm install cors

npm install -D @types/cors
```

### CORS Configuration Options

We can configure CORS to allow:

1. A specific origin.
2. Multiple origins.
3. Specific HTTP methods.
4. Specific request headers.
5. Credentials such as cookies and authorization-related credentials.

Example:

```typescript
import cors from "cors";

app.use(cors({
    origin: "http://localhost:5173",
    methods: ["GET", "POST", "PUT", "DELETE"],
    allowedHeaders: ["Content-Type", "Authorization"],
    credentials: true
}));
```

**Important:** When `credentials: true` is enabled, the server must specify an explicit allowed origin. It cannot use `*` as the allowed origin.
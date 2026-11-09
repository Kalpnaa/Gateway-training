# Topic 1: How the Web Works

## 1. Client and Server

[基本網路架構─輸入網址後發生了什麼事? | Lily 程式學習筆記 | Programming Learning Notes - 點部落](https://images.openai.com/static-rsc-4/IdvfmtwxMwMLNaISfW1xFYHegINeHaX5BmdaxTZNK1E1VZtTqgmCXoJcm3_KD5NcFeVzfei5Ud_AkXaNHmu6PtDyLy80DRxsEwvTuREbYpAJ0RyAZxj200u3RszzJrFvVK0VKONlr52tWmbyC2XCuJAi00ERIC6qjrrxKHxg7Ew?purpose=inline)

[dotblogs.com.tw](https://dotblogs.com.tw/Lily_Software_Engineer/2023/11/28/after-enter-url-in-browser?utm_source=chatgpt.com)

The web works using a client-server architecture.

- Client: The device or application requesting information. Example: Chrome browser.
- Server: A computer that receives requests, processes them, and sends responses.
- Browser: Software used to access websites, such as Chrome, Firefox or Edge.

### How does it work?

Suppose you open `https://www.amazon.com`.

1. You enter the URL in your browser.
2. Browser identifies the domain name.
3. DNS finds the IP address associated with that domain.
4. Browser sends an HTTP request to the server.
5. Server processes the request.
6. Server sends an HTTP response.
7. Browser displays the webpage.

### Important terminology

| Term       | Meaning                                             |
| ---------- | --------------------------------------------------- |
| URL        | Complete address of a resource                      |
| Domain     | Human-readable website name                         |
| DNS        | Converts domain names into IP addresses             |
| IP address | Numerical address identifying a device on a network |
| Browser    | Client software used to access websites             |
| Server     | Receives and processes client requests              |

Example:

`https://www.example.com/products?id=10`

- `https` → Protocol
- `www.example.com` → Domain/host
- `/products` → Path
- `id=10` → Query parameter

Remember: DNS is like a phonebook. It helps your browser find the server's IP address using its domain name.

## 2. HTTP (Hypertext Transfer Protocol)

HTTP is a communication protocol used between clients and servers.

It follows a request-response model.

[From Browser to Server: What Really Happens When You Type a URL | by Satyam Singh | Medium](https://images.openai.com/static-rsc-4/rrLAoQ4LKHWje3eLKV9Ox9vPlXDeHj_yls9Tfhd2xjsZX9JsHqV9qi_hjB6M7MpRoVGhqOtaEoMZdon11_k4CfP1z94jPW_XUT4uYjkljjghq64FGdgSaOgn_Pm1SnZ6cOta93YPtDwf2VF8Y0Ibk6uNzX9T8QorJfd9zJK0oW8?purpose=inline)

[medium.com](https://medium.com/%40thesamventure/from-browser-to-server-what-really-happens-when-you-type-a-url-93187c1e9454?utm_source=chatgpt.com)

### A. HTTP Methods

HTTP methods describe what action the client wants to perform.

| Method | Purpose            | Example                 |
| ------ | ------------------ | ----------------------- |
| GET    | Retrieve data      | Get student details     |
| POST   | Create a resource  | Add a student           |
| PUT    | Replace a resource | Replace student details |
| PATCH  | Partially update   | Update student email    |
| DELETE | Delete a resource  | Delete a student        |

Example API:

```
GET /students/10
POST /students
PUT /students/10
PATCH /students/10
DELETE /students/10
```

Important distinctions:

- GET: Read data.
- POST: Usually creates data.
- PUT: Replaces the complete resource representation.
- PATCH: Updates selected fields.
- DELETE: Removes a resource.

### B. HTTP Status Codes

Status codes tell the client what happened to its request.

| Category | Meaning      | Examples           |
| -------- | ------------ | ------------------ |
| 2xx      | Success      | 200, 201, 204      |
| 3xx      | Redirection  | 301, 302, 304      |
| 4xx      | Client error | 400, 401, 403, 404 |
| 5xx      | Server error | 500, 502, 503      |

Important codes to remember:

- 200 OK: Request successful.
- 201 Created: Resource successfully created.
- 204 No Content: Successful request, no response body.
- 301 Moved Permanently: Permanent redirection.
- 400 Bad Request: Invalid request.
- 401 Unauthorized: Authentication is required or has failed.
- 403 Forbidden: Server refuses access.
- 404 Not Found: Resource doesn't exist.
- 500 Internal Server Error: Something went wrong on the server.
- 503 Service Unavailable: Server temporarily unavailable.

Remember the difference:

- 401 = Authentication problem.
- 403 = You don't have permission.

### C. Headers and Request/Response Bodies

Headers: Provide additional information about a request or response.

Examples:

```
Content-Type: application/json
Authorization: Bearer token123
Accept: application/json
```

Request body: Data sent by the client to the server.

Example:

```
{
  "name": "Kalpana",
  "age": 21
}
```

Response body: Data returned by the server.

Example:

```
{
  "id": 101,
  "name": "Kalpana",
  "status": "success"
}
```

Important:

- Headers contain metadata.
- Body contains the actual data being sent or received.
- GET requests generally don't need a body.

## 3. REST (Representational State Transfer)

REST is an architectural style used to design web APIs.

REST APIs organize data around resources.

For example, consider a student management API.

| Operation        | HTTP method | Endpoint       |
| ---------------- | ----------- | -------------- |
| Get all students | GET         | `/students`    |
| Get one student  | GET         | `/students/10` |
| Create student   | POST        | `/students`    |
| Replace student  | PUT         | `/students/10` |
| Update student   | PATCH       | `/students/10` |
| Delete student   | DELETE      | `/students/10` |

### A. Resources and URLs

A resource represents an entity such as:

- Students
- Products
- Employees
- Orders

REST uses URLs to identify resources.

Prefer:

```
GET /students
```

Instead of:

```
GET /getStudents
```

### B. Statelessness

This is a very important REST concept.

Stateless means the server does not store client session state between requests as part of the REST interaction.

Every request must contain the information needed to process it.

For example:

Request 1:

```
GET /profile
Authorization: Bearer abc123
```

Request 2:

```
GET /orders
Authorization: Bearer abc123
```

The server doesn't rely on remembering the previous request to understand the next one.

### C. Idempotent Methods

An operation is idempotent when performing it multiple times has the same intended effect on the server as performing it once.

| Method | Idempotent?    |
| ------ | -------------- |
| GET    | Yes            |
| PUT    | Yes            |
| DELETE | Yes            |
| POST   | Generally no   |
| PATCH  | Not guaranteed |

Example:

Sending this request five times:

```
DELETE /students/10
```

The intended final state is the same: student 10 is absent.

Important exam point: DELETE can return different status codes across repeated requests, but it is still idempotent.

### D. Paging and Filtering

When an API has thousands of records, returning everything at once is inefficient.

We use pagination.

Example:

```
GET /students?page=2&limit=10
```

This requests page 2 with 10 records.

Filtering:

```
GET /students?department=computer
```

Sorting:

```
GET /students?sort=name&order=asc
```

These are query strings, which begin after `?` and use `&` to separate parameters.

## 4. JSON (JavaScript Object Notation)

JSON is a lightweight text format used to exchange data between applications.

### A. JSON Object

An object contains key-value pairs.

```
{
  "name": "Kalpana",
  "age": 21,
  "isStudent": true
}
```

### B. JSON Array

An array contains multiple values.

```
{
  "students": [
    {
      "id": 1,
      "name": "Amit"
    },
    {
      "id": 2,
      "name": "Riya"
    }
  ]
}
```

### C. JSON Rules

1. Keys must use double quotes.
2. Strings must use double quotes.
3. Numbers don't require quotes.
4. Boolean values are `true` and `false`.
5. Null is written as `null`.
6. No trailing commas.

Valid:

```
{
  "name": "Amit",
  "age": 20
}
```

Invalid:

```
{
  'name': 'Amit',
  'age': 20,
}
```

### D. Converting JSON to and from text

In JavaScript:

Object to JSON string:

```
const student = {
    name: "Kalpana",
    age: 21
};

const jsonText = JSON.stringify(student);

console.log(jsonText);
```

JSON string to JavaScript object:

```
const data = '{"name":"Kalpana","age":21}';

const studentObject = JSON.parse(data);

console.log(studentObject.name);
```

Remember:

| Method             | Purpose              |
| ------------------ | -------------------- |
| `JSON.stringify()` | Object → JSON string |
| `JSON.parse()`     | JSON string → Object |

## 5. Browser Developer Tools

Browser developer tools help developers inspect, debug and troubleshoot websites.

Open them using `F12` or `Ctrl + Shift + I` in Chrome.

[How to Use Chrome DevTools – Simple Strategies for Smarter Web Development](https://images.openai.com/static-rsc-4/k7UNdhjZs0RLLxQ115J3kYoCbW8hmHFnZv9kAviANcBT1fyw6H3XDR3DPsrTiEcZDNvi8TdOHhjTZVisQT9U-_FWmZ9kglumLw1_U1VSpNJjPsvBJXi8eFkFjuQu0-lXUSJSgRxr_hjkxi0iyV82kMjlaZeTMZtem0Em2JrDphY?purpose=inline)

[freecodecamp.org](https://www.freecodecamp.org/news/chrome-devtools/?utm_source=chatgpt.com)

### A. Elements Tab

Used to inspect and modify HTML and CSS.

You can:

- Inspect HTML elements.
- View CSS styles.
- Modify styles temporarily.
- Debug layout problems.

### B. Console Tab

Used to execute JavaScript and identify errors.

Example:

```
console.log("Hello World");
```

You can also see JavaScript errors and warnings here.

### C. Network Tab

Used to monitor network requests.

You can inspect:

- API requests.
- HTTP methods.
- Status codes.
- Request and response headers.
- Request and response bodies.
- Loading time.

Exam tip: If an API request returns 404, the Network tab helps you investigate the failed request.

## 6. Storage and Security Basics

### A. Cookies

Cookies are small pieces of data stored by the browser and associated with a website.

Common uses:

- Session management.
- Authentication.
- User preferences.
- Tracking.

Cookies can be sent automatically with matching HTTP requests, depending on their attributes.

Important cookie attributes:

- `HttpOnly`: Prevents JavaScript access to the cookie.
- `Secure`: Sends the cookie only over HTTPS.
- `SameSite`: Controls cross-site cookie sending.

### B. Local Storage

Local Storage stores key-value data in the browser.

Example:

```
localStorage.setItem("username", "Kalpana");

const name = localStorage.getItem("username");

localStorage.removeItem("username");
```

Important characteristics:

- Data persists even after closing the browser.
- Data is stored as strings.
- It is not automatically sent with HTTP requests.
- JavaScript can access it from the same origin.

### Cookies vs Local Storage

| Feature                      | Cookies              | Local Storage          |
| ---------------------------- | -------------------- | ---------------------- |
| Storage                      | Browser              | Browser                |
| Expiration                   | Configurable         | Persists until cleared |
| Automatically sent to server | Yes, when applicable | No                     |
| Storage capacity             | Smaller              | Larger                 |
| JavaScript access            | Depends on HttpOnly  | Yes                    |

### C. Same-Origin Policy (SOP)

A browser security mechanism that restricts how a webpage from one origin can access resources from another origin.

An origin consists of:

1. Protocol
2. Domain/hostname
3. Port

Example:

`https://example.com:443`

Changing any one of these creates a different origin.

### D. CORS (Cross-Origin Resource Sharing)

CORS is a mechanism that allows servers to specify which other origins can access their resources through browser requests.

Example:

Frontend:

`http://localhost:3000`

Backend:

`http://localhost:5000`

These are different origins because their ports differ.

The backend can allow the frontend using a response header:

```
Access-Control-Allow-Origin: http://localhost:3000
```

Remember:

- SOP restricts cross-origin access.
- CORS provides a controlled way to allow cross-origin access.
- CORS is enforced by browsers, not a replacement for server-side authorization.

# Quick revision sheet

| Concept        | Remember                                     |
| -------------- | -------------------------------------------- |
| DNS            | Domain → IP address                          |
| HTTP           | Request-response protocol                    |
| GET            | Retrieve                                     |
| POST           | Create                                       |
| PUT            | Replace                                      |
| PATCH          | Partial update                               |
| DELETE         | Delete                                       |
| 2xx            | Success                                      |
| 3xx            | Redirection                                  |
| 4xx            | Client error                                 |
| 5xx            | Server error                                 |
| REST           | Resource-based API architecture              |
| Stateless      | Each request carries required context        |
| Idempotent     | Repeating operation has same intended effect |
| JSON.stringify | Object → String                              |
| JSON.parse     | String → Object                              |
| Elements       | HTML/CSS                                     |
| Console        | JavaScript debugging                         |
| Network        | HTTP requests                                |
| Cookies        | Can be sent automatically                    |
| Local Storage  | Browser-side persistent storage              |
| SOP            | Restricts cross-origin access                |
| CORS           | Controlled cross-origin access               |


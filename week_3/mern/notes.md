## **1. Introduction to Node.js**

- Node.js is a JavaScript runtime environment used to execute JavaScript outside the browser.
- It is built on Google's **V8 JavaScript Engine**.
- It is used for server-side development.
- It is fast, lightweight and high-performance.
- We can create APIs using Node.js and integrate them with the frontend.
- It provides a unified language (JavaScript) for both frontend and backend development.

## **2. First Node.js Application**

Steps:

1. Create a folder.
2. Create a JavaScript file (`app.js`).
3. Write JavaScript code.
4. Execute the file using the terminal.

Command:

```
node app.js
```

### **REPL (Read-Eval-Print Loop)**

- REPL allows us to execute JavaScript code directly in the terminal.
- It is useful for testing small pieces of code.

Command:

```
node
```

## **3. Modules in Node.js**

Modules help us organize code into reusable files.

**Types of modules:**

1. Core Modules – Built-in modules provided by Node.js.
2. Third-Party Modules – Packages installed using npm.
3. Custom Modules – Modules created by developers.

### **Importing modules**

Node.js supports `require()` to import modules using CommonJS.

Example:

```
var fs = require('fs');
```

Here, `fs` is the File System core module.

### **Exporting modules**

We can export functionality from a custom module using:

```
module.exports = {
    // functions or variables
};
```

We can also use `exports` to export properties.

## **4. Core Modules and Global Objects**

### **Core Modules**

Core modules are built into Node.js and do not require separate installation.

Examples:

- `fs` – File System
- `http` – Create HTTP servers
- `path` – Work with file and directory paths
- `os` – Operating system information
- `url` – URL handling

### **Global Objects**

Global objects can be accessed directly without importing them.

Examples:

- `console`
- `process`
- `__dirname`
- `__filename`
- `Buffer`
- `setTimeout()`

### **JavaScript Console vs Node.js Console**

| Browser JavaScript      | Node.js                              |
| ----------------------- | ------------------------------------ |
| Runs inside the browser | Runs outside the browser             |
| Has access to DOM       | Does not have browser DOM            |
| Uses browser APIs       | Uses Node.js APIs                    |
| `window` is available   | `window` is not available by default |
| Browser environment     | Server-side environment              |

## **5. Creating a Server in Node.js**

- Node.js provides the `http` core module to create servers.
- A server receives client requests and sends responses.

Basic syntax:

```
const http = require('http');

const server = http.createServer((req, res) => {
    res.end("Hello from Node.js Server");
});

server.listen(3000, () => {
    console.log("Server running on port 3000");
});
```

**Important points:**

- `http.createServer()` creates an HTTP server.
- `req` represents the incoming request.
- `res` represents the response.
- `res.end()` ends the response and sends it to the client.
- `server.listen()` starts the server on the specified port.

## **6. External Packages and npm**

### **npm (Node Package Manager)**

- npm is used to install and manage third-party packages.
- Packages provide additional functionality to our applications.

Commands:

```
npm init -y
npm install package-name
npm i package-name
```

### **package.json**

- Contains project information and configuration.
- Stores dependencies and scripts.
- Maintains project metadata.

### **package-lock.json**

- Records the exact installed dependency versions and dependency tree.
- Helps maintain consistent installations across environments.

### **node_modules**

- Folder containing installed packages and their dependencies.
- Created automatically when packages are installed using npm.

### **Nodemon**

- Nodemon is a third-party development tool.
- Automatically restarts the Node.js server whenever we make changes to the code.

Installation:

```
npm install nodemon
```

Execution:

```
npx nodemon app.js
```

## **7. Process Object**

- `process` is a global object in Node.js.
- It provides information and control over the current Node.js process.

Example:

```
process.exit();
```

\- `process.exit()` terminates the running Node.js process.

## **8. Creating Simple APIs**

- An API allows communication between the frontend and backend.
- The client sends a request, and the server processes it and returns a response.

### **Request and Response**

**Request (**`req`**):**

Contains information sent by the client.

Important properties:

- `req.url` – Requested URL.
- `req.method` – HTTP request method (GET, POST, PUT, DELETE).
- `req.headers.host` – Host information from the request headers.

**Response (**`res`**):**

Used by the server to send data back to the client.

Common methods:

- `res.write()` – Writes response data.
- `res.end()` – Ends the response.

## **9. Command-Line Input**

- Node.js allows us to receive input through command-line arguments.
- `process.argv` stores the command-line arguments passed when executing a program.

Example:

```
console.log(process.argv);
```

## **10. Loading HTML Through a Node.js Server**

We can serve HTML content to the client in two ways:

**Method 1: Using an HTML file**

- Create a separate HTML file.
- Read the HTML file using the File System module.
- Send its content as a server response.

**Method 2: Writing HTML inside JavaScript**

- Directly write HTML content inside the Node.js file.
- Send the HTML using the response object.

## **11. Handling Form Data (POST Request)**

When a client submits a form, the data is sent to the server through an HTTP request.

**Important concepts:**

- Form data is received through the request (`req`) object.
- Data may arrive in multiple chunks rather than all at once.
- We collect these chunks and combine them to obtain the complete data.
- The Buffer class is used to handle incoming data.
- Query String module can be used to parse URL-encoded form data.

### **Handling data in chunks**

Important events:

- `data` – Triggered whenever a data chunk is received.
- `end` – Triggered when all data has been received.

Example:

```
let body = '';

req.on('data', (chunk) => {
    body += chunk;
});

req.on('end', () => {
    console.log(body);
});
```

### **Buffer Class**

- Buffer is used to handle binary data in Node.js.
- It helps collect and process incoming data chunks.

### **Query String Module**

- Used to parse and format URL query strings.
- Helps convert submitted form data into readable key-value pairs.

Example:

```
const querystring = require('querystring');

const data = querystring.parse(body);

console.log(data);
```


/* ==========================================
   NODE.JS CODE PRACTICE
   ========================================== */


// 1. FILE SYSTEM MODULE (fs)

// Import fs module and create a file
// var fs = require('fs');
// fs.writeFileSync("first.txt", "hello");


// 2. CORE MODULES (fs and os)

// Import core modules
// const fs = require('fs');
// const os = require('os');

// Create a file and write data
// fs.writeFileSync("dummy.txt", "dummy text");

// Get operating system platform
// console.log(os.platform());

// Get current process ID
// console.log(process.pid);


// 3. CREATING A BASIC HTTP SERVER

// Create server and send response to client
// const http = require('http');

// http.createServer((req, resp) => {
//     resp.write("this is gateway");
//     resp.end("heeloo");
// }).listen(4800);


// 4. EXTERNAL PACKAGE - COLORS

// Import external colors package
// const c = require('colors');

// Display colored text in terminal
// console.log(c.red("heelo"));
// console.log("hello");


// 5. SENDING HTML RESPONSE FROM SERVER

// Create server and send HTML content
// const http = require('http');

// http.createServer((req, resp) => {
//     resp.setHeader("content-type", "text/html");
//     resp.write("<h2>heelo</h2>");
//     resp.end("");
// }).listen(4800);


// 6. SENDING JSON DATA FROM SERVER

// Create sample user data
// const http = require('http');

// const userdata = [
//     {
//         name: "ram",
//         age: 20
//     },
//     {
//         name: "shyam",
//         age: 30
//     }
// ];

// Send JSON response to client
// http.createServer((req, res) => {
//     res.setHeader("Content-Type", "application/json");
//     res.write(JSON.stringify(userdata));
//     res.end();
// }).listen(5000);


// 7. HANDLING CLIENT REQUEST AND RESPONSE

// Access request URL and send response
// const http = require('http');

// http.createServer((req, res) => {
//     console.log(req.url);

//     res.write("client side response");
//     res.end("hello");
// }).listen(5000);


// Request properties:
// req.url           - Requested URL
// req.method        - HTTP request method
// req.headers.host  - Host information


// 8. COMMAND-LINE ARGUMENTS

// Get command-line arguments
// const arg = process.argv;

// Print the first user-provided argument
// console.log("-----------------", arg[2]);

// Run: node app.js hello
// arg[0] - Node executable path
// arg[1] - File path
// arg[2] - User-provided argument

# MongoDB

MongoDB is a **NoSQL, document-oriented database** used to store and manage application data.

## 1. MongoDB Basics

### A. Document
- A document is a single record stored in MongoDB.
- Documents are stored in **BSON (Binary JSON)** format, which is a binary representation of JSON that supports additional data types.

### B. Collection
- A collection is a group of related documents.
- It is similar to a table in a relational database.

### MongoDB Structure

Database → Collection → Documents

## 2. Setting Up MongoDB

There are two common ways to use MongoDB:

**Option A: MongoDB Community Server**
- Install MongoDB locally.
- Use its shell, `mongosh`, to interact with the database.

**Option B: MongoDB Atlas**
- A cloud-based MongoDB database service.
- Allows us to create and manage databases without installing MongoDB locally.

### What is mongosh?

`mongosh` is the MongoDB Shell. It allows us to interact directly with a MongoDB database using commands.

---

# 3. MongoDB CRUD Operations

CRUD stands for:
- **Create** – Insert documents.
- **Read** – Retrieve documents.
- **Update** – Modify documents.
- **Delete** – Remove documents.

These are the four basic operations used to manage database records.

Let's perform each operation using `mongosh`.

### A. Create – Insert Documents

First, select our database:

```javascript
use helpdesk
```

**Insert a single ticket:**

```javascript
db.tickets.insertOne({
    ticketNumber: 1001,
    title: "Laptop not working",
    description: "Laptop is not starting",
    status: "Open",
    priority: "High"
})
```

- `insertOne()` inserts one document into the collection.

**Insert multiple tickets:**

```javascript
db.tickets.insertMany([
    {
        ticketNumber: 1002,
        title: "Internet issue",
        description: "Internet disconnected frequently",
        status: "Open",
        priority: "Medium"
    },
    {
        ticketNumber: 1003,
        title: "Software installation",
        description: "Need VS Code installation",
        status: "Closed",
        priority: "Low"
    }
])
```

- `insertMany()` inserts multiple documents.

**Note:** MongoDB automatically generates an `_id` field if we don't provide one.

### B. Read – Find Documents

**Get all tickets:**

```javascript
db.tickets.find()
```

**Get one ticket:**

```javascript
db.tickets.findOne({
    ticketNumber: 1001
})
```

**Find tickets with Open status:**

```javascript
db.tickets.find({
    status: "Open"
})
```

**Find tickets with High priority:**

```javascript
db.tickets.find({
    priority: "High"
})
```

**Find documents using multiple conditions:**

```javascript
db.tickets.find({
    status: "Open",
    priority: "High"
})
```

By default, multiple conditions in the same query are combined using **AND**.

### C. Update – Modify Documents

**Update one ticket:**

```javascript
db.tickets.updateOne(
    { ticketNumber: 1001 },
    {
        $set: {
            status: "In Progress"
        }
    }
)
```

Here:
- `updateOne()` updates the first matching document.
- `$set` changes the specified fields without replacing the entire document.

**Update multiple tickets:**

```javascript
db.tickets.updateMany(
    { status: "Open" },
    {
        $set: {
            priority: "Medium"
        }
    }
)
```

### D. Delete – Remove Documents

**Delete one ticket:**

```javascript
db.tickets.deleteOne({
    ticketNumber: 1003
})
```

**Delete multiple tickets:**

```javascript
db.tickets.deleteMany({
    status: "Closed"
})
```

**Note:** Be careful with `deleteMany()`. It deletes every document matching the specified condition.

### CRUD Summary

| Operation | MongoDB Method |
|---|---|
| Create one | `insertOne()` |
| Create many | `insertMany()` |
| Read all | `find()` |
| Read one | `findOne()` |
| Update one | `updateOne()` |
| Update many | `updateMany()` |
| Delete one | `deleteOne()` |
| Delete many | `deleteMany()` |

---

# 4. MongoDB Query Operators

Query operators allow us to perform more advanced filtering on documents.

### A. Comparison Operators

| Operator | Meaning |
|---|---|
| `$eq` | Equal |
| `$ne` | Not equal |
| `$gt` | Greater than |
| `$gte` | Greater than or equal |
| `$lt` | Less than |
| `$lte` | Less than or equal |
| `$in` | Matches any value in an array |
| `$nin` | Does not match values in an array |

**Example:**

Find tickets with High or Medium priority:

```javascript
db.tickets.find({
    priority: { $in: ["High", "Medium"] }
})
```

### B. Logical Operators

| Operator | Meaning |
|---|---|
| `$and` | All conditions must match |
| `$or` | At least one condition must match |
| `$not` | Negates a condition |
| `$nor` | None of the conditions should match |

**Example – OR condition:**

```javascript
db.tickets.find({
    $or: [
        { status: "Open" },
        { priority: "High" }
    ]
})
```

This returns tickets that have either Open status or High priority.

### C. Sorting and Limiting

**Sort tickets by ticket number:**

```javascript
db.tickets.find().sort({
    ticketNumber: 1
})
```

- `1` means ascending order.
- `-1` means descending order.

**Limit the number of results:**

```javascript
db.tickets.find().limit(5)
```

This returns a maximum of five documents.

---

# 5. Indexes in MongoDB

An index helps MongoDB find documents faster.

Without an index, MongoDB may need to scan many documents to find the required record.

### Creating an Index

```javascript
db.tickets.createIndex({
    ticketNumber: 1
})
```

This creates an ascending index on `ticketNumber`.

### Unique Index

Suppose every ticket must have a unique ticket number.

We can create:

```javascript
db.tickets.createIndex(
    { ticketNumber: 1 },
    { unique: true }
)
```

Now MongoDB prevents duplicate ticket numbers in that collection.

### Viewing Indexes

```javascript
db.tickets.getIndexes()
```

### Deleting an Index

```javascript
db.tickets.dropIndex("ticketNumber_1")
```

**Note:** Indexes improve read performance but require additional storage and can slow down write operations because indexes also need to be maintained.

---

# 6. Data Modeling in MongoDB

Data modeling defines how related data is organized and stored in MongoDB.

There are two common approaches:

### A. Embedding

Embedding means storing related information inside the same document.

**Example:**

```javascript
{
    ticketNumber: 1001,
    title: "Laptop not working",
    status: "Open",
    employee: {
        name: "Rahul",
        email: "rahul@example.com"
    }
}
```

Here, employee information is embedded inside the ticket document.

### B. Referencing

Referencing means storing the ID of another document instead of embedding all its information.

**Example – Ticket document:**

```javascript
{
    ticketNumber: 1001,
    title: "Laptop not working",
    status: "Open",
    employeeId: "EMP101"
}
```

**Employee document:**

```javascript
{
    _id: "EMP101",
    name: "Rahul",
    email: "rahul@example.com"
}
```

Here, the ticket stores the employee's ID to refer to the employee document.

### One-to-Many Relationships

A one-to-many relationship means one document is associated with multiple other documents.

In MongoDB, we can implement this using references.

**Employee:**

```javascript
{
    _id: "EMP101",
    name: "Rahul"
}
```

**Tickets:**

```javascript
{
    ticketNumber: 1001,
    title: "Laptop issue",
    employeeId: "EMP101"
}
```

```javascript
{
    ticketNumber: 1002,
    title: "Internet issue",
    employeeId: "EMP101"
}
```

Both tickets refer to the same employee.

---

# 7. Mongoose

MongoDB stores data in documents and collections. But when working with Node.js and TypeScript, directly writing MongoDB queries can become repetitive.

**Mongoose is an ODM (Object Data Modeling) library for MongoDB and Node.js.**

It provides schemas, models, validation and methods to interact with MongoDB.

### Installing Mongoose

```bash
npm install mongoose dotenv
```

## A. Schema and Model

### Schema

A schema defines the structure, data types and validation rules of documents in a collection.

**Common Schema Properties:**

| Property | Meaning |
|---|---|
| `type` | Defines the data type |
| `required` | Field must be provided |
| `default` | Value used when none is provided |
| `enum` | Restricts allowed values |
| `trim` | Removes extra whitespace |
| `unique` | Creates a unique index |
| `timestamps` | Automatically adds `createdAt` and `updatedAt` |
| `ref` | References another collection |

**Example – Ticket Schema:**

```typescript
import mongoose, { Schema } from "mongoose";

const ticketSchema = new Schema(
    {
        ticketNumber: {
            type: Number,
            required: true,
            unique: true
        },

        title: {
            type: String,
            required: true,
            trim: true
        },

        description: {
            type: String,
            required: true
        },

        status: {
            type: String,
            enum: ["Open", "In Progress", "Closed"],
            default: "Open"
        },

        priority: {
            type: String,
            enum: ["Low", "Medium", "High"],
            default: "Medium"
        },

        employee: {
            type: Schema.Types.ObjectId,
            ref: "Employee",
            required: true
        }
    },
    {
        timestamps: true
    }
);

const Ticket = mongoose.model("Ticket", ticketSchema);

export default Ticket;
```

### Model

A model is created from a schema and provides methods to interact with the MongoDB collection.

```typescript
const Ticket = mongoose.model("Ticket", ticketSchema);
```

Common model methods:

```typescript
Ticket.create()
Ticket.find()
Ticket.findById()
Ticket.findByIdAndUpdate()
Ticket.findByIdAndDelete()
```

**Remember:**
- Schema defines the structure and validation rules.
- Model provides methods to perform database operations.

## B. Data Modeling and Relationships

We can establish relationships between different models using embedding or referencing.

For example:

One employee can have multiple tickets.

This represents a **one-to-many relationship** between Employee and Ticket models.

---

# 8. CRUD Operations Using Mongoose

CRUD means Create, Read, Update and Delete.

### CRUD Summary

| Operation | Mongoose Method |
|---|---|
| Create | `Model.create()` |
| Read all | `Model.find()` |
| Read one | `Model.findById()` |
| Update | `Model.findByIdAndUpdate()` |
| Delete | `Model.findByIdAndDelete()` |

### A. Create a Ticket

```typescript
const ticket = await Ticket.create({
    ticketNumber: 1001,
    title: "Laptop issue",
    description: "Laptop is not starting",
    employee: employeeId
});
```

### B. Read All Tickets

```typescript
const tickets = await Ticket.find();
```

### C. Read One Ticket

```typescript
const ticket = await Ticket.findById(ticketId);
```

### D. Update a Ticket

```typescript
const ticket = await Ticket.findByIdAndUpdate(
    ticketId,
    { status: "In Progress" },
    { new: true, runValidators: true }
);
```

- `new: true` returns the updated document.
- `runValidators: true` applies schema validation during the update.

### E. Delete a Ticket

```typescript
const ticket = await Ticket.findByIdAndDelete(ticketId);
```

---

# 9. Validation in Mongoose

Validation ensures that invalid data is not saved in our database.

**Example:**

```typescript
title: {
    type: String,
    required: true,
    minlength: 5,
    maxlength: 100,
    trim: true
}
```

Here:
- `required` ensures that the field is provided.
- `minlength` specifies the minimum number of characters.
- `maxlength` specifies the maximum number of characters.
- `trim` removes extra whitespace.

Other common validation options include:
- `enum`
- `min`
- `max`
- `match`

---

# 10. Mongoose Hooks (Middleware)

Hooks allow us to execute code before or after certain database operations.

There are two common types:

- **Pre Hook:** Runs before an operation.
- **Post Hook:** Runs after an operation.

**Example:**

```typescript
ticketSchema.pre("save", function () {
    console.log("Ticket is about to be saved");
});
```

```typescript
ticketSchema.post("save", function (doc) {
    console.log("Ticket saved successfully");
});
```

Hooks are useful for tasks such as logging, modifying data and performing additional operations.

---

# 11. Populate in Mongoose

`populate()` helps us retrieve related documents instead of receiving only their referenced IDs.

For example, a ticket stores an employee's ObjectId. Using `populate()`, we can retrieve the employee's information along with the ticket.

```typescript
const tickets = await Ticket.find().populate("employee");
```

Instead of getting only the employee ID, we get the referenced employee document.

We can also select specific fields:

```typescript
const tickets = await Ticket.find()
    .populate("employee", "name email");
```

---

# 12. Lean Queries

When we only want to read data, we can use `lean()`.

**Example:**

```typescript
const tickets = await Ticket.find().lean();
```

This returns plain JavaScript objects instead of full Mongoose documents.

| Normal Query | Lean Query |
|---|---|
| Returns Mongoose documents | Returns plain JavaScript objects |
| Supports document methods | No Mongoose document methods |
| Supports change tracking | No change tracking |
| More overhead | Lower overhead |

**When to use it:** Use `lean()` for read-only operations where we don't need Mongoose document functionality.

---

# 13. Sequences – Auto-Increment Ticket Numbers

Suppose we want every ticket to have a unique, automatically generated ticket number.

We could use:

```javascript
tickets.length + 1
```

But this is unreliable because:
- Records might be deleted.
- Multiple users might create tickets simultaneously.
- Two requests could generate the same ticket number.

### Solution: Counters Collection

Instead, we can maintain a separate `counters` collection to store the latest ticket number.

For example:

```javascript
{
    _id: "ticketNumber",
    sequenceValue: 1003
}
```

Whenever a new ticket is created, we increment the counter and generate the next ticket number.

### Why Atomic Increment?

Atomic increment prevents two simultaneous requests from reading the same old counter value and generating the same ticket number.

MongoDB provides `$inc` for incrementing values atomically.

**Example:**

```typescript
const counter = await Counter.findByIdAndUpdate(
    "ticketNumber",
    { $inc: { sequenceValue: 1 } },
    { new: true, upsert: true }
);
```

- `$inc` increments the counter value.
- `new: true` returns the updated document.
- `upsert: true` creates the document if it doesn't already exist.

### Creating a Counter Service

Create:

`src/services/counterService.ts`

Put the `getNextTicketNumber()` function inside it.

This keeps counter-related logic separate from the controller.

### Important Change in Application Architecture

Earlier, we might have stored data in an in-memory array.

Now, our service retrieves and stores data in MongoDB using Mongoose.

Therefore, our controller also needs to become asynchronous.

For example, the create-ticket controller should use `async/await` to wait for the database operation to complete.


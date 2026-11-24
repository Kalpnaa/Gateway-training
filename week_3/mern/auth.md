Here are your notes formatted into a clean, beginner-friendly Markdown file. I've kept your original explanations and code examples, just improved the structure, formatting, and readability.

# Authentication and Authorization

Authentication and authorization are used to secure an application by verifying the user's identity and controlling what they are allowed to access.

## 1. Password Hashing Using bcrypt

When a user registers, we should **never store the original password** in the database.

Instead, we use **password hashing**.

Password hashing converts a password into a one-way representation called a hash. We store the hash instead of the original password.

### bcrypt

`bcrypt` is a password-hashing library designed to make password guessing expensive.

Install bcrypt:

```
npm install bcrypt
npm install -D @types/bcrypt
```

### Hash a Password

```
import bcrypt from "bcrypt";

const password = "Rahul@123";

const hashedPassword = await bcrypt.hash(password, 10);

console.log(hashedPassword);
```

- `bcrypt.hash()` converts the password into a hash.
- `10` represents the salt rounds (cost factor).

### Why Use Salt?

Even if two users have the same password, their hashes should normally be different because bcrypt generates a random salt for each hash.

This makes it harder for attackers to identify users with identical passwords.

### Verify a Password

During login, we compare the entered password with the stored hash.

```
const isMatch = await bcrypt.compare(
    "Rahul@123",
    hashedPassword
);

console.log(isMatch);
```

It returns:

- `true` → Password matches.
- `false` → Password does not match.

**Important:** We don't decrypt a hash. Password hashing is one-way. `bcrypt.compare()` verifies a password against the stored hash.

---

## 2. JSON Web Token (JWT)

JWT is a compact token used to securely transmit claims between parties.

In our application, we'll use it to represent the authenticated user.

### Install JWT

```
npm install jsonwebtoken
npm install -D @types/jsonwebtoken
```

### Generate a JWT

```
import jwt from "jsonwebtoken";

const token = jwt.sign(
    {
        userId: "EMP101",
        role: "Employee"
    },
    process.env.JWT_SECRET!,
    {
        expiresIn: "1d"
    }
);

console.log(token);
```

Let's understand:

- `jwt.sign()` creates and signs the token.
- The first argument contains the payload (user information).
- The second argument is the secret key.
- `expiresIn: "1d"` means the token expires after one day.

Add a secret to your `.env` file:

```
JWT_SECRET=your_long_random_secret_key
```

**Important:**

- Use a strong, randomly generated secret in real applications.
- Never commit `.env` to GitHub.

### Verify a JWT

When a client sends a token, the server verifies it.

```
const decoded = jwt.verify(
    token,
    process.env.JWT_SECRET!
);

console.log(decoded);
```

If the token is valid, `jwt.verify()` returns its decoded payload.

If it is expired, invalid, or tampered with, it throws an error.

### Difference Between JWT Methods

| Method         | Purpose                                            |
| -------------- | -------------------------------------------------- |
| `jwt.sign()`   | Creates a token.                                   |
| `jwt.verify()` | Checks whether a token is valid.                   |
| `jwt.decode()` | Reads the payload without verifying its signature. |

**Important:** Do not use `jwt.decode()` for authentication because it does not verify the token's signature.

---

## 3. Authentication Middleware

We don't want to write token verification logic separately in every protected route.

Instead, we create **authentication middleware**.

### Responsibilities of Authentication Middleware

1. Read the token from the request.
2. Verify the token.
3. Extract the user's information.
4. Attach that information to the request.
5. Allow the request to continue using `next()`.

### How Does It Work?

The client generally sends a token in the `Authorization` header:

```
Authorization: Bearer <JWT_TOKEN>
```

Explanation:

- `req.headers.authorization` reads the Authorization header.
- `Bearer` identifies the token format.
- `jwt.verify()` verifies the token.
- `req.user` stores the verified user's identity and role.
- `next()` passes control to the next middleware or controller.
- `401` means the user is not authenticated.

---

## 4. Authorization Using Roles (RBAC)

Authentication confirms **who the user is**.

Authorization determines **what the user is allowed to do**.

Suppose Rahul is an Employee and Priya is a Manager.

Both can successfully log in, but they should not have the same permissions.

### Example: Role-Based Access Control

| Action           | Employee | Support | Manager |
| ---------------- | -------- | ------- | ------- |
| Create ticket    | Yes      | Yes     | Yes     |
| View own tickets | Yes      | Yes     | Yes     |
| Assign tickets   | No       | No      | Yes     |
| View all tickets | No       | Yes     | Yes     |
| Manage employees | No       | No      | Yes     |

This is called **Role-Based Access Control (RBAC)**.

### Create Role Authorization Middleware

Add this to `src/middleware/authMiddleware.ts`:

```
export const authorize = (...allowedRoles: string[]) => {
    return (
        req: Request,
        res: Response,
        next: NextFunction
    ) => {
        if (!req.user) {
            return next(new AppError("Authentication required", 401));
        }

        if (!allowedRoles.includes(req.user.role)) {
            return next(new AppError("Access forbidden", 403));
        }

        next();
    };
};
```

Let's understand:

- `allowedRoles` contains the roles permitted to access a route.
- `includes()` checks whether the logged-in user's role is allowed.
- If the user doesn't have an allowed role, we return `403 Forbidden`.
- Otherwise, `next()` allows the request to continue.

### Use Both Middlewares Together

```
router.get(
    "/manager-dashboard",
    authenticate,
    authorize("Manager"),
    managerDashboardController
);
```

The execution order is:

1. `authenticate` checks whether the user is logged in.
2. `authorize("Manager")` checks whether the user is a manager.
3. `managerDashboardController` handles the request.

---

## 5. Protected Route Decision Flow

When a request comes to a protected route, the server performs two checks.

### Step 1: Authentication

- Is the JWT valid?
- **No** → Return `401 Unauthorized`.
- **Yes** → Continue to authorization.

### Step 2: Authorization

- Is the user's role permitted?
- **No** → Return `403 Forbidden`.
- **Yes** → Allow the request to reach the controller.

### Complete Flow

```
Incoming Request
       |
       v
Authentication Middleware
       |
       v
Is the JWT valid?
       |
   No  |  Yes
       | 
       v
  401 Unauthorized
       |
     Stop

             Yes
              |
              v
    Authorization Middleware
              |
              v
    Is the user's role permitted?
              |
         No   |   Yes
              |
              v
       403 Forbidden
              |
            Stop

                      Yes
                       |
                       v
               Controller Executes
```

---

## 6. Important Exam Points: 401 vs 403

| Status Code        | Meaning                                             | When?                                                       |
| ------------------ | --------------------------------------------------- | ----------------------------------------------------------- |
| `401 Unauthorized` | User is not authenticated.                          | User is not logged in, or the token is invalid/expired.     |
| `403 Forbidden`    | User is authenticated but does not have permission. | User tries to access a resource restricted to another role. |

**Remember:**

- Authentication → Who are you?
- Authorization → What are you allowed to access?
- bcrypt → Securely hashes passwords.
- JWT → Represents the authenticated user.
- `authenticate` → Checks whether the user is logged in.
- `authorize` → Checks whether the user has the required role.
- `401` → Authentication problem.
- `403` → Permission problem.
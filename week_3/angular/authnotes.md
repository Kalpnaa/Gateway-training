# Authentication and Authorization in ASP.NET Core

## 1. ASP.NET Core Identity

ASP.NET Core Identity is a framework that manages user accounts and authentication-related functionality in ASP.NET Core applications.

### Features of ASP.NET Core Identity

| Feature | Purpose |
|---|---|
| User Registration | Create user accounts |
| Login | Verify user credentials |
| Password Hashing | Securely store passwords |
| Password Validation | Enforce password rules |
| Roles | Assign roles such as Admin and Employee |
| Claims | Store information about users |
| Account Management | Password reset, email confirmation, etc. |

### Important Identity Classes

| Class | Purpose |
|---|---|
| `IdentityUser` | Represents a user account |
| `UserManager` | Creates and manages users |
| `SignInManager` | Handles sign-in operations |
| `RoleManager` | Creates and manages roles |
| `PasswordHasher` | Hashes and verifies passwords |

---

## 2. JWT (JSON Web Token)

JWT is a compact token used to securely transmit information between a client and a server.

In ASP.NET Core Web API, JWT is commonly used to authenticate users after they log in.

### How JWT Authentication Works

**1. Angular Frontend**
- User enters email and password.
- Login request is sent to the backend.

**2. ASP.NET Core API**
- Identity verifies the user's credentials.

**3. JWT Generated**
- Backend issues a signed token.
- Token is returned to Angular.

**4. Angular Sends API Requests**
- Angular includes the token in the Authorization header.

```http
Authorization: Bearer <token>
```

**5. API Validates JWT**

The API checks the token and allows access to protected resources if it is valid.

### Structure of a JWT

A JWT consists of three parts separated by dots:

```text
xxxxx.yyyyy.zzzzz
```

These three parts are:

1. Header
2. Payload
3. Signature

### What are Claims?

A claim is a piece of information about an authenticated user.

For example:

| Claim | Value |
|---|---|
| User ID | 101 |
| Email | user@example.com |
| Role | Admin |
| Department | IT |

In ASP.NET Core, claims are represented using the `Claim` class.

### Issuing a JWT

Issuing means generating and giving a token to the user after successful authentication.

### Validating a JWT

When Angular sends a protected API request, it includes:

```http
Authorization: Bearer eyJhbGciOiJIUzI1NiIs...
```

ASP.NET Core's JWT Bearer authentication middleware checks:

- Is the token signature valid?
- Has it expired?
- Does the issuer match?
- Does the audience match?
- Is the token otherwise valid according to the configured validation rules?

If valid, ASP.NET Core creates an authenticated user identity from its claims.

If invalid or expired, the request is generally rejected with **401 Unauthorized**.

### JWT Implementation Setup

Install the JWT Bearer authentication package:

```bash
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 10.0.0
```

Initialize User Secrets:

```bash
dotnet user-secrets init
```

Store JWT configuration securely during development:

```bash
dotnet user-secrets set "Jwt:Key" "MyDevelopmentSecretKeyForHelpdeskApi2026_123456"

dotnet user-secrets set "Jwt:Issuer" "HelpdeskApi"

dotnet user-secrets set "Jwt:Audience" "HelpdeskClient"
```

---

## 3. Authorization

Authorization determines what an authenticated user is allowed to access or perform.

### [Authorize] Attribute

ASP.NET Core provides the `[Authorize]` attribute to restrict access to authenticated users.

It can be applied to controllers or individual endpoints.

### Role-Based Authorization

Role-based authorization restricts endpoints based on a user's role.

For example:
- Admin can access administrative endpoints.
- Employee can access employee-specific endpoints.

**Controller-based syntax:**

```csharp
[Authorize(Roles = "Admin")]
[HttpGet("admin")]
public IActionResult GetAdminData()
{
    return Ok("Welcome Admin");
}
```

**Minimal API syntax:**

```csharp
app.MapGet("/admin", () => "Welcome Admin")
   .RequireAuthorization(policy =>
       policy.RequireRole("Admin"));
```

### Policy-Based Authorization

Policy-based authorization allows us to define more flexible authorization rules using:

- Roles
- Claims
- Custom requirements
- Combinations of multiple conditions

Policies are defined centrally and applied to controllers or endpoints.

**Example:**

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("Admin"));
});
```

Apply the policy:

```csharp
[Authorize(Policy = "AdminOnly")]
```

For Minimal APIs:

```csharp
app.MapGet("/admin", () => "Welcome Admin")
   .RequireAuthorization("AdminOnly");
```


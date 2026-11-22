# Angular

## 1. Getting Started with Angular

Angular is a TypeScript-based frontend framework developed by Google for building dynamic, single-page web applications (SPAs).

### 1.1 Angular CLI

Angular CLI (Command Line Interface) is a command-line tool that helps developers create, develop, test, and build Angular applications.

Instead of manually creating every file, Angular CLI generates the required project structure and code.

**Important commands:**

```bash
npm install -g @angular/cli

npx ng version

npx ng new proj-ui

cd proj-ui

npx ng serve

npx ng generate component tickets

npx ng generate service ticket
```

### 1.2 Project Structure

| File | Purpose |
|---|---|
| `main.ts` | Starting point of the Angular application |
| `app.component.ts` | Contains component logic |
| `app.component.html` | Contains the component's HTML template |
| `app.component.css` | Contains component-specific styling |
| `app.config.ts` | Application-level configuration and providers |
| `app.routes.ts` | Defines application routes |
| `index.html` | Main HTML page |
| `package.json` | Dependencies and npm scripts |
| `angular.json` | Angular CLI project configuration |

### 1.3 Standalone Components

A standalone component is a component that can manage its own dependencies without needing to be declared inside an Angular NgModule.

**Example:**

```typescript
import { Component } from '@angular/core';

@Component({
  selector: 'app-welcome',
  standalone: true,
  template: `<h1>Welcome to Helpdesk!</h1>`
})
export class WelcomeComponent {

}
```

**Understanding the code:**

- `@Component` → Decorator that tells Angular this class is a component.
- `selector` → HTML tag used to display the component.
- `standalone: true` → Makes the component independently usable.
- `template` → HTML content displayed by the component.
- `WelcomeComponent` → Component class containing its logic.

---

## 2. Components and Templates

### 2.1 Components

A component is a reusable and independent part of an Angular application that controls a particular section of the user interface.

Each component generally consists of three main parts:

- `.html` → Defines the UI.
- `.css` → Defines the styling.
- `.ts` → Contains the component logic.

### 2.2 Interpolation

Interpolation is used to display TypeScript component data inside an HTML template.

**Syntax:**

```html
{{ expression }}
```

It allows us to display component properties and expressions in HTML.

### 2.3 Property Binding

Property binding is used to connect component data to an HTML element property.

**Syntax:**

```html
[property]="expression"
```

**Examples:**

```html
<img [src]="imageUrl">

<button [disabled]="isDisabled">
  Submit Ticket
</button>
```

### 2.4 Event Binding

Event binding allows us to execute a component method when a user performs an action.

**Component (TypeScript):**

```typescript
export class Ticket {

  message = '';

  createTicket() {
    this.message = 'Ticket created successfully!';
  }

}
```

**Template (HTML):**

```html
<button (click)="createTicket()">
  Create Ticket
</button>

<p>{{ message }}</p>
```

Here, when the user clicks the button, the `createTicket()` method is executed.

### 2.5 Two-Way Binding

Two-way binding means data can flow in both directions:

- Component → HTML
- HTML → Component

It uses `[(ngModel)]` for two-way binding.

**Example:**

```html
<input [(ngModel)]="variableName">
```

Notice the combination:

- `[ ]` represents property binding.
- `( )` represents event binding.
- `[( )]` combines both, which is called **banana-in-a-box syntax**.

**Note:** To use `ngModel`, import `FormsModule` into the standalone component.

### 2.6 Control Flow: @if and @for

Control flow allows us to decide which HTML elements should be displayed based on conditions or data.

Angular provides built-in control flow syntax:

| Syntax | Purpose |
|---|---|
| `@if` | Displays content conditionally |
| `@else` | Displays alternative content |
| `@for` | Repeats content for each item in a collection |
| `@empty` | Displays content when a collection is empty |

**Example:**

```html
@if (isLoggedIn) {
  <p>Welcome back!</p>
} @else {
  <p>Please log in.</p>
}
```

**@for example:**

```html
@for (ticket of tickets; track ticket.id) {
  <p>{{ ticket.title }}</p>
} @empty {
  <p>No tickets available.</p>
}
```

### 2.7 Pipes

A Pipe is used to transform or format data before displaying it in an HTML template, without changing the original value stored in the component.

**Examples:**

- Convert text into uppercase or lowercase.
- Format dates.
- Format currency.
- Display numbers with decimal precision.
- Convert numbers into percentage format.

#### A. Syntax

```html
{{ value | pipeName }}
```

The `|` symbol is called the pipe operator.

#### B. Common Built-in Pipes

| Pipe | Purpose |
|---|---|
| `uppercase` | Converts text to uppercase |
| `lowercase` | Converts text to lowercase |
| `titlecase` | Capitalizes the first letter of words |
| `date` | Formats dates |
| `currency` | Formats currency |
| `number` | Formats numbers |
| `percent` | Converts a number into percentage format |
| `json` | Displays an object as JSON |

#### C. Practical Examples

Suppose our Helpdesk component contains:

```typescript
export class Ticket {
  ticketTitle = 'login issue';
  createdAt = new Date();
  amount = 2500;
  completion = 0.75;
}
```

We can format these values in the HTML template:

```html
<h2>{{ ticketTitle | uppercase }}</h2>

<p>{{ ticketTitle | titlecase }}</p>

<p>{{ createdAt | date:'dd/MM/yyyy' }}</p>

<p>{{ amount | currency:'INR' }}</p>

<p>{{ completion | percent }}</p>
```

#### D. Parameterized Pipes

Some pipes accept additional arguments to customize the output.

For example:

```html
{{ createdAt | date:'dd/MM/yyyy' }}
```

Here, `dd/MM/yyyy` specifies the date format.

Similarly:

```html
{{ amount | currency:'INR':'symbol':'1.0-0' }}
```

This formats the number as Indian currency without decimal places.

#### E. Chaining Pipes

We can apply multiple pipes to the same value.

```html
{{ ticketTitle | lowercase | titlecase }}
```

Angular applies the pipes from left to right.

#### F. Custom Pipes

Angular also allows us to create our own pipes when built-in pipes don't meet our requirements.

For example, suppose we want to display ticket statuses in a more readable format.

**Generate a custom pipe:**

```bash
npx ng generate pipe ticket-status
```

---

## 3. Services and Dependency Injection

### 3.1 Services

A service is a TypeScript class used to store reusable logic or data that can be shared across multiple components.

For example, in our Helpdesk application, `TicketService` can contain methods for retrieving, creating, updating, and deleting tickets.

**Generate a service:**

```bash
npx ng generate service ticket
```

### 3.2 Dependency Injection (DI)

Dependency Injection is a design pattern in which a class receives the objects or services it needs from an external system instead of creating them itself.

In Angular, the framework's injector manages and provides these dependencies.

For example, our component needs `TicketService` to retrieve ticket data.

Instead of creating the service manually, Angular provides it through Dependency Injection.

**Example:**

```typescript
import { Component, inject } from '@angular/core';
import { TicketService } from './ticket.service';

@Component({
  selector: 'app-tickets',
  standalone: true,
  template: `<h2>Tickets</h2>`
})
export class TicketsComponent {

  ticketService = inject(TicketService);

}
```

### Sharing Data Between Multiple Components

Services allow multiple components to access and share common data and logic.

For example:

- Dashboard component can retrieve ticket statistics.
- Ticket List component can retrieve all tickets.
- Create Ticket component can create new tickets.

All these components can use the same `TicketService`.

---

## 4. Routing

Routing allows us to navigate between different views or pages of an application without reloading the entire browser page.

Angular uses a Router to decide which component should be displayed based on the URL.

### 4.1 Defining Routes

Routes are defined using an array of route objects, generally in `app.routes.ts`.

**Important route properties:**

| Property | Purpose |
|---|---|
| `path` | URL path |
| `component` | Component to display |
| `redirectTo` | Redirects to another route |
| `canActivate` | Guard that controls access to a route |

**Example:**

```typescript
import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { TicketListComponent } from './ticket-list/ticket-list.component';

export const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },

  { path: 'tickets', component: TicketListComponent },

  { path: '', redirectTo: 'dashboard', pathMatch: 'full' }
];
```

The routes are registered in `app.config.ts` using `provideRouter(routes)`.

### 4.2 Router Outlet

Defining routes is not enough. Angular also needs to know where to display the selected component.

For that, we use:

```html
<router-outlet></router-outlet>
```

Think of `router-outlet` as a placeholder where Angular displays the component corresponding to the current route.

### 4.3 Routing Links and Navigation

To navigate between routes, Angular provides the `routerLink` directive.

We use `routerLink` instead of normal `href` because it uses Angular Router for client-side navigation without a full page reload.

**Example:**

```html
<a routerLink="/dashboard">Dashboard</a>

<a routerLink="/tickets">Tickets</a>
```

We can also navigate programmatically using `router.navigate()` from TypeScript.

**Example:**

```typescript
import { Router } from '@angular/router';
import { inject } from '@angular/core';

export class TicketComponent {

  router = inject(Router);

  goToTickets() {
    this.router.navigate(['/tickets']);
  }

}
```

### 4.4 Route Parameters

We don't need to create separate routes for every ticket. Instead, we use dynamic route parameters.

**Example route:**

```typescript
{ path: 'tickets/:id', component: TicketDetailsComponent }
```

Here, `:id` is a dynamic route parameter.

For example:

```text
/tickets/101
/tickets/102
/tickets/103
```

All these URLs can display the same component with different ticket IDs.

**Important concepts:**

| Concept | Purpose |
|---|---|
| `ActivatedRoute` | Provides information about the currently active route |
| `snapshot` | Reads route information at a particular moment |
| `paramMap` | Provides access to route parameters |
| `get('id')` | Retrieves the value of the id parameter |

**Reading a route parameter using snapshot:**

```typescript
import { ActivatedRoute } from '@angular/router';
import { inject } from '@angular/core';

export class TicketDetailsComponent {

  route = inject(ActivatedRoute);

  ticketId = this.route.snapshot.paramMap.get('id');

}
```

**One additional concept:**

If the same component stays active while the route parameter changes, `snapshot` won't automatically update your property.

In that situation, we can subscribe to `paramMap` to react to changes.

### 4.5 Route Guards

Route guards control whether a user can navigate to a particular route.

For example, only authenticated users should be allowed to access the dashboard.

**Important route guards:**

| Guard | Purpose |
|---|---|
| `CanActivate` | Controls access to a route |
| `CanActivateChild` | Controls access to child routes |
| `CanDeactivate` | Controls whether a user can leave a route |
| `CanMatch` | Controls whether a route can be selected for matching |

---

## 5. Reactive Forms

Reactive Forms are an Angular approach to creating and managing forms using TypeScript.

### 5.1 Reactive Forms vs Template-Driven Forms

| Template-Driven Forms | Reactive Forms |
|---|---|
| Form logic mainly in HTML | Form logic mainly in TypeScript |
| Uses `ngModel` | Uses `FormControl` and `FormGroup` |
| Suitable for simple forms | Suitable for complex forms |
| Less explicit control | More control and testability |

### 5.2 FormGroup and FormControl

**FormControl**

- Represents an individual form field.
- Each field can have its own value and validation rules.

**Example:**

```typescript
import { FormControl } from '@angular/forms';

title = new FormControl('');
```

**FormGroup**

It combines multiple FormControls into one form.

**Example:**

```typescript
import { FormGroup, FormControl } from '@angular/forms';

ticketForm = new FormGroup({
  title: new FormControl(''),
  description: new FormControl(''),
  priority: new FormControl('Medium')
});
```

### 5.3 Connecting Reactive Forms with HTML

Two important directives:

- `[formGroup]` → Connects HTML form to TypeScript FormGroup.
- `formControlName` → Connects an HTML input to an individual FormControl.

**Example:**

```html
<form [formGroup]="ticketForm">

  <input formControlName="title">

  <textarea formControlName="description"></textarea>

  <input formControlName="priority">

</form>
```

### 5.4 Built-in Validators

Validators are used to check whether the entered values satisfy certain conditions.

Angular provides built-in validators through the `Validators` class.

**Some important validators:**

| Validator | Purpose |
|---|---|
| `Validators.required` | Field cannot be empty |
| `Validators.minLength(5)` | Minimum 5 characters |
| `Validators.maxLength(100)` | Maximum 100 characters |
| `Validators.email` | Checks email format |
| `Validators.pattern()` | Checks a specified pattern |
| `Validators.min(1)` | Minimum numeric value |
| `Validators.max(10)` | Maximum numeric value |

**Example:**

```typescript
import { FormGroup, FormControl, Validators } from '@angular/forms';

ticketForm = new FormGroup({

  title: new FormControl('', [
    Validators.required,
    Validators.minLength(5)
  ]),

  description: new FormControl('', [
    Validators.required
  ])

});
```

### Important FormControl Properties

| Property | Meaning |
|---|---|
| `valid` | All validation rules pass |
| `invalid` | One or more validation rules fail |
| `value` | Current field value |
| `errors` | Validation errors |
| `touched` | User has interacted with and left the field |
| `dirty` | User has changed the field value |
| `pristine` | User has not changed the field value |

For example:

```typescript
this.ticketForm.get('title')?.invalid;
```

### 5.5 Custom Validators

We can create our own validators for specific validation requirements.

We create a function that implements Angular's `ValidatorFn` type and returns either:

- `null` → Validation successful.
- An error object → Validation failed.

**Example structure:**

```typescript
import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export const customValidator: ValidatorFn = (
  control: AbstractControl
): ValidationErrors | null => {

  if (control.value === 'invalid') {
    return { customError: true };
  }

  return null;
};
```

### 5.6 Showing Validation Errors

We can display error messages in HTML using Angular's `@if` control flow.

**Example:**

```html
@if (
  ticketForm.get('title')?.hasError('required') &&
  ticketForm.get('title')?.touched
) {
  <p>Title is required.</p>
}
```

### 5.7 Form Submission

We use `(ngSubmit)` to handle form submission.

**Example:**

```html
<form [formGroup]="ticketForm" (ngSubmit)="submitForm()">

  <input formControlName="title">

  <button type="submit">Submit</button>

</form>
```

The `submitForm()` method handles the submitted form data in TypeScript.

---

## 6. Talking to the API

### 6.1 HttpClient

HttpClient is an Angular service used to communicate with backend APIs through HTTP requests.

**Important HTTP methods:**

| Method | Purpose | Helpdesk Example |
|---|---|---|
| GET | Retrieve data | Get all tickets |
| POST | Create data | Create a ticket |
| PUT | Update existing data | Update a ticket |
| PATCH | Partially update data | Change ticket status |
| DELETE | Delete data | Delete a ticket |

### 6.2 Typed API Responses

An interface defines the structure of an object, including its properties and their data types.

The ASP.NET Core API returns information, so we should have a TypeScript interface representing this response.

**Example:**

```typescript
export interface Ticket {
  id: number;
  title: string;
  description: string;
  status: string;
  priority: string;
}
```

Typed responses help us with:

- Better code organization.
- Type checking.
- Autocomplete in the code editor.
- Fewer mistakes while accessing object properties.

### 6.3 Observables and HTTP Requests

Angular HttpClient returns an Observable, not an immediate response value.

The request is not executed just because this method returns an Observable. We need to subscribe to it or use another mechanism such as the async pipe.

**Example:**

```typescript
this.ticketService.getTickets().subscribe({

  next: (data) => {
    console.log(data);
  },

  error: (error) => {
    console.log(error);
  }

});
```

Here:

- `next` runs when the response is successfully received.
- `error` runs when the request fails.

### 6.4 HTTP Interceptors

HTTP Interceptors are used to intercept outgoing HTTP requests and incoming HTTP responses.

They allow us to perform common operations without repeating the same code in every API call.

**Example: JWT Authentication Flow**

```text
Angular Component
       |
       | Requests ticket data
       v
HTTP Interceptor
       |
       | Reads JWT and adds Authorization header
       v
ASP.NET Core Web API
       |
       | Validates JWT and processes request
       v
Response returned to Angular
```

Common uses:

- Adding JWT tokens to outgoing requests.
- Logging HTTP requests.
- Handling common errors.
- Modifying HTTP headers.

---

## 7. RxJS Basics

RxJS stands for Reactive Extensions for JavaScript.

It is a library used in Angular to handle asynchronous data and events using Observables.

### 7.1 Observable

An Observable represents a stream of data that can arrive over time.

It doesn't necessarily contain the data immediately. It represents a future stream of values that we can observe.

Think of it like subscribing to a notification service: whenever a notification arrives, you receive it.

### 7.2 Subscribe()

`subscribe()` is used to receive values emitted by an Observable.

**Important properties:**

| Property | Purpose |
|---|---|
| `next` | Receives emitted data |
| `error` | Handles errors |
| `complete` | Runs when the Observable completes |

For a normal HttpClient GET request, the Observable generally emits the response and then completes.

### 7.3 pipe()

`pipe()` is used to apply RxJS operators to an Observable.

**Example:**

```typescript
this.ticketService.getTickets().pipe(

  map(tickets =>
    tickets.filter(t => t.status === 'Open')
  )

).subscribe(data => {
  console.log(data);
});
```

Here:

- `pipe()` creates a processing chain.
- `map()` transforms the emitted data.
- `subscribe()` receives the final result.

Think of `pipe()` as a processing pipeline through which data passes before reaching the subscriber.

### 7.4 map()

`map()` transforms an emitted value into another value.

For example, we can transform a list of tickets into the total number of tickets.

### 7.5 catchError()

`catchError()` is used to handle errors in an Observable pipeline.

It allows us to return an alternative Observable when an error occurs.

### 7.6 switchMap()

`switchMap()` takes a value from one Observable and switches to a new Observable.

It is particularly useful for search functionality.

For example, when a user searches for tickets, we want to process the latest search request instead of waiting for older requests to finish.

### Important RxJS Concepts

| Operator / Concept | Purpose | Helpdesk Example |
|---|---|---|
| Observable | Represents asynchronous data | API response |
| subscribe | Receives data | Display tickets |
| pipe | Chains operators | Process API data |
| map | Transforms data | Get total ticket count |
| catchError | Handles errors | Handle failed API request |
| switchMap | Switches to the latest Observable | Ticket search |

---

## 8. Angular Material (UI Library)

Angular Material provides ready-made UI components so developers don't have to build elements from scratch.

Instead of manually designing buttons, tables, and dialogs, we can use predefined Angular Material components.

### 8.1 Angular Material Table

A Material Table displays structured data in rows and columns.

It provides the `MatTable` component.

**Important components and directives:**

| Component / Directive | Purpose |
|---|---|
| `mat-table` | Creates the table |
| `matColumnDef` | Defines a column |
| `mat-header-cell` | Defines header cells |
| `mat-cell` | Defines data cells |
| `matSort` | Enables sorting |
| `mat-paginator` | Enables pagination |

### 8.2 Angular Material Form Fields

Angular Material provides styled input controls.

**Important components and directives:**

| Component / Directive | Purpose |
|---|---|
| `mat-form-field` | Container for an input |
| `mat-label` | Input label |
| `matInput` | Material input directive |
| `mat-error` | Displays validation errors |
| `mat-hint` | Displays helper text |

### 8.3 Material Dialog

A dialog is a popup window that appears over the current page.

Angular Material provides `MatDialog`.

**Important methods:**

| Method | Purpose |
|---|---|
| `open()` | Opens a dialog |
| `close()` | Closes a dialog |
| `afterClosed()` | Receives the result after closing |

### 8.4 Angular Material Snackbar

A Snackbar displays a temporary notification to the user.

Angular Material provides `MatSnackBar`.

For example:

- Ticket created successfully!
- Ticket updated successfully!
- Something went wrong!

### Summary of Angular Material Components

| Component | Main Purpose |
|---|---|
| `MatTable` | Display structured data |
| `MatFormField` | Styled form inputs |
| `MatDialog` | Popup windows |
| `MatSnackBar` | Temporary notifications |
| `MatPaginator` | Table pagination |
| `MatSort` | Table sorting |
| `MatInput` | Styled input control |

---

## 9. Overall Angular Flow in Helpdesk

The concepts we learned can work together in our Helpdesk application.

1. **Components:** Create different UI sections such as Dashboard, Ticket List, and Create Ticket.
2. **Templates:** Display data and handle user interactions.
3. **Services:** Store reusable logic and communicate with the backend.
4. **Dependency Injection:** Provide services to components.
5. **Routing:** Navigate between different pages.
6. **Reactive Forms:** Create and validate ticket forms.
7. **HttpClient:** Communicate with the ASP.NET Core Web API.
8. **Interceptors:** Automatically attach JWT tokens to API requests.
9. **RxJS:** Handle asynchronous API responses and data processing.
10. **Angular Material:** Build a consistent and user-friendly interface.

**Overall application flow:**

```text
User
 |
 v
Angular Component
 |
 v
Angular Service
 |
 v
HTTP Interceptor
 |
 v
ASP.NET Core Web API
 |
 v
Database
 |
 v
API Response
 |
 v
Angular Component
 |
 v
Display Data to User
```

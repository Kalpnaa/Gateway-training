## 1. Introduction to TypeScript

- TypeScript (TS): A strongly typed programming language built on top of JavaScript.
- TypeScript is a superset of JavaScript, meaning it includes all JavaScript features along with additional features.
- TypeScript helps identify errors during development through its type-checking system.

### Why TypeScript?

1. Types – Data Types: Defines the type of data a variable can store.
2. Loose Documentation in JavaScript: JavaScript has fewer built-in ways to describe expected data types. TypeScript makes code easier to understand.
3. Developer Tooling: Provides better autocomplete, error detection and debugging support.
4. AI-Friendly: Clear types and interfaces help AI tools understand code structure and generate more consistent code.
5. Add-on to JavaScript: Supports JavaScript features and adds static typing.
6. TypeScript Process: TypeScript code is converted into JavaScript before execution.
7. Type Checker: Checks type consistency and identifies errors during development.

## 2. TypeScript Architecture

Flow:

TypeScript Code (.ts)

Lexer

Breaks source code into tokens.

Parser

Converts tokens into an Abstract Syntax Tree (AST).

Binder

Creates symbol tables and connects declarations with their scopes.

Type Checker

Checks types and ensures consistency. Uses short-circuit evaluation where applicable.

Emitter

Generates JavaScript and declaration files.

Output

.js, .d.ts and other generated files

Important terms:

- Lexer: Converts source code into tokens.
- Parser: Creates AST (Abstract Syntax Tree).
- Binder: Creates symbol tables and establishes relationships between symbols and scopes.
- Type Checker: Checks whether types are used correctly.
- Emitter: Removes TypeScript-specific syntax and generates JavaScript output.

## 3. Installation and Setup

Install TypeScript as a development dependency:

```
npm install -D typescript
```

Initialize TypeScript configuration:

```
npx tsc --init
```

Compile TypeScript into JavaScript:

```
npx tsc
```

Important: `tsconfig.json` stores TypeScript compiler configuration.

## 4. Types in TypeScript

TypeScript supports Type Annotation and Type Inference.

### A. Type Annotation

Explicitly defining the data type of a variable.

Syntax:

```
let variableName: dataType = value;
```

Examples:

```
let name: string = "Kalpana";
let age: number = 21;
let isStudent: boolean = true;
```

### B. Basic Data Types

| Data type | Description    | Example   |
| --------- | -------------- | --------- |
| `string`  | Text values    | `"Hello"` |
| `number`  | Numeric values | `100`     |
| `boolean` | True or false  | `true`    |

### C. Type Inference

TypeScript automatically determines the type based on the assigned value.

```
let name = "Kalpana";
let age = 21;
```

Here, TypeScript automatically infers `string` and `number`.

## 5. Union Types

Union types allow a variable to store values of more than one specified type.

Syntax:

```
let variable: type1 | type2;
```

Example:

```
let id: number | string;

id = 101;
id = "ABC101";
```

Here, `id` can store either a number or a string.

## 6. Arrays in TypeScript

Arrays store multiple values of the same specified type.

Syntax:

```
let arrayName: dataType[] = [];
```

Example:

```
let numbers: number[] = [10, 20, 30];

let names: string[] = ["A", "B", "C"];
```

Alternative syntax:

```
let numbers: Array<number> = [10, 20, 30];
```

## 1. Introduction to HTML and CSS

### What is HTML?

HTML (HyperText Markup Language) is the standard markup language used to create the structure and content of web pages.

It tells the browser what elements should appear on a page, such as:

- Headings and paragraphs
- Images and links
- Tables and lists
- Forms and buttons
- Navigation sections and page content

HTML is a markup language, not a programming language. It describes the structure of content using elements and tags.

### What is CSS?

CSS (Cascading Style Sheets) is used to control the presentation and appearance of HTML elements.

It defines:

- Colours and backgrounds
- Fonts and text styling
- Width, height and spacing
- Borders and shadows
- Element positioning
- Page layouts
- Responsive behaviour across devices

### HTML vs CSS vs JavaScript

| Technology | Responsibility | Example                        |
| ---------- | -------------- | ------------------------------ |
| HTML       | Structure      | Create a button                |
| CSS        | Presentation   | Make the button blue           |
| JavaScript | Behaviour      | Perform an action when clicked |

Think of a webpage as a house:

- HTML = structure of the house.
- CSS = paint, furniture and design.
- JavaScript = electrical systems and functionality.

# Part 1: HTML

## 2. HTML document structure

Every standard HTML page follows a basic structure.

```
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>My First Website</title>
</head>

<body>

    <h1>Welcome to My Website</h1>
    <p>This is my first webpage.</p>

</body>
</html>
```

Let's understand every part.

### 2.1 `<!DOCTYPE html>`

- Declares that the document uses HTML5.
- It is not an HTML element.
- It tells the browser to render the page using standards mode rather than quirks mode.

### 2.2 `<html>`

- Root element of the HTML document.
- All other HTML elements are placed inside it, except the doctype declaration.
- `lang="en"` indicates that the page's primary language is English.

### 2.3 `<head>`

Contains metadata and information about the document.

It generally does not contain the visible page content.

Common elements inside `<head>`:

| Element    | Purpose                                 |
| ---------- | --------------------------------------- |
| `<title>`  | Sets the browser tab title              |
| `<meta>`   | Provides metadata                       |
| `<link>`   | Connects external resources such as CSS |
| `<style>`  | Contains internal CSS                   |
| `<script>` | Loads or contains JavaScript            |

Example:

```
<head>
    <title>Student Portal</title>

    <meta charset="UTF-8">

    <meta name="description"
          content="Student management portal">

    <meta name="viewport"
          content="width=device-width, initial-scale=1.0">

    <link rel="stylesheet" href="style.css">
</head>
```

Important metadata:

`charset="UTF-8"`

Specifies the character encoding. UTF-8 supports a wide range of characters and symbols.

`name="viewport"`

Controls the page's viewport on mobile devices.

- `width=device-width` makes the viewport width match the device width.
- `initial-scale=1.0` sets the initial zoom level.

Without a suitable viewport setting, a mobile browser may render the page using a wider virtual viewport, making it appear zoomed out.

### 2.4 `<body>`

Contains the visible content of the webpage.

Examples:

```
<body>
    <h1>About Us</h1>
    <p>We build software solutions.</p>
    <img src="logo.png" alt="Company logo">
    <button>Contact Us</button>
</body>
```

Remember: `<head>` contains document information; `<body>` contains page content.

## 3. HTML elements, tags and attributes

These three terms are related but different.

### Tags

Tags are the markup enclosed in angle brackets.

```
<p>Hello World</p>
```

Here:

- `<p>` is the opening tag.
- `</p>` is the closing tag.

### Element

An element includes the opening tag, content and closing tag.

```
<p>Hello World</p>
```

The entire expression is a paragraph element.

### Attributes

Attributes provide additional information or configuration for an element.

```
<a href="https://example.com" target="_blank">
    Visit Website
</a>
```

Here:

- `href` specifies the destination.
- `target="_blank"` requests opening the destination in a new browsing context, usually a new tab.

General syntax:

```
<tag attribute="value">Content</tag>
```

### Types of HTML elements

1\. Paired elements

Have opening and closing tags.

```
<h1>Hello</h1>
<p>Welcome</p>
<div>Content</div>
```

2\. Void elements

Do not have closing tags or content.

```
<br>
<hr>
<img src="photo.jpg" alt="Photo">
<input type="text">
<meta charset="UTF-8">
```

You may see `<br />` or `<img />` in HTML, but the slash is not required for HTML void elements.

### Nested elements

An element can contain other elements.

```
<div>
    <h2>Student Details</h2>
    <p>Name: Mira</p>
</div>
```

Elements should be properly nested.

Correct:

```
<p><strong>Hello</strong></p>
```

Incorrect:

```
<p><strong>Hello</p></strong>
```

## 4. HTML headings, paragraphs and text formatting

### Headings

HTML provides six heading levels:

```
<h1>Main Heading</h1>
<h2>Section Heading</h2>
<h3>Subsection Heading</h3>
<h4>Heading Level 4</h4>
<h5>Heading Level 5</h5>
<h6>Heading Level 6</h6>
```

- `<h1>` is the highest-level heading.
- `<h6>` is the lowest-level heading.
- Headings provide a hierarchical structure to content.
- Use headings according to their meaning, not just their visual size.

A good structure:

```
<h1>Web Development</h1>

<h2>Frontend Development</h2>
<h3>HTML</h3>
<h3>CSS</h3>

<h2>Backend Development</h2>
<h3>Python</h3>
```

### Paragraph

```
<p>This is a paragraph.</p>
```

### Text formatting elements

| Element    | Purpose                                    |
| ---------- | ------------------------------------------ |
| `<strong>` | Indicates strong importance                |
| `<b>`      | Draws attention stylistically              |
| `<em>`     | Emphasises text                            |
| `<i>`      | Alternate voice or stylistic text          |
| `<u>`      | Marks text with an annotation or underline |
| `<mark>`   | Highlights text                            |
| `<small>`  | Side comments or fine print                |
| `<del>`    | Deleted text                               |
| `<ins>`    | Inserted text                              |
| `<sub>`    | Subscript                                  |
| `<sup>`    | Superscript                                |
| `<code>`   | Represents code                            |
| `<pre>`    | Preformatted text                          |

Example:

```
<p><strong>Important:</strong> Submit the assignment.</p>

<p>This is <em>very important</em>.</p>

<p>Water: H<sub>2</sub>O</p>

<p>Math: x<sup>2</sup></p>

<p>Price: <del>₹1000</del> ₹800</p>
```

Important distinction: `<strong>` and `<em>` carry semantic meaning; `<b>` and `<i>` are primarily stylistic.

## 5. HTML lists

HTML provides three commonly used list types.

### 5.1 Ordered list — `<ol>`

Used when the order of items matters.

```
<h2>Steps to Register</h2>

<ol>
    <li>Open the website</li>
    <li>Enter your details</li>
    <li>Submit the form</li>
</ol>
```

Output: numbered list.

Useful attributes:

```
<ol type="A">
    <li>HTML</li>
    <li>CSS</li>
</ol>
```

The `type` attribute supports:

- `1` – Numbers
- `A` – Uppercase letters
- `a` – Lowercase letters
- `I` – Uppercase Roman numerals
- `i` – Lowercase Roman numerals

### 5.2 Unordered list — `<ul>`

Used when the order does not matter.

```
<ul>
    <li>Python</li>
    <li>Java</li>
    <li>C#</li>
</ul>
```

It usually displays bullet points.

### 5.3 Description list — `<dl>`

Used for terms and their descriptions.

```
<dl>
    <dt>HTML</dt>
    <dd>Defines webpage structure.</dd>

    <dt>CSS</dt>
    <dd>Defines webpage presentation.</dd>
</dl>
```

- `<dl>` – Description list
- `<dt>` – Term
- `<dd>` – Description

### Nested lists

Lists can be nested inside other lists.

```
<ul>
    <li>Frontend
        <ul>
            <li>HTML</li>
            <li>CSS</li>
        </ul>
    </li>

    <li>Backend
        <ul>
            <li>Python</li>
            <li>Java</li>
        </ul>
    </li>
</ul>
```

## 6. HTML links — `<a>`

The anchor element creates hyperlinks.

```
<a href="https://www.google.com">
    Open Google
</a>
```

### Important attributes

| Attribute  | Purpose                                       |
| ---------- | --------------------------------------------- |
| `href`     | Destination URL                               |
| `target`   | Where to open the link                        |
| `title`    | Additional advisory information               |
| `download` | Suggests downloading the linked resource      |
| `rel`      | Describes the relationship to the destination |

### Opening a link in a new tab

```
<a href="https://example.com"
   target="_blank"
   rel="noopener">
    Visit Website
</a>
```

`noopener` prevents the opened page from accessing the original page through `window.opener`.

### Types of links

External link

```
<a href="https://google.com">Google</a>
```

Internal page link

```
<a href="about.html">About Us</a>
```

Email link

```
<a href="mailto:hello@example.com">
    Send Email
</a>
```

Telephone link

```
<a href="tel:+911234567890">
    Call Us
</a>
```

Jump to a section on the same page

```
<a href="#contact">Go to Contact</a>

<section id="contact">
    <h2>Contact Us</h2>
</section>
```

Here, `href="#contact"` points to the element with `id="contact"`.

Important: Use `<a>` for navigation and `<button>` for actions.

## 7. HTML images — `<img>`

The image element displays an image.

```
<img src="student.jpg"
     alt="Student studying at a desk">
```

### Important attributes

| Attribute | Purpose                         |
| --------- | ------------------------------- |
| `src`     | Image file path or URL          |
| `alt`     | Text alternative                |
| `width`   | Image width                     |
| `height`  | Image height                    |
| `loading` | Loading behaviour               |
| `title`   | Additional advisory information |

Example:

```
<img
    src="profile.jpg"
    alt="Profile picture of a student"
    width="200"
    height="200"
    loading="lazy">
```

### Absolute vs relative paths

Absolute URL:

```
<img src="https://example.com/images/photo.jpg" alt="Photo">
```

Relative path:

```
<img src="images/photo.jpg" alt="Photo">
```

### Why is `alt` important?

- Screen readers can describe the image to users who cannot see it.
- It provides alternative text when an image cannot load.
- It improves accessibility.

For a decorative image that adds no meaningful information:

```
<img src="decoration.png" alt="">
```

An empty `alt` tells assistive technology that the image can be skipped.

### Responsive images

```
<img
    src="photo.jpg"
    alt="A mountain landscape"
    style="max-width: 100%; height: auto;">
```

This prevents the image from exceeding its container's width.

## 8. HTML tables

Tables represent data arranged in rows and columns.

Example:

```
<table>
    <thead>
        <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Marks</th>
        </tr>
    </thead>

    <tbody>
        <tr>
            <td>1</td>
            <td>Mira</td>
            <td>90</td>
        </tr>

        <tr>
            <td>2</td>
            <td>Riya</td>
            <td>85</td>
        </tr>
    </tbody>

    <tfoot>
        <tr>
            <td colspan="2">Average</td>
            <td>87.5</td>
        </tr>
    </tfoot>
</table>
```

### Important table elements

| Element      | Meaning                       |
| ------------ | ----------------------------- |
| `<table>`    | Defines a table               |
| `<tr>`       | Table row                     |
| `<th>`       | Header cell                   |
| `<td>`       | Data cell                     |
| `<thead>`    | Groups header rows            |
| `<tbody>`    | Groups main data rows         |
| `<tfoot>`    | Groups footer rows            |
| `<caption>`  | Table title or description    |
| `<colgroup>` | Groups columns for formatting |

### `colspan` and `rowspan`

colspan: A cell spans multiple columns.

```
<td colspan="2">Total</td>
```

rowspan: A cell spans multiple rows.

```
<td rowspan="2">Computer Engineering</td>
```

### Table accessibility

Use `<th>` for header cells and specify `scope` when appropriate.

```
<th scope="col">Name</th>
<th scope="col">Marks</th>
```

For row headers:

```
<th scope="row">Mira</th>
```

Important: Tables are for tabular data, not for designing the overall webpage layout. CSS Flexbox and Grid are used for layouts.

## 9. Semantic HTML elements

Semantic HTML means using elements according to their meaning and purpose.

Instead of using `<div>` for everything, use elements that describe the content.

[10 semantic HTML tags to better structure your website](https://images.openai.com/static-rsc-4/GIZn7T9W70aIdrF4rAn9Dd30Up2X31B_1iH8ssUvFsmAsd43bwioDwhSZ823bmny3LtVpLz_XUdXqsji9ErMxsP2gSqKfnqw6PudrXLZO0i1KZxrRcXRSp_50MjggJmoUMdGLO_IiPp4GZ8zPfoOagkgWEEANIWneU3RtQ57eNA?purpose=inline)

[hartenfeller.dev](https://hartenfeller.dev/blog/underused-semantic-html-tags?utm_source=chatgpt.com)

### Important semantic elements

| Element        | Purpose                                                     |
| -------------- | ----------------------------------------------------------- |
| `<header>`     | Introductory content or header for a page/section           |
| `<nav>`        | Navigation links                                            |
| `<main>`       | Main content of the page                                    |
| `<section>`    | Thematic grouping of content, usually with a heading        |
| `<article>`    | Self-contained content that can stand independently         |
| `<aside>`      | Related or supplementary content                            |
| `<footer>`     | Footer for a page or section                                |
| `<figure>`     | Self-contained media or illustration                        |
| `<figcaption>` | Caption for a figure                                        |
| `<address>`    | Contact information for the relevant person or organisation |
| `<time>`       | Represents a date or time                                   |
| `<details>`    | Expandable disclosure widget                                |
| `<summary>`    | Visible heading for `<details>`                             |

### Example

```
<!DOCTYPE html>
<html lang="en">
<head>
    <title>Technology Blog</title>
</head>

<body>

    <header>
        <h1>Tech Blog</h1>

        <nav>
            <a href="/">Home</a>
            <a href="/about">About</a>
            <a href="/contact">Contact</a>
        </nav>
    </header>

    <main>

        <section>
            <h2>Latest Articles</h2>

            <article>
                <h3>Introduction to AI</h3>
                <p>AI is transforming technology.</p>
            </article>

        </section>

        <aside>
            <h2>Related Articles</h2>
            <p>Explore more topics.</p>
        </aside>

    </main>

    <footer>
        <p>Copyright 2026 Tech Blog</p>
    </footer>

</body>
</html>
```

### Difference between `div`, `section`, and `article`

| Element     | Use                                                 |
| ----------- | --------------------------------------------------- |
| `<div>`     | Generic container without inherent semantic meaning |
| `<section>` | Groups related content around a theme               |
| `<article>` | Independent, self-contained content                 |

Example:

- A blog page can have several `<article>` elements.
- Each article can contain multiple `<section>` elements.
- A `<div>` can be used to group elements when no more meaningful semantic element fits.

Why use semantic HTML?

1. Better accessibility.
2. Easier code maintenance.
3. Better document structure.
4. Helps search engines understand page content.
5. Makes the HTML more meaningful to developers and browsers.

## 10. HTML forms

Forms collect information from users and submit it for processing.

Examples:

- Registration forms
- Login forms
- Feedback forms
- Search forms
- Payment forms

### Basic form structure

```
<form action="/register" method="POST">

    <label for="username">Username:</label>

    <input
        type="text"
        id="username"
        name="username"
        required>

    <button type="submit">Register</button>

</form>
```

Let's understand each part.

| Attribute      | Purpose                                                                 |
| -------------- | ----------------------------------------------------------------------- |
| `action`       | URL where form data is submitted                                        |
| `method`       | HTTP method used for submission                                         |
| `name`         | Key used when submitting the field                                      |
| `id`           | Unique identifier for the element                                       |
| `required`     | Makes the field mandatory                                               |
| `placeholder`  | Displays a hint inside the field                                        |
| `autocomplete` | Controls browser autofill hints                                         |
| `disabled`     | Disables the field                                                      |
| `readonly`     | Prevents editing while keeping the field usable and generally submitted |

### GET vs POST in forms

GET

```
<form action="/search" method="GET">
    <input type="text" name="query">
    <button type="submit">Search</button>
</form>
```

Data is generally sent through the URL query string.

Example:

```
/search?query=html
```

Uses:

- Searching
- Filtering
- Retrieving information

POST

```
<form action="/register" method="POST">
    <input type="text" name="username">
    <button type="submit">Register</button>
</form>
```

Form data is sent in the request body.

Uses:

- Registration
- Submitting data
- Creating resources

Important: POST does not automatically encrypt data. HTTPS is needed to protect data in transit.

### 10.1 Input types

The `<input>` element supports different types of user input.

| Type             | Purpose                         |
| ---------------- | ------------------------------- |
| `text`           | Single-line text                |
| `password`       | Password input                  |
| `email`          | Email address                   |
| `number`         | Numeric input                   |
| `tel`            | Telephone number                |
| `url`            | URL input                       |
| `search`         | Search field                    |
| `date`           | Date picker                     |
| `time`           | Time picker                     |
| `datetime-local` | Local date and time             |
| `month`          | Month and year                  |
| `week`           | Week and year                   |
| `checkbox`       | Multiple independent selections |
| `radio`          | One selection from a group      |
| `file`           | File upload                     |
| `color`          | Colour picker                   |
| `range`          | Slider                          |
| `hidden`         | Hidden form value               |
| `submit`         | Submits the form                |
| `reset`          | Resets form controls            |
| `button`         | Generic button                  |

Examples:

```
<input type="text" placeholder="Enter name">

<input type="email" placeholder="Enter email">

<input type="password" placeholder="Enter password">

<input type="number" min="1" max="100">

<input type="date">

<input type="file">
```

### 10.2 Labels

A label describes the purpose of an input field.

```
<label for="email">Email:</label>

<input type="email" id="email" name="email">
```

The `for` attribute of the label must match the input's `id`.

Why?

- Clicking the label focuses or activates its associated control.
- Screen readers can announce the field's label.
- It improves usability and accessibility.

You can also wrap an input inside a label:

```
<label>
    Email:
    <input type="email" name="email">
</label>
```

### 10.3 Checkboxes

Used when users can select multiple independent options.

```
<p>Select your skills:</p>

<label>
    <input type="checkbox" name="skills" value="python">
    Python
</label>

<label>
    <input type="checkbox" name="skills" value="java">
    Java
</label>

<label>
    <input type="checkbox" name="skills" value="sql">
    SQL
</label>
```

### 10.4 Radio buttons

Used when users should select one option from a group.

```
<p>Select gender:</p>

<label>
    <input type="radio" name="gender" value="male">
    Male
</label>

<label>
    <input type="radio" name="gender" value="female">
    Female
</label>
```

Important: Radio buttons belong to the same selection group when they share the same `name`.

- Checkbox → multiple selections are possible.
- Radio → normally one selection per group.

### 10.5 Select dropdown

Used to select an option from a list.

```
<label for="course">Choose Course:</label>

<select id="course" name="course">

    <option value="">Select a course</option>

    <option value="computer">Computer Engineering</option>

    <option value="mechanical">Mechanical Engineering</option>

    <option value="civil">Civil Engineering</option>

</select>
```

Useful attributes:

- `selected` → selects an option by default.
- `disabled` → disables an option.
- `multiple` → allows multiple selections.
- `required` → makes selection mandatory.

### 10.6 Textarea

Used for multiline text.

```
<label for="message">Message:</label>

<textarea
    id="message"
    name="message"
    rows="5"
    cols="30"
    placeholder="Enter your message">
</textarea>
```

Unlike `<input type="text">`, a textarea can accept multiple lines.

### 10.7 Buttons

Three important button types:

```
<button type="submit">Submit</button>

<button type="reset">Reset</button>

<button type="button">Click Me</button>
```

| Type   | Behaviour                                               |
| ------ | ------------------------------------------------------- |
| submit | Submits the associated form                             |
| reset  | Resets form controls to their initial values            |
| button | Does nothing by default; typically used with JavaScript |

Important Gateway question: A `<button>` inside a form defaults to `type="submit"` if its type is not specified. So specify `type="button"` for a button that should not submit the form.

## 11. Built-in HTML form validation

HTML provides native validation without requiring JavaScript.

### 11.1 `required`

```
<input type="text" required>
```

The user must enter a value before submission.

### 11.2 `min` and `max`

```
<input type="number" min="18" max="60">
```

The number must be within the specified range.

### 11.3 `minlength` and `maxlength`

```
<input type="text" minlength="3" maxlength="20">
```

Controls the minimum and maximum number of characters.

### 11.4 `pattern`

Uses a regular expression to validate the value.

```
<input
    type="text"
    pattern="[A-Za-z]{3,}"
    title="Enter at least three letters">
```

This pattern requires at least three alphabetic characters.

### 11.5 `type="email"`

```
<input type="email" required>
```

The browser checks whether the value has a valid email-like format.

It does not verify that the email address actually exists.

### 11.6 `step`

Controls allowed increments for numeric or date/time inputs.

```
<input type="number" min="0" max="100" step="5">
```

Valid values include 0, 5, 10, 15 and so on.

### 11.7 `novalidate`

Disables the browser's built-in validation when submitting a form.

```
<form novalidate>
    <input type="email" required>
    <button type="submit">Submit</button>
</form>
```

### Complete form example

```
<form action="/register" method="POST">

    <label for="name">Full Name</label>
    <input
        type="text"
        id="name"
        name="name"
        required
        minlength="3">

    <label for="email">Email</label>
    <input
        type="email"
        id="email"
        name="email"
        required>

    <label for="age">Age</label>
    <input
        type="number"
        id="age"
        name="age"
        min="18"
        max="60"
        required>

    <label for="password">Password</label>
    <input
        type="password"
        id="password"
        name="password"
        minlength="8"
        required>

    <button type="submit">Register</button>

</form>
```

Important: HTML validation improves user experience, but it is not a security mechanism. The backend must validate submitted data again because browser validation can be bypassed.

## 12. HTML accessibility basics

Accessibility means designing websites so people with different abilities can use them.

It includes users who:

- Use screen readers.
- Navigate with a keyboard instead of a mouse.
- Have visual impairments.
- Have difficulty distinguishing colours.
- Have motor or cognitive disabilities.

### 12.1 Alt text

```
<img src="chart.png" alt="Sales increased from January to March">
```

Alt text communicates meaningful image content to users who cannot see it.

Rules:

- Describe the important information.
- Be concise and meaningful.
- Avoid unnecessary phrases such as "image of".
- Use `alt=""` for decorative images.

### 12.2 Labels for form fields

Every form control should have an accessible name.

Best practice:

```
<label for="username">Username</label>
<input type="text" id="username" name="username">
```

A placeholder is not a substitute for a label because it disappears when the user enters text.

### 12.3 Keyboard accessibility

A website should be usable without a mouse.

Important keyboard keys:

| Key         | Purpose                                |
| ----------- | -------------------------------------- |
| Tab         | Moves focus forward                    |
| Shift + Tab | Moves focus backward                   |
| Enter       | Activates links and buttons            |
| Space       | Activates buttons and toggles controls |
| Arrow keys  | Navigate within many grouped controls  |

### Focus indicator

The focused element should be visually identifiable.

```
button:focus-visible,
a:focus-visible,
input:focus-visible {
    outline: 3px solid blue;
    outline-offset: 2px;
}
```

`:focus-visible` styles focus when the browser determines that a visible focus indicator is appropriate, commonly during keyboard navigation.

Never remove focus outlines without providing a clear replacement.

### 12.4 Colour contrast

Text should have enough contrast against its background.

WCAG 2.2 AA contrast guidelines generally require:

- Normal text: at least 4.5:1.
- Large text: at least 3:1.
- User-interface components and meaningful graphical objects: generally at least 3:1 against adjacent colours.

Don't communicate important information using colour alone.

For example, instead of displaying only a red error border, also display an error message:

```
<p class="error">
    Error: Email address is required.
</p>
```

### 12.5 Other useful accessibility practices

- Use headings in a logical hierarchy.
- Use semantic HTML.
- Provide meaningful link text instead of "Click here".
- Make buttons and links keyboard accessible.
- Use sufficient font sizes and spacing.
- Associate error messages with the relevant form field.
- Avoid flashing content that may trigger seizures.

# Part 2: CSS

## 13. Introduction to CSS

CSS controls how HTML elements look and how they are positioned.

### CSS syntax

```
selector {
    property: value;
}
```

Example:

```
h1 {
    color: blue;
    font-size: 30px;
}
```

Here:

- `h1` → selector.
- `color` → property.
- `blue` → value.
- `color: blue;` → declaration.

### Three ways to add CSS

1\. Inline CSS

Written directly inside an HTML element.

```
<h1 style="color: red;">Hello</h1>
```

2\. Internal CSS

Written inside the `<style>` element.

```
<head>
    <style>
        h1 {
            color: blue;
        }
    </style>
</head>
```

3\. External CSS

Written in a separate `.css` file.

HTML:

```
<link rel="stylesheet" href="style.css">
```

CSS file:

```
h1 {
    color: green;
}
```

Best practice: External CSS is generally preferred for maintainability, reuse and separation of concerns.

## 14. CSS selectors

A selector identifies which HTML elements should receive a style.

### 14.1 Universal selector

Selects all elements.

```
* {
    margin: 0;
    padding: 0;
}
```

### 14.2 Element selector

Selects all elements of a particular type.

```
p {
    color: blue;
}
```

### 14.3 Class selector

Selects elements with a specific class.

```
<p class="highlight">Important text</p>
```

```
.highlight {
    color: red;
}
```

A class can be reused on multiple elements.

### 14.4 ID selector

Selects the element with a specific ID.

```
<h1 id="heading">Welcome</h1>
```

```
#heading {
    color: green;
}
```

An ID should be unique within the document.

### 14.5 Grouping selector

Applies the same styles to multiple selectors.

```
h1, h2, p {
    font-family: Arial, sans-serif;
}
```

### 14.6 Descendant selector

Selects matching elements anywhere inside another element.

```
div p {
    color: blue;
}
```

This selects all paragraphs inside a `div`, even if they are nested more deeply.

### 14.7 Child selector

Selects only direct children.

```
div > p {
    color: red;
}
```

### 14.8 Adjacent sibling selector

Selects the immediately following sibling.

```
h2 + p {
    color: green;
}
```

### 14.9 General sibling selector

Selects matching siblings that appear after the specified element.

```
h2 ~ p {
    color: purple;
}
```

### 14.10 Attribute selector

Selects elements based on their attributes.

```
input[type="text"] {
    border: 1px solid gray;
}
```

Other examples:

```
a[target="_blank"] {
    color: red;
}

input[required] {
    border-color: orange;
}
```

### 14.11 Pseudo-classes

Select elements based on a state or position.

```
button:hover {
    background-color: blue;
}

input:focus {
    border-color: green;
}

li:first-child {
    color: red;
}

li:last-child {
    color: blue;
}

li:nth-child(2) {
    font-weight: bold;
}
```

Common pseudo-classes:

| Pseudo-class     | Meaning                                            |
| ---------------- | -------------------------------------------------- |
| `:hover`         | Pointer is over the element                        |
| `:active`        | Element is being activated                         |
| `:focus`         | Element has focus                                  |
| `:focus-visible` | Browser determines focus indication is appropriate |
| `:first-child`   | First child                                        |
| `:last-child`    | Last child                                         |
| `:nth-child(n)`  | Child at a particular position or pattern          |
| `:checked`       | Selected checkbox/radio                            |
| `:disabled`      | Disabled form control                              |
| `:required`      | Required form control                              |
| `:not()`         | Excludes elements matching a selector              |

### 14.12 Pseudo-elements

Style a specific part of an element or create generated content.

```
p::first-letter {
    font-size: 30px;
}

p::first-line {
    color: blue;
}

h1::before {
    content: "★ ";
}

h1::after {
    content: " ✓";
}
```

Common pseudo-elements:

- `::before`
- `::after`
- `::first-letter`
- `::first-line`
- `::selection`
- `::placeholder`

Remember:

- Pseudo-class uses `:`.
- Pseudo-element generally uses `::`.

## 15. CSS specificity and cascade

This is one of the most important CSS concepts for interviews.

When multiple CSS rules target the same element, the browser determines which declaration wins using the cascade.

Specificity is one part of that process.

### Specificity priority

For common selectors, the order is:

1. Inline styles.
2. ID selectors.
3. Class, attribute and pseudo-class selectors.
4. Element and pseudo-element selectors.
5. Universal selector contributes no specificity.

Think of specificity as a score with four parts:

```
Inline | ID | Class/Attribute/Pseudo-class | Element/Pseudo-element
```

Example:

| Selector    | Specificity |
| ----------- | ----------- |
| `*`         | 0-0-0-0     |
| `p`         | 0-0-0-1     |
| `.box`      | 0-0-1-0     |
| `#main`     | 0-1-0-0     |
| `div.box`   | 0-0-1-1     |
| `#main p`   | 0-1-0-1     |
| `div.box p` | 0-0-1-2     |

### Example

HTML:

```
<p id="intro" class="text">
    Hello
</p>
```

CSS:

```
p {
    color: blue;
}

.text {
    color: green;
}

#intro {
    color: red;
}
```

Output: Red.

Why?

The ID selector has greater specificity than the class and element selectors.

### What if specificity is equal?

The later applicable declaration generally wins when origin, importance, layer and other cascade conditions are equal.

```
p {
    color: blue;
}

p {
    color: red;
}
```

Output: Red.

### `!important`

```
p {
    color: red !important;
}
```

It marks a declaration as important and changes the cascade priority.

Use it sparingly. It makes CSS harder to override and maintain.

### Important cascade detail

Specificity is not the only thing involved in the cascade. The browser also considers:

- Origin and importance.
- Cascade layers.
- Specificity.
- Scoping proximity where applicable.
- Source order.

For your initial learning, focus on specificity and source order, but remember that `!important` and cascade layers can change the result.

## 16. CSS box model

Very important

Every HTML element is represented as a rectangular box.

The CSS box model has four main parts.

[Box Model Demystified: Margin, Border, Padding & Content - Euron Daily | Euron Community](https://images.openai.com/static-rsc-4/aNhJ5Hv9YEE0LLuFCrQxMEDQ_IPKsc85eHhW6jgkh1zwJmushl24aMsEIfzZ-IBueplaLN4JEmixTRp5c4x0W5xoEd_awQCsUM_soM1dg3XTeGKNvuWjldtPtK3xRPEZG3XYVu6RLJtWWmE16OvBHxsAIugXrPIUK_szeuHn_9k?purpose=inline)

[euron.one](https://euron.one/community/posts/d14457ca-5699-4307-bef0-889364028e4c?utm_source=chatgpt.com)

### 1. Content

The actual content inside the element.

```
.box {
    width: 200px;
    height: 100px;
}
```

### 2. Padding

Space between the content and the border.

```
.box {
    padding: 20px;
}
```

### 3. Border

The boundary surrounding padding and content.

```
.box {
    border: 2px solid black;
}
```

### 4. Margin

Space outside the border, separating the element from other elements.

```
.box {
    margin: 15px;
}
```

### Total width calculation

With the default `content-box` model:

\\[ \text{Total Width} = \text{Content Width} + \text{Padding} + \text{Border} + \text{Margin} \\]

Example:

```
.box {
    width: 200px;
    padding: 20px;
    border: 5px solid black;
    margin: 10px;
}
```

Total horizontal space:

\\[ 200 + 40 + 10 + 20 = 270px \\]

The margin is included in the total space occupied, but it is not part of the element's border box.

### `box-sizing`

There are two important values.

1\. content-box (default)

The specified width applies only to the content.

```
.box {
    box-sizing: content-box;
    width: 200px;
    padding: 20px;
    border: 5px solid;
}
```

Border-box width = 250px.

2\. border-box

The specified width includes content, padding and border.

```
.box {
    box-sizing: border-box;
    width: 200px;
    padding: 20px;
    border: 5px solid;
}
```

Border-box width = 200px.

The content width becomes 150px.

### Common best practice

```
*,
*::before,
*::after {
    box-sizing: border-box;
}
```

This makes sizing more predictable across the page.

### Margin vs padding

| Margin                                | Padding                       |
| ------------------------------------- | ----------------------------- |
| Space outside the border              | Space inside the border       |
| Separates elements                    | Separates content from border |
| Background doesn't extend into margin | Background covers padding     |
| Can have negative values              | Cannot have negative values   |

### Margin collapse

Vertical margins of certain block elements can collapse into one another.

Example:

```
.first {
    margin-bottom: 30px;
}

.second {
    margin-top: 20px;
}
```

In a normal block layout, the vertical gap is generally 30px, not 50px.

Margin collapse does not work the same way in Flexbox or Grid layouts.

## 17. CSS colours and backgrounds

CSS supports several colour formats.

### Named colours

```
h1 {
    color: red;
}
```

### Hexadecimal

```
h1 {
    color: #ff0000;
}
```

Hex format: `#RRGGBB`.

### RGB

```
h1 {
    color: rgb(255, 0, 0);
}
```

RGB represents red, green and blue values, generally from 0 to 255.

### RGBA

```
.box {
    background-color: rgba(255, 0, 0, 0.5);
}
```

The fourth value controls alpha (opacity), from 0 to 1.

### HSL

```
h1 {
    color: hsl(0, 100%, 50%);
}
```

HSL represents:

- Hue
- Saturation
- Lightness

### Background properties

```
body {
    background-color: lightgray;
    background-image: url("background.jpg");
    background-repeat: no-repeat;
    background-position: center;
    background-size: cover;
}
```

Important properties:

| Property                | Purpose                      |
| ----------------------- | ---------------------------- |
| `background-color`      | Background colour            |
| `background-image`      | Background image             |
| `background-repeat`     | Controls repetition          |
| `background-position`   | Controls placement           |
| `background-size`       | Controls image sizing        |
| `background-attachment` | Controls scrolling behaviour |

`cover` fills the container while preserving the image's aspect ratio; some image content may be cropped.

`contain` fits the entire image inside the container; empty space may remain.

## 18. CSS units

CSS units define measurements such as width, height, margin, padding and font size.

There are two broad categories.

### 18.1 Absolute units

| Unit | Meaning    |
| ---- | ---------- |
| `px` | CSS pixel  |
| `cm` | Centimetre |
| `mm` | Millimetre |
| `in` | Inch       |
| `pt` | Point      |
| `pc` | Pica       |

Most common in web development: `px`.

```
.box {
    width: 300px;
}
```

A CSS pixel is a reference pixel, not necessarily one physical screen pixel.

### 18.2 Relative units

| Unit   | Meaning                                                                                                 |
| ------ | ------------------------------------------------------------------------------------------------------- |
| `%`    | Relative to a property-specific reference                                                               |
| `em`   | Relative to the element's font size for font-size; otherwise generally the element's computed font size |
| `rem`  | Relative to the root element's font size                                                                |
| `vw`   | 1% of viewport width                                                                                    |
| `vh`   | 1% of viewport height                                                                                   |
| `vmin` | 1% of smaller viewport dimension                                                                        |
| `vmax` | 1% of larger viewport dimension                                                                         |

### px

```
p {
    font-size: 16px;
}
```

A fixed CSS measurement.

### rem

Assume the root font size is 16px.

```
html {
    font-size: 16px;
}

h1 {
    font-size: 2rem;
}
```

2rem = 32px.

### em

```
.parent {
    font-size: 20px;
}

.child {
    font-size: 2em;
}
```

The child's font size becomes 40px.

Be careful: `em` can compound when nested font sizes are specified in `em`.

### Percentage

```
.container {
    width: 80%;
}
```

The percentage is calculated relative to the relevant containing block for width.

Percentages do not always refer to the parent in every CSS property.

### Viewport units

```
.hero {
    width: 100vw;
    min-height: 100vh;
}
```

- `100vw` = full viewport width.
- `100vh` = viewport height.

On mobile, dynamic viewport units such as `dvh` can help when browser toolbars expand and collapse.

### When to use which unit?

| Requirement                | Suitable unit |
| -------------------------- | ------------- |
| Small borders              | px            |
| Scalable typography        | rem           |
| Component-relative sizing  | em            |
| Responsive container width | %             |
| Full viewport height       | vh / dvh      |
| Full viewport width        | vw            |

## 19. CSS fonts and text styling

CSS provides properties to control how text appears.

### Font family

```
body {
    font-family: Arial, Helvetica, sans-serif;
}
```

The browser tries fonts from left to right.

A generic fallback such as `sans-serif` should generally be included.

### Font size

```
h1 {
    font-size: 32px;
}
```

### Font weight

```
p {
    font-weight: bold;
}
```

Common values:

- `normal` = 400
- `bold` = 700
- `100` to `900` where supported by the font

### Font style

```
p {
    font-style: italic;
}
```

### Text alignment

```
h1 {
    text-align: center;
}
```

Values: `left`, `right`, `center`, `justify`.

### Text decoration

```
a {
    text-decoration: none;
}
```

Other values include `underline`, `overline` and `line-through`.

### Line height

```
p {
    line-height: 1.6;
}
```

Controls the height of a line box and helps readability.

### Letter spacing

```
h1 {
    letter-spacing: 2px;
}
```

### Text transform

```
h1 {
    text-transform: uppercase;
}
```

Other values include `lowercase` and `capitalize`.

### Text shadow

```
h1 {
    text-shadow: 2px 2px 4px gray;
}
```

### Google Fonts

External fonts can be imported using a stylesheet link or CSS `@import`.

For example, in HTML:

```
<link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>

<link
    href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap"
    rel="stylesheet">
```

Then:

```
body {
    font-family: "Roboto", sans-serif;
}
```

# Part 3: CSS Layout

## 20. CSS display property

The `display` property controls how an element participates in layout.

Important values:

| Value          | Behaviour                                                           |
| -------------- | ------------------------------------------------------------------- |
| `block`        | Starts on a new line and generally takes available width            |
| `inline`       | Flows within text and does not accept width/height in the usual way |
| `inline-block` | Flows inline but accepts width and height                           |
| `none`         | Removes the element from layout                                     |
| `flex`         | Creates a Flexbox container                                         |
| `grid`         | Creates a Grid container                                            |

### Block elements

Examples: `<div>`, `<p>`, `<h1>`, `<section>`.

```
div {
    display: block;
}
```

Characteristics:

- Normally starts on a new line.
- Normally takes the available width.
- Width and height can be specified.

### Inline elements

Examples: `<span>`, `<a>`, `<strong>`, `<em>`.

```
span {
    display: inline;
}
```

Characteristics:

- Flows within the surrounding text.
- Does not normally start a new line.
- Width and height do not apply in the normal inline formatting model.

### Inline-block

```
button {
    display: inline-block;
    width: 120px;
    height: 40px;
}
```

Characteristics:

- Can sit alongside other inline-level content.
- Supports width and height.
- Supports vertical padding and margins.

### Display none vs visibility hidden

```
.box1 {
    display: none;
}

.box2 {
    visibility: hidden;
}
```

| `display: none`                         | `visibility: hidden`                     |
| --------------------------------------- | ---------------------------------------- |
| Removed from layout                     | Space is retained                        |
| Not displayed                           | Not displayed                            |
| Usually removed from accessibility tree | Generally hidden from accessibility tree |

Don't confuse either with `opacity: 0`, which makes an element transparent but leaves it in layout and can leave it interactive.

## 21. CSS positioning

The `position` property controls how an element is positioned.

### 21.1 Static

Default positioning.

```
.box {
    position: static;
}
```

- Follows normal document flow.
- `top`, `right`, `bottom` and `left` do not reposition it.

### 21.2 Relative

```
.box {
    position: relative;
    top: 10px;
    left: 20px;
}
```

- Remains in normal document flow.
- Moves relative to its original position.
- Its original space is retained.
- Can establish a positioning reference for absolutely positioned descendants.

### 21.3 Absolute

```
.parent {
    position: relative;
}

.child {
    position: absolute;
    top: 10px;
    right: 10px;
}
```

- Removed from normal document flow.
- Positioned relative to its nearest positioned ancestor.
- If there is no suitable positioned ancestor, it uses the initial containing block.

### 21.4 Fixed

```
.navbar {
    position: fixed;
    top: 0;
    width: 100%;
}
```

- Positioned relative to the viewport in the usual case.
- Does not occupy its original space in normal flow.
- Remains in place while scrolling.

Some ancestor properties, such as transforms, can establish a different containing block for fixed descendants.

### 21.5 Sticky

```
.header {
    position: sticky;
    top: 0;
}
```

- Behaves like relative positioning until it reaches its scrolling threshold.
- Then sticks within its scroll container.
- Needs a threshold such as `top: 0` to become sticky in that direction.

### Comparison

| Position | Normal flow?        | Main behaviour                          |
| -------- | ------------------- | --------------------------------------- |
| static   | Yes                 | Default                                 |
| relative | Yes                 | Offset from original position           |
| absolute | No                  | Positioned relative to containing block |
| fixed    | No                  | Usually fixed relative to viewport      |
| sticky   | Yes, until sticking | Sticks during scrolling                 |

### 21.6 Z-index

Controls stacking order when elements overlap.

```
.box1 {
    position: relative;
    z-index: 1;
}

.box2 {
    position: relative;
    z-index: 2;
}
```

The second box is generally painted above the first when both are in the same stacking context and other painting rules don't override that order.

Important: `z-index` is not a universal global ranking. Stacking contexts matter. Properties such as `transform`, positioned elements with certain `z-index` values, and `opacity` below 1 can create stacking contexts.

## 22. Flexbox

Very important

Flexbox (Flexible Box Layout) is a one-dimensional layout system.

It is mainly used to arrange elements in:

- A row (horizontal direction).
- A column (vertical direction).

Use Flexbox when arranging items along one main axis.

[- Exclusive Addons](https://images.openai.com/static-rsc-4/MSDaCH5obvN7BpyLXNoDqB5gf8bDgZNW_98sCnI72FyWra2aJ_YkCSDWVMTfscj7D-OsUe7OQwfbbDVjFR4O6LFox1VI-e6hD04ef3YlQsnehOP3EZW7q9yfCVbImNJi_ZrG5yNhOz-8UyKcmYnBqefdFeRrKIwH6niLOEVd9u0?purpose=inline)

[exclusiveaddons.com](https://exclusiveaddons.com/flexible-container/?utm_source=chatgpt.com)

### 22.1 Creating a Flexbox container

HTML:

```
<div class="container">
    <div class="item">One</div>
    <div class="item">Two</div>
    <div class="item">Three</div>
</div>
```

CSS:

```
.container {
    display: flex;
}
```

The direct children become flex items.

By default, the items are arranged in a row.

### 22.2 Flex direction

```
.container {
    display: flex;
    flex-direction: row;
}
```

Possible values:

| Value            | Behaviour                                      |
| ---------------- | ---------------------------------------------- |
| `row`            | Left to right in the default writing direction |
| `row-reverse`    | Reverse row direction                          |
| `column`         | Top to bottom                                  |
| `column-reverse` | Bottom to top                                  |

Example:

```
.container {
    display: flex;
    flex-direction: column;
}
```

Now items appear vertically.

### 22.3 Main axis and cross axis

This is essential to understand Flexbox.

- Main axis is determined by `flex-direction`.
- Cross axis is perpendicular to the main axis.

If `flex-direction: row`:

- Main axis = horizontal.
- Cross axis = vertical.

If `flex-direction: column`:

- Main axis = vertical.
- Cross axis = horizontal.

### 22.4 Justify-content

Controls alignment along the main axis.

```
.container {
    display: flex;
    justify-content: center;
}
```

Important values:

| Value           | Behaviour                                   |
| --------------- | ------------------------------------------- |
| `flex-start`    | Items at the start                          |
| `flex-end`      | Items at the end                            |
| `center`        | Items in the centre                         |
| `space-between` | Equal space between items; no outer space   |
| `space-around`  | Space around each item                      |
| `space-evenly`  | Equal spacing between items and outer edges |

[Flexbox Decoded: Complete Illustrated Guide | by Tapajyoti Bose | Medium](https://images.openai.com/static-rsc-4/JXHfYggQUYZR_uufCY8MPjvkLm2TFaAziGA3sCwxpyVIj_ANWraoHH0XvrtCDwtOgp-mvxxs02jBofNqXeYJpUga-uTGHO1s0w2gcg-SfOXAdiYbJm0O8dPIANKUSfjlpqgt2RpVYh9YYnP30VDXvRmJ0j1SMLQO6lJWSAkgE3U?purpose=inline)

[tapajyoti-bose.medium.com](https://tapajyoti-bose.medium.com/flexbox-decoded-complete-illustrated-guide-569940a2a8d7?utm_source=chatgpt.com)

### 22.5 Align-items

Controls alignment along the cross axis.

```
.container {
    display: flex;
    align-items: center;
}
```

Common values:

- `stretch`
- `flex-start`
- `flex-end`
- `center`
- `baseline`

Example: With `flex-direction: row`, `align-items: center` vertically centres the items.

### 22.6 Align-content

Controls the distribution of multiple flex lines along the cross axis when there is extra space.

It is useful when:

- `flex-wrap: wrap` is enabled.
- There are multiple flex lines.
- The container has extra cross-axis space.

It does not replace `align-items`.

### 22.7 Flex-wrap

Controls whether items stay on one line or move onto additional lines.

```
.container {
    display: flex;
    flex-wrap: wrap;
}
```

Values:

- `nowrap` – Default; one line.
- `wrap` – Items can move to additional lines.
- `wrap-reverse` – Additional lines are reversed along the cross axis.

### 22.8 Gap

Controls the spacing between items.

```
.container {
    display: flex;
    gap: 20px;
}
```

You can also use:

```
.container {
    row-gap: 10px;
    column-gap: 20px;
}
```

### 22.9 Flex item properties

flex-grow

Controls how flex items can grow to consume positive free space.

```
.item1 {
    flex-grow: 1;
}

.item2 {
    flex-grow: 2;
}
```

If the available extra space is distributed according to these grow factors, the second item receives twice the share of the first.

flex-shrink

Controls how flex items shrink when there is insufficient space.

```
.item {
    flex-shrink: 1;
}
```

Default is 1.

Setting it to 0 prevents the item from shrinking due to the flex shrink algorithm.

flex-basis

Sets the initial main size used by the flex layout algorithm.

```
.item {
    flex-basis: 200px;
}
```

flex shorthand

```
.item {
    flex: 1;
}
```

This is a shorthand for grow, shrink and basis. The common `flex: 1` form distributes available space among items, using a zero basis in the standard expansion.

### 22.10 Align-self

Overrides the container's `align-items` value for an individual item.

```
.item2 {
    align-self: flex-end;
}
```

### 22.11 Complete Flexbox example

```
<div class="container">
    <div class="card">Card 1</div>
    <div class="card">Card 2</div>
    <div class="card">Card 3</div>
</div>
```

```
.container {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    flex-wrap: wrap;
    gap: 20px;
}

.card {
    flex: 1 1 200px;
    padding: 20px;
    background-color: lightblue;
}
```

This creates a flexible row of cards that can wrap when the available width is insufficient.

### 22.12 Common Flexbox question

How do you centre an element horizontally and vertically?

```
.container {
    display: flex;
    justify-content: center;
    align-items: center;
    min-height: 100vh;
}
```

This centres the child along both axes when the container has sufficient height.

## 23. CSS Grid

Very important

CSS Grid is a two-dimensional layout system.

It allows you to arrange items in both rows and columns.

Use Grid for:

- Dashboard layouts.
- Product grids.
- Image galleries.
- Page-level layouts.
- Complex row-and-column structures.

[Css Grid-Container at Arthur Ritchie blog](https://images.openai.com/static-rsc-4/SYPqmWl4QmLSrWo5EPGNKcrC6RexX_-jgWpPAKkEnahew7QDqUOVWAlez37JTZxqdLhPGaELBVxoWpbcFkLxOGf0rhA-gr3aw_HUghKrchYd3_sIFM4bUqMDnhfTY15SgBHDLSNHbXGOQgcSQa1VefdxQFn03QA0_serR458Xsw?purpose=inline)

[storage.googleapis.com](https://storage.googleapis.com/dqhrwafautafoe/css-grid-container.html?utm_source=chatgpt.com)

### 23.1 Creating a Grid container

HTML:

```
<div class="container">
    <div>One</div>
    <div>Two</div>
    <div>Three</div>
    <div>Four</div>
</div>
```

CSS:

```
.container {
    display: grid;
}
```

This creates a grid container. Without explicit track definitions, the browser creates implicit rows for the items.

### 23.2 Grid-template-columns

Defines the columns.

```
.container {
    display: grid;
    grid-template-columns: 200px 200px 200px;
}
```

Creates three columns, each 200px wide.

You can use fractional units:

```
.container {
    display: grid;
    grid-template-columns: 1fr 1fr 1fr;
}
```

`fr` represents a fraction of the available grid space after accounting for relevant fixed sizes and gaps.

### 23.3 Repeat function

Instead of writing repeated values:

```
.container {
    grid-template-columns: 1fr 1fr 1fr;
}
```

You can write:

```
.container {
    grid-template-columns: repeat(3, 1fr);
}
```

### 23.4 Grid-template-rows

Defines the row sizes.

```
.container {
    display: grid;
    grid-template-rows: 100px 200px;
}
```

### 23.5 Gap

Controls spacing between rows and columns.

```
.container {
    display: grid;
    gap: 20px;
}
```

Or:

```
.container {
    row-gap: 10px;
    column-gap: 20px;
}
```

### 23.6 Grid-column and grid-row

Controls how many grid tracks an item spans.

```
.item1 {
    grid-column: 1 / 3;
}
```

This makes the item span from grid line 1 to grid line 3, covering two columns.

Similarly:

```
.item2 {
    grid-row: 1 / 3;
}
```

This spans two rows.

### 23.7 Grid-template-areas

Allows you to name layout regions.

```
.container {
    display: grid;

    grid-template-areas:
        "header header"
        "sidebar main"
        "footer footer";

    grid-template-columns: 200px 1fr;
}

.header {
    grid-area: header;
}

.sidebar {
    grid-area: sidebar;
}

.main {
    grid-area: main;
}

.footer {
    grid-area: footer;
}
```

This creates a page structure with:

- Header across the top.
- Sidebar and main content in the middle.
- Footer across the bottom.

### 23.8 Responsive Grid using auto-fit and minmax

One of the most useful Grid patterns:

```
.container {
    display: grid;
    grid-template-columns:
        repeat(auto-fit, minmax(200px, 1fr));

    gap: 20px;
}
```

Let's understand:

- `repeat()` repeats the column definition.
- `auto-fit` fits as many columns as possible.
- `minmax(200px, 1fr)` gives each column a minimum width of 200px and allows it to grow.

The layout automatically adjusts the number of columns according to available space.

### 23.9 Auto-fill vs auto-fit

Both try to create as many tracks as possible.

- `auto-fill` retains empty tracks where space permits.
- `auto-fit` collapses empty tracks so existing items can expand.

### 23.10 Justify-items and align-items in Grid

```
.container {
    display: grid;
    justify-items: center;
    align-items: center;
}
```

- `justify-items` controls alignment inside grid areas along the inline axis.
- `align-items` controls alignment inside grid areas along the block axis.

`justify-content` and `align-content` distribute the grid itself within its container when there is extra space.

### Complete Grid example

```
<div class="grid-container">
    <div class="card">Card 1</div>
    <div class="card">Card 2</div>
    <div class="card">Card 3</div>
    <div class="card">Card 4</div>
</div>
```

```
.grid-container {
    display: grid;
    grid-template-columns: repeat(2, 1fr);
    gap: 20px;
}

.card {
    padding: 20px;
    background-color: lightblue;
}
```

This produces two columns.

## 24. Flexbox vs Grid

This distinction is very commonly tested.

[Understanding Grid System in CSS: A Comprehensive Guide](https://images.openai.com/static-rsc-4/2S1gH9wkSDa1wjhF-dTkJ_mZ_jUnqzQwU60QKOPGjfc4mhk3UmS1fGYEASz-MZVIlDsftD7xM8oyhZwUp5qg6foryrqsNLFM6193-EnRLEuBWcX71TGgUlrf4WsMvrNScchb_7BQ4reQyzP1I_y9BUwjmPdoRjHp0GxiZMcNV44?purpose=inline)

[tutorjoes.in](https://www.tutorjoes.in/css_tutorial/grid_introduction_in_css?utm_source=chatgpt.com)

| Flexbox                              | Grid                                     |
| ------------------------------------ | ---------------------------------------- |
| One-dimensional layout               | Two-dimensional layout                   |
| Works mainly along one axis          | Works with rows and columns              |
| Content-driven arrangement is common | Track-based layout is common             |
| Useful for navigation bars           | Useful for dashboards                    |
| Useful for aligning buttons          | Useful for card galleries                |
| `justify-content` and `align-items`  | Grid track and item alignment properties |

Can Flexbox and Grid be used together?

Yes! They are often combined.

Example:

- Grid for the overall page layout.
- Flexbox for arranging navigation links inside the header.

Neither replaces the other.

## 25. Responsive web design

Responsive design means building websites that adapt to different screen sizes and devices.

A responsive website should work well on:

- Desktop computers.
- Laptops.
- Tablets.
- Mobile phones.

A page should not require horizontal scrolling for ordinary content at common screen sizes.

### 25.1 Viewport meta tag

Always include:

```
<meta name="viewport"
      content="width=device-width, initial-scale=1.0">
```

This helps browsers use the actual device width as the layout viewport.

### 25.2 Media queries

Media queries apply CSS based on device or viewport conditions.

Syntax:

```
@media (condition) {
    selector {
        property: value;
    }
}
```

Example:

```
.container {
    display: flex;
    gap: 20px;
}

@media (max-width: 768px) {
    .container {
        flex-direction: column;
    }
}
```

What happens?

- Above 768px: items appear in a row.
- At 768px or below: items appear in a column.

### 25.3 Common media query conditions

Maximum width

```
@media (max-width: 600px) {
    body {
        font-size: 14px;
    }
}
```

Applies when the viewport width is 600px or less.

Minimum width

```
@media (min-width: 768px) {
    .container {
        width: 80%;
    }
}
```

Applies when the viewport width is at least 768px.

Range

```
@media (min-width: 600px) and (max-width: 900px) {
    .container {
        width: 90%;
    }
}
```

### 25.4 Mobile-first design

Mobile-first means starting with styles for smaller screens and progressively adding layout changes for larger screens.

```
.container {
    display: flex;
    flex-direction: column;
}

@media (min-width: 768px) {
    .container {
        flex-direction: row;
    }
}
```

Why is it useful?

- Prioritises essential content.
- Encourages simpler layouts.
- Reduces unnecessary styling.
- Works naturally with progressively larger screens.

### 25.5 Responsive images

```
img {
    max-width: 100%;
    height: auto;
}
```

This prevents images from exceeding their containing element's width.

### 25.6 Fluid layouts

Instead of fixed widths:

```
.container {
    width: 1000px;
}
```

Use flexible widths:

```
.container {
    width: 90%;
    max-width: 1200px;
    margin: 0 auto;
}
```

This allows the container to shrink on smaller screens while limiting its maximum width.

### 25.7 Responsive typography

You can use `clamp()` to make text scale within limits.

```
h1 {
    font-size: clamp(24px, 4vw, 48px);
}
```

The three values mean:

- Minimum font size = 24px.
- Preferred responsive size = 4vw.
- Maximum font size = 48px.

This avoids text becoming excessively small or large.

### 25.8 Example: Complete responsive card layout

```
<div class="cards">

    <div class="card">
        <h2>HTML</h2>
        <p>Structure of a webpage.</p>
    </div>

    <div class="card">
        <h2>CSS</h2>
        <p>Style of a webpage.</p>
    </div>

    <div class="card">
        <h2>JavaScript</h2>
        <p>Behaviour of a webpage.</p>
    </div>

</div>
```

```
* {
    box-sizing: border-box;
}

.cards {
    display: grid;
    grid-template-columns: 1fr;
    gap: 20px;
    padding: 20px;
}

.card {
    background: lightblue;
    padding: 20px;
    border-radius: 10px;
}

@media (min-width: 600px) {
    .cards {
        grid-template-columns: repeat(2, 1fr);
    }
}

@media (min-width: 900px) {
    .cards {
        grid-template-columns: repeat(3, 1fr);
    }
}
```

Result:

- Mobile: one column.
- Tablet: two columns.
- Desktop: three columns.

## 26. Other useful CSS properties

These aren't the main focus of your listed syllabus, but they help you understand real-world CSS and practical questions.

### Borders

```
.box {
    border: 2px solid black;
    border-radius: 10px;
}
```

### Width and height

```
.box {
    width: 300px;
    height: 200px;
    min-width: 200px;
    max-width: 500px;
    min-height: 100px;
}
```

### Overflow

Controls what happens when content exceeds the element's available area.

```
.box {
    overflow: auto;
}
```

Values:

- `visible` – Default; content may overflow.
- `hidden` – Clips overflowing content.
- `scroll` – Provides scrolling.
- `auto` – Adds scrolling when needed.

### Opacity

```
.box {
    opacity: 0.5;
}
```

Controls the transparency of the element and its rendered contents.

### Box shadow

```
.card {
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.2);
}
```

### Transitions

```
button {
    background-color: blue;
    transition: background-color 0.3s ease;
}

button:hover {
    background-color: green;
}
```

Creates a smooth transition when the background colour changes.

### CSS variables

CSS custom properties let you reuse values.

```
:root {
    --primary-color: blue;
    --spacing: 20px;
}

button {
    background-color: var(--primary-color);
    padding: var(--spacing);
}
```

Useful for maintaining consistent themes and spacing.

# Part 4: Additional important concepts and practical understanding

## 27. More HTML form elements and attributes

These are useful in practical development and interview questions.

### 27.1 Fieldset and legend

`<fieldset>` groups related form controls, and `<legend>` provides a caption for that group.

```
<form>
    <fieldset>
        <legend>Personal Information</legend>

        <label for="name">Name:</label>
        <input type="text" id="name" name="name">

        <label for="email">Email:</label>
        <input type="email" id="email" name="email">
    </fieldset>
</form>
```

This is particularly useful for accessibility and organising long forms.

### 27.2 Datalist

Provides suggestions while allowing users to enter their own values.

```
<label for="browser">Choose browser:</label>

<input list="browsers" id="browser" name="browser">

<datalist id="browsers">
    <option value="Chrome">
    <option value="Firefox">
    <option value="Edge">
</datalist>
```

Difference:

- `<select>` generally restricts users to listed options.
- `<datalist>` suggests options but allows other values.

### 27.3 Output

Represents the result of a calculation or user action.

```
<output name="result">0</output>
```

### 27.4 Form encoding and file uploads

When uploading files, you commonly need:

```
<form
    action="/upload"
    method="POST"
    enctype="multipart/form-data">

    <input type="file" name="document">

    <button type="submit">Upload</button>
</form>
```

`enctype` determines how form data is encoded.

| Encoding                            | Purpose                                                             |
| ----------------------------------- | ------------------------------------------------------------------- |
| `application/x-www-form-urlencoded` | Default form encoding                                               |
| `multipart/form-data`               | Used for file uploads                                               |
| `text/plain`                        | Plain-text encoding; rarely used for normal application submissions |

The file input may also use:

```
<input type="file" accept=".pdf,.jpg,.png">
```

`accept` guides the file picker but does not guarantee that the uploaded file is safe. Validate files on the server.

## 28. Flexbox and Grid — extra properties worth knowing

### Flexbox shorthand: `flex-flow`

Combines `flex-direction` and `flex-wrap`.

```
.container {
    display: flex;
    flex-flow: row wrap;
}
```

Equivalent to:

```
.container {
    flex-direction: row;
    flex-wrap: wrap;
}
```

### Flexbox item order

```
.item1 {
    order: 2;
}

.item2 {
    order: 1;
}
```

Controls the visual ordering of flex items. Default order is 0.

Be careful: visual ordering does not necessarily change the document's DOM order or keyboard navigation order.

### Grid implicit rows

Sometimes the number of items exceeds the explicitly defined grid tracks.

```
.container {
    display: grid;
    grid-template-columns: repeat(3, 1fr);
    grid-auto-rows: 100px;
}
```

`grid-auto-rows` controls the size of implicitly created rows.

### Grid auto-placement

```
.container {
    display: grid;
    grid-auto-flow: row;
}
```

Controls how automatically placed items are inserted into the grid.

Common values:

- `row`
- `column`
- `row dense`
- `column dense`

# Part 5: Common Gateway interview questions

These are the distinctions I particularly want you to remember.

| Question                                                           | Correct understanding                                                                          |
| ------------------------------------------------------------------ | ---------------------------------------------------------------------------------------------- |
| Is HTML a programming language?                                    | No, it is a markup language.                                                                   |
| Is CSS a programming language?                                     | No, it is a stylesheet language.                                                               |
| Difference between head and body?                                  | Metadata vs visible page content.                                                              |
| Difference between `div` and `section`?                            | Generic container vs thematic content grouping.                                                |
| Difference between `id` and `class`?                               | Unique identifier vs reusable grouping.                                                        |
| Difference between `strong` and `b`?                               | Importance vs stylistic attention.                                                             |
| Difference between `a` and `button`?                               | Navigation vs action.                                                                          |
| Difference between checkbox and radio?                             | Multiple selections vs one selection per group.                                                |
| Difference between GET and POST?                                   | URL query parameters commonly carry GET data; POST submits a request body.                     |
| Does HTML validation replace backend validation?                   | No.                                                                                            |
| What is the purpose of alt text?                                   | Text alternative for images.                                                                   |
| What is CSS specificity?                                           | Determines priority among competing declarations within the cascade.                           |
| What is the CSS box model?                                         | Content, padding, border and margin.                                                           |
| What is `box-sizing: border-box`?                                  | Width and height include padding and border.                                                   |
| Difference between `em` and `rem`?                                 | Element-relative font sizing vs root-relative font sizing.                                     |
| Difference between relative and absolute positioning?              | Relative retains its original flow space; absolute is removed from normal flow.                |
| Difference between fixed and sticky?                               | Fixed is positioned independently of normal flow; sticky participates in flow until it sticks. |
| Difference between Flexbox and Grid?                               | One-dimensional vs two-dimensional layout.                                                     |
| Difference between `justify-content` and `align-items` in Flexbox? | Main-axis vs cross-axis alignment.                                                             |
| What is a media query?                                             | Applies CSS depending on conditions such as viewport width.                                    |
| What is mobile-first design?                                       | Start with small-screen styles and progressively enhance for larger screens.                   |

# Part 6: One-page revision sheet

This is the part to revisit before your test.

HTML essentials

- `<!DOCTYPE html>` – HTML5 declaration.
- `<head>` – Metadata and resource links.
- `<body>` – Visible content.
- `<header>`, `<nav>`, `<main>`, `<section>`, `<footer>` – Semantic structure.
- `<a>` – Navigation.
- `<img>` – Image; provide meaningful `alt`.
- `<table>` – Tabular data.
- `<form>` – User input and submission.
- `<label for="">` – Connects label to input ID.
- `required`, `min`, `max`, `pattern` – Built-in validation.

Accessibility essentials

- Meaningful alt text.
- Label every form control.
- Keyboard navigation.
- Visible focus indicator.
- Adequate colour contrast.
- Logical heading structure.

CSS essentials

- Selector → property → value.
- Selectors: element, class, ID, attribute, descendant, child, pseudo-class and pseudo-element.
- Specificity: inline, ID, class, element (with cascade rules).
- Box model: content → padding → border → margin.
- `border-box` includes padding and border in the specified dimensions.
- `rem` → root font size; `em` → element-relative sizing.
- `px`, `%`, `vw`, `vh` → sizing units.

Layout essentials

- `display: flex` → one-dimensional layout.
- `display: grid` → two-dimensional layout.
- `justify-content` → main-axis alignment in Flexbox.
- `align-items` → cross-axis alignment in Flexbox.
- `flex-wrap` → allows flex items to wrap.
- `grid-template-columns` → defines columns.
- `gap` → spacing between items.
- `position: relative/absolute/fixed/sticky` → positioning.
- `@media` → responsive styles.
- `minmax()` and `auto-fit` → responsive Grid layouts.




// Console.WriteLine("Hello, World!");


// Using value types, reference types, constants, var, and nullables
// const string Platform = "Coderbyte";
// var score = 95; 
// double runtimeSeconds = 4.52;
// int? bonusPoints = null;

// string[] statusMessages = { "Passed", "Failed", "Pending" };

// Console.WriteLine($"Platform: {Platform}");
// Console.WriteLine($"Your Score: {score}");
// Console.WriteLine($"Time Taken: {runtimeSeconds} seconds");
// Console.WriteLine($"Bonus Points Active: {bonusPoints.HasValue}");
// Console.WriteLine($"Test Result Status: {statusMessages[0]}");


//Type conversion

Console.WriteLine("=== TYPE CONVERSION PRACTICE PROGRAM ===");


// 1. IMPLICIT CASTING (Automatic)
int normalInt = 500;
long giantLong = normalInt; // Automatically upgrades to a larger memory box
double precisionDouble = normalInt; // Automatically upgrades to include decimals

Console.WriteLine($"Int value: {normalInt}");
Console.WriteLine($"Automatically converted to Long: {giantLong}");
Console.WriteLine($"Automatically converted to Double: {precisionDouble}");



// 2. EXPLICIT CASTING (Forced - Potential Data Loss)
Console.WriteLine("\n--- 2. Explicit Casting ---");
double productPrice = 99.75;
// We force the double into an int using (int)
int dollarAmount = (int)productPrice; 

Console.WriteLine($"Original price: {productPrice}");
Console.WriteLine($"After (int) cast: {dollarAmount} (Notice the .75 was completely cut off!)");



// 3. PARSE (Strict Text-to-Number)
Console.WriteLine("\n--- 3. Using Parse() ---");
string itemsInCartText = "12";
int itemsCount = int.Parse(itemsInCartText);

Console.WriteLine($"Parsed string \"{itemsInCartText}\" into integer: {itemsCount}");
// WARNING: If you try int.Parse("abc"), the program will crash here!



// 4. TRYPARSE (The Bulletproof Safe Way)
Console.Write("Enter your birth year (try numbers or typos): ");
string userInput = Console.ReadLine() ?? "";

// TryParse returns a true/false and outputs the number safely into 'validYear'
if (int.TryParse(userInput, out int validYear))
{
    int currentYear = DateTime.Now.Year;
    int calculatedAge = currentYear - validYear;
    Console.WriteLine($"Success! You are roughly {calculatedAge} years old.");
}
else
{
    Console.WriteLine($"Conversion Failed! \"{userInput}\" is not a valid number. (No crash!)");
}


// 5. CONVERT (The Universal Tool)
Console.WriteLine("\n--- 5. Using Convert ---");
string nullString = null;

// int crashTest = int.Parse(nullString); // 🛑 This line would crash the app
int safeDefault = Convert.ToInt32(nullString); // ✅ Safely returns 0

double rawRating = 4.67;
int roundedRating = Convert.ToInt32(rawRating); // Rounds to the nearest whole number

Console.WriteLine($"Convert handling null: {safeDefault}");
Console.WriteLine($"Convert rounding {rawRating}: {roundedRating}");


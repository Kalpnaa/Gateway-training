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

// Console.WriteLine("=== TYPE CONVERSION PRACTICE PROGRAM ===");


// // 1. IMPLICIT CASTING (Automatic)
// int normalInt = 500;
// long giantLong = normalInt; // Automatically upgrades to a larger memory box
// double precisionDouble = normalInt; // Automatically upgrades to include decimals

// Console.WriteLine($"Int value: {normalInt}");
// Console.WriteLine($"Automatically converted to Long: {giantLong}");
// Console.WriteLine($"Automatically converted to Double: {precisionDouble}");



// // 2. EXPLICIT CASTING (Forced - Potential Data Loss)
// Console.WriteLine("\n--- 2. Explicit Casting ---");
// double productPrice = 99.75;
// // We force the double into an int using (int)
// int dollarAmount = (int)productPrice; 

// Console.WriteLine($"Original price: {productPrice}");
// Console.WriteLine($"After (int) cast: {dollarAmount} (Notice the .75 was completely cut off!)");



// // 3. PARSE (Strict Text-to-Number)
// Console.WriteLine("\n--- 3. Using Parse() ---");
// string itemsInCartText = "12";
// int itemsCount = int.Parse(itemsInCartText);

// Console.WriteLine($"Parsed string \"{itemsInCartText}\" into integer: {itemsCount}");
// // WARNING: If you try int.Parse("abc"), the program will crash here!



// // 4. TRYPARSE (The Bulletproof Safe Way)
// Console.Write("Enter your birth year (try numbers or typos): ");
// string userInput = Console.ReadLine() ?? "";

// // TryParse returns a true/false and outputs the number safely into 'validYear'
// if (int.TryParse(userInput, out int validYear))
// {
//     int currentYear = DateTime.Now.Year;
//     int calculatedAge = currentYear - validYear;
//     Console.WriteLine($"Success! You are roughly {calculatedAge} years old.");
// }
// else
// {
//     Console.WriteLine($"Conversion Failed! \"{userInput}\" is not a valid number. (No crash!)");
// }


// // 5. CONVERT (The Universal Tool)
// Console.WriteLine("\n--- 5. Using Convert ---");
// string nullString = null;

// // int crashTest = int.Parse(nullString); // 🛑 This line would crash the app
// int safeDefault = Convert.ToInt32(nullString); // ✅ Safely returns 0

// double rawRating = 4.67;
// int roundedRating = Convert.ToInt32(rawRating); // Rounds to the nearest whole number

// Console.WriteLine($"Convert handling null: {safeDefault}");
// Console.WriteLine($"Convert rounding {rawRating}: {roundedRating}");


// var grade = 10 switch
// {
//     10 => "excellent",
//     20 => "good",
//     _ => "dont know"
// };

// Console.WriteLine($"answer {grade}");

// int []numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// foreach (int num in numbers)
// {
//     // Skip even numbers
//     if (num % 2 == 0)
//     {
//         continue;
//     }

//     // Stop completely if the number is greater than 7
//     if (num > 7)
//     {
//         break;
//     }

//     Console.WriteLine($"Found odd number: {num}");
// }

// Console.WriteLine("=== METHODS PRACTICE PROGRAM ===");

// // 1. Testing Overloading
// Console.WriteLine($"Area of 4x5 rectangle: {GeometryUtils.CalculateArea(4, 5)}");
// Console.WriteLine($"Area of 5x5 square: {GeometryUtils.CalculateArea(5)}");

// // 2. Testing Optional and Named parameters
// Console.WriteLine("\n--- User Setup ---");
// GeometryUtils.CreateUser("Alex"); 
// GeometryUtils.CreateUser("Samantha", systemRole: "Moderator"); 

// // 3. Testing ref modifier
// int energyLevel = 50;
// GeometryUtils.BoostEnergy(ref energyLevel);
// Console.WriteLine($"\nBoosted Energy Level: {energyLevel}");

// Console.WriteLine("=================================");


// // ========================================================
// // ZONE 2: TYPE DECLARATIONS (Must be completely at the bottom)
// // ========================================================

// public static class GeometryUtils
// {
//     // Version 1: For a rectangle (takes two numbers)
//     public static int CalculateArea(int width, int height) => width * height;

//     // Version 2: For a square (overloaded - takes one number)
//     public static int CalculateArea(int side) => side * side;

//     public static void CreateUser(string name, int age = 20, string systemRole = "Standard")
//     {
//         Console.WriteLine($"User: {name} | Age: {age} | Permission: {systemRole}");
//     }

//     public static void BoostEnergy(ref int energy)
//     {
//         energy += 25;
//     }
// }


// string txt = " kal_pna_sha_rma ";
// Console.WriteLine(txt);

// string cleantxt = txt.Trim();
// string []splitxt = txt.Split('_');

// Console.WriteLine(cleantxt);
// Console.WriteLine(splitxt[2]);

//Array
// string []fruits = {"apple","banan","kiwi"};


// Console.WriteLine(fruits[0]);
// Console.WriteLine(fruits[1]);
// Console.WriteLine(fruits[2]);

// List<string> shoppingList = new List<string>();
// shoppingList.Add("Milk");
// shoppingList.Add("Eggs");
// shoppingList.Add("Bread");

// shoppingList.Remove("Eggs"); // Automatically updates the indices

// // Lists use Count (not Length)
// Console.WriteLine($"Items to buy: {shoppingList.Count}"); 
// Console.WriteLine($"First item: {shoppingList[0]}");

// Dictionary<string, decimal> productCatalog = new Dictionary<string, decimal>();

// productCatalog.Add("LAPTOP101", 999.99m);
// productCatalog.Add("MOUSE02", 25.50m);

// // Quick checking if a key already exists
// if (productCatalog.ContainsKey("MOUSE02"))
// {
//     // Fast retrieval using the key box
//     Console.WriteLine($"Mouse Price: ${productCatalog["MOUSE02"]}");
// }

// HashSet<int> id = new HashSet<int>{101,102};
// id.Add(101);
// Console.WriteLine($"{id.Count}");

// string[] rawLogs = { "Alice", "Bob", "Alice", "Charlie", "Bob", "Alice" };

// // 1. Let's filter unique visitors using a HashSet
// HashSet<string> uniqueVisitors = new HashSet<string>(rawLogs);

// Console.WriteLine("\n--- Unique Visitors Identified ---");
// foreach (string visitor in uniqueVisitors)
// {
//     Console.WriteLine($"-> {visitor}");
// }

// // 2. Let's tally frequency counts using a Dictionary
// Dictionary<string, int> visitCounts = new Dictionary<string, int>();

// foreach (string entry in rawLogs)
// {
//     if (visitCounts.ContainsKey(entry))
//     {
//         visitCounts[entry]++;
//     }
//     else
//     {
//         visitCounts[entry] = 1; // Instantiate entry
//     }
// }

// Console.WriteLine("\n--- Frequency Leaderboard ---");
// foreach (var record in visitCounts)
// {
//     Console.WriteLine($"{record.Key} visited {record.Value} times.");
// }



// // ========================================================
// // ZONE 1: RUNNING THE CODE
// // ========================================================
// try
// {
//     Console.WriteLine("--- Starting Transaction ---");
    
//     decimal walletBalance = 50.00m;
//     decimal itemCost = 75.00m;

//     // ✅ FIXED: Added 'BankManager.' so C# knows exactly where to find the method
//     BankManager.ProcessPayment(walletBalance, itemCost);
// }
// catch (InsufficientFundsException ex)
// {
//     Console.WriteLine($"[Payment Error] {ex.Message}");
// }
// catch (Exception ex)
// {
//     // Global fallback catcher for any other unexpected problem
//     Console.WriteLine($"[Unexpected Error] {ex.Message}");
// }
// finally
// {
//     Console.WriteLine("--- Connection Closed Gracefully ---");
// }


// // --- Testing a standard formatting crash protection ---
// try
// {
//     string badInput = "hello";
//     int number = int.Parse(badInput); // Will trigger a FormatException
// }
// catch (FormatException)
// {
//     Console.WriteLine("[System Notice] Handled an invalid text-to-number parse safely.");
// }


// // ========================================================
// // ZONE 2: CUSTOM EXCEPTIONS & METHODS (At the bottom)
// // ========================================================

// public class InsufficientFundsException : Exception
// {
//     public InsufficientFundsException(string message) : base(message) { }
// }

// public static class BankManager
// {
//     public static void ProcessPayment(decimal balance, decimal cost)
//     {
//         if (cost > balance)
//         {
//             // Intentionally trigger our custom domain exception
//             throw new InsufficientFundsException($"Declined: You need ${cost - balance} more to buy this item.");
//         }
//         Console.WriteLine("Payment successful!");
//     }
// }

using System;

Console.WriteLine("=== DATE & TIME PRACTICE LAB ===");

// 1. Working with Absolute Points in Time
DateTimeOffset currentMoment = DateTimeOffset.Now;
Console.WriteLine($"Current Year:        {currentMoment.Year}");
Console.WriteLine($"Day of the Week:     {currentMoment.DayOfWeek}");
Console.WriteLine($"Formatted Cleanly:  {currentMoment.ToString("dd-MMM-yyyy HH:mm:ss")}");

// 2. Performing Time Math (Adding/Subtracting)
DateTimeOffset deadline = currentMoment.AddDays(7).AddHours(2);
Console.WriteLine($"Deadline in 7 days:  {deadline.ToString("f")}");

// 3. Calculating Remaining Time using TimeSpan
DateTimeOffset concertStart = new DateTimeOffset(2027, 12, 25, 20, 0, 0, TimeSpan.FromHours(5.5)); // Dec 25, 2027 at 8 PM IST
TimeSpan timeUntilConcert = concertStart - DateTimeOffset.Now;

Console.WriteLine($"\n--- Countdown to Concert ---");
Console.WriteLine($"Days Remaining:    {timeUntilConcert.Days}");
Console.WriteLine($"Hours Remaining:   {timeUntilConcert.Hours} (partial day calculation)");
Console.WriteLine($"Total Hours Left:  {(int)timeUntilConcert.TotalHours} (absolute calculation)");

// 4. Safely parsing dates from Strings (Text-to-Date conversion)
string manualDateText = "2026-11-04";
if (DateTime.TryParse(manualDateText, out DateTime parsedDate))
{
    Console.WriteLine($"\nSuccessfully parsed \"{manualDateText}\" into a real Date object: {parsedDate.ToShortDateString()}");
}

Console.WriteLine("================================");

#nullable enable
using System;

class Program
{
    static void Main()
    {
        // Nullable Reference Type (Null Safety)
        string? name = null;

        // Null-conditional + Null-coalescing
        Console.WriteLine($"Name Length: {name?.Length ?? 0}");

        // Assign value
        name = "Anch pia";
        Console.WriteLine($"Name Length after assignment: {name?.Length}");

        // Switch Expression
        Console.Write("Enter a number (1-3): ");
        int num = int.Parse(Console.ReadLine());

        string result = num switch
        {
            1 => "One",
            2 => "Two",
            3 => "Three",
            _ => "Invalid Number"
        };

        Console.WriteLine($"Switch Expression Result: {result}");
    }
}

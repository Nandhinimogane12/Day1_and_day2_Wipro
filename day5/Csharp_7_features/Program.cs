using System;

class Program
{
    static void Main()
    {
        // Tuples
        var person = GetPerson();
        Console.WriteLine($"Tuple: Name = {person.Name}, Age = {person.Age}");

        // Pattern Matching
        object obj = person.Age;
        if (obj is int age)
        {
            Console.WriteLine($"Pattern Matching: Age is {age}");
        }

        // Out Variables
        Console.Write("Enter a number: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int number))
        {
            Console.WriteLine($"Out Variable: You entered {number}");

         // Local Function
            int Square(int n)
            {
                return n * n;
            }

            Console.WriteLine($"Local Function: Square = {Square(number)}");
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
    }

    // Tuple Method
    static (string Name, int Age) GetPerson()
    {
        return ("Anch", 22);
    }
}

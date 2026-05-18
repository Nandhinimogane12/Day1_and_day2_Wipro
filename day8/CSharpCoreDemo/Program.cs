using System;
using System.Reflection;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void PrintDetails()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}");
    }
}

// Generic class (US2)
public class Box<T>
{
    public T Value { get; set; }

    public void Display()
    {
        Console.WriteLine("Box Value: " + Value);
    }
}

class Program
{
    // Generic method (US3)
    static void PrintData<T>(T data)
    {
        Console.WriteLine("Generic Method Data: " + data);
    }

    // ref keyword demo (US4)
    static void UpdateValue(ref int number)
    {
        number += 10;
    }

    // out keyword demo (US5)
    static void Calculate(int a, int b, out int sum, out string message)
    {
        sum = a + b;
        message = "Calculation successful!";
    }

    static void Main()
    {
        Console.WriteLine("=== US1: Reflection ===");
        Type type = typeof(Student);
        Console.WriteLine("Class Name: " + type.Name);

        Console.WriteLine("\nProperties:");
        foreach (var prop in type.GetProperties())
            Console.WriteLine(prop.Name);

        Console.WriteLine("\nMethods:");
        foreach (var method in type.GetMethods())
            Console.WriteLine(method.Name);

        Console.WriteLine("\n=== US2: Generics (Class + Field) ===");
        Box<int> intBox = new Box<int> { Value = 100 };
        intBox.Display();

        Box<string> strBox = new Box<string> { Value = "Hello World" };
        strBox.Display();

        Console.WriteLine("\n=== US3: Generics (Method) ===");
        PrintData<int>(42);
        PrintData<string>("Generics in C#");
        PrintData<double>(3.14);

        Console.WriteLine("\n===US4: ref keyword===");
        int value = 5;
        Console.WriteLine("Before: " + value);
        UpdateValue(ref value);
        Console.WriteLine("After: " + value);

        Console.WriteLine("\n=== US5: out keyword ===");
        int result;
        string msg;
        Calculate(10, 20, out result, out msg);
        Console.WriteLine("Sum: " + result);
        Console.WriteLine("Message: " + msg);
    }
}


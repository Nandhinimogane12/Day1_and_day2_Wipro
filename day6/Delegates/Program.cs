using System;

namespace Delegate_Example
{
    // 1. Declare the delegate
    public delegate int MathOperation(int x, int y);

    // 2. Class with methods that match the delegate
    public class Calculate
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }

    class Program
    {
        // 3. Your Main method
        static void Main(string[] args)
        {
            Calculate obj = new Calculate();

            MathOperation operation;

            operation = obj.Add;
            Console.WriteLine("Addition: " + operation(10, 5));

            operation = obj.Subtract;
            Console.WriteLine("Subtraction: " + operation(10, 5));

            operation = obj.Multiply;
            Console.WriteLine("Multiplication: " + operation(10, 5));

            Console.ReadKey();
        }
    }
}
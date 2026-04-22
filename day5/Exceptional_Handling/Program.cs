using System;
class AgeException : Exception
{
    public AgeException(string message) : base(message) { }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter age:");
        int age = Convert.ToInt32(Console.ReadLine());

        try//exception thrown
        {
            if (age < 18)
            {
                throw new AgeException("Age must be 18 or above.");
            }

            Console.WriteLine("Valid age.");
        }
        catch (AgeException ae) //catches the exception
        {
            Console.WriteLine("Error: " + ae.Message);
        }
        finally //will always execute.
        {
            Console.WriteLine("Exceuted");
        }
    }
}

using System;
using System.Collections;

namespace demo4wipro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day4 Collections");
            Console.WriteLine("List");
            List<int> numbers = new List<int>();
            numbers.Add(50);
            numbers.Add(100);
            numbers.Add(2);
            Console.WriteLine("Items in the list: ");
            foreach(int num in numbers)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("Total count: " + numbers.Count);

            Console.WriteLine("Non Generic Collection");

            Stack stack = new Stack();
            stack.Push(1);
            stack.Push("Apple");
            stack.Push("Mango");
            stack.Push(99.5);
            stack.Push(false);
            Console.WriteLine("Length of stack is " + stack.Count);

            Console.WriteLine("removing values from stack:");
            Console.WriteLine("Element removed from stack is " + stack.Pop());

            foreach (object value in stack)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("Stack Length" + stack.Count);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine("Stack Length by adding 2 more elements " + stack.Count);

            Stack stack2 = new Stack();
            stack2.Push(4);
            stack2.Push(5);
            Console.WriteLine("Stack Length after adding 2 elements in stack2 is " + stack.Count);

            Hashtable hashtable = new Hashtable();
            hashtable.Add("name", "Nandhini");
            hashtable.Add("age", 22);
            hashtable.Add("course", "B.Tech");
            hashtable.Add("passed", true);
            hashtable.Add("fees", 80000.0);

            Console.WriteLine("Name: " + hashtable["name"]);
            Console.WriteLine("Age: " + hashtable["age"]);
            Console.WriteLine("Course: " + hashtable["course"]);
            Console.WriteLine("Passed: " + hashtable["passed"]);
            Console.WriteLine("Fees: " + hashtable["fees"]);

            foreach (DictionaryEntry entry in hashtable)
            {
                Console.WriteLine("Key: " + entry.Key + ", Value: " + entry.Value);
            }
        }
    }
}

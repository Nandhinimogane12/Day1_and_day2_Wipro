using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Step 1: Define file paths
        string filepath = "sample.txt";
        string copyPath = "copy.txt";

        try
        {
            // Step 2: Create file
            Console.WriteLine("Creating a file...");
            File.Create(filepath).Close(); // Closing the file is important

            // Step 3: Write data to file
            Console.WriteLine("Writing to the file...");
            File.WriteAllText(filepath, "Hello, this is NandhiniMogane from Puducherry!!");

            // Step 4: Append data to file
            Console.WriteLine("Appending data to the file...");
            File.AppendAllText(filepath, "\nThis data is appended to the text.");

            // Step 5: Read from file
            Console.WriteLine("Reading from the file...");
            string content = File.ReadAllText(filepath);
            Console.WriteLine(content);

            // Step 6: Copy file
            Console.WriteLine("Copying file...");
            File.Copy(filepath, copyPath, true);

            Console.WriteLine("File copied successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

using System;

// User Story 2: Factory Pattern
// Product interface
public interface IDocument
{
    void Open();
    void Save();
}

// Concrete Products
public class PdfDocument : IDocument
{
    public void Open() => Console.WriteLine("Opening PDF Document");
    public void Save() => Console.WriteLine("Saving PDF Document");
}

public class WordDocument : IDocument
{
    public void Open() => Console.WriteLine("Opening Word Document");
    public void Save() => Console.WriteLine("Saving Word Document");
}

// Factory Class - Creates objects without specifying exact class
public class DocumentFactory
{
    // Factory Method: Returns correct type based on input
    public static IDocument CreateDocument(string type)
    {
        switch (type.ToLower())
        {
            case "pdf":
                return new PdfDocument();
            case "word":
                return new WordDocument();
            default:
                throw new ArgumentException($"Document type {type} not supported");
        }
    }
}

// Demo: Client code doesn't use 'new PdfDocument()'
class Program
{
    static void Main()
    {
        // Factory decides which class to create
        IDocument doc1 = DocumentFactory.CreateDocument("pdf");
        doc1.Open();
        doc1.Save();

        Console.WriteLine("---");

        IDocument doc2 = DocumentFactory.CreateDocument("word");
        doc2.Open();
        doc2.Save();

        Console.WriteLine("Factory Demo Complete");
    }
}

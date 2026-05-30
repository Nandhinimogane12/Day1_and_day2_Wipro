using System;

class Book
{
    public string Title;
    public string Author;

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Author: " + Author);
    }
}

class Student
{
    public string Name;
    public int Age;

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void DisplayStudent()
    {
        Console.WriteLine("Student Name: " + Name);
        Console.WriteLine("Student Age: " + Age);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Book object
        Book myBook = new Book("Ponniyin Selvan", "Kalki");
        myBook.DisplayInfo();

        Console.WriteLine();

        // Student object
        Student s1 = new Student("Nandhini", 21);
        s1.DisplayStudent();
        Console.ReadLine();
    }
}




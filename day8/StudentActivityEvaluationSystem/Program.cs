using System;
using System.Collections.Generic;

class Student
{
    public string Name;
    public int Marks;
    public int Attendance;
    public int Participation;

    public Student(string name, int marks, int attendance, int participation)
    {
        Name = name;
        Marks = marks;
        Attendance = attendance;
        Participation = participation;
    }
}

class Program
{
    // Delegate for student evaluation
    delegate void StudentEvaluation(Student s);

    static void Main()
    {
        // List of students
        List<Student> students = new List<Student>()
        {
            new Student("Virat", 75, 90, 8),
            new Student("Anch", 45, 80, 6),
            new Student("Pia", 60, 95, 9),
            new Student("Dhoni", 38, 70, 5)
        };

        // Anonymous Method for total marks and performance display
        StudentEvaluation evaluateStudent = delegate (Student s)
        {
            int total = s.Marks + s.Attendance + s.Participation;

            Console.WriteLine("Student Name: " + s.Name);
            Console.WriteLine("Marks: " + s.Marks);
            Console.WriteLine("Attendance: " + s.Attendance);
            Console.WriteLine("Participation: " + s.Participation);
            Console.WriteLine("Total Score: " + total);

            if (total > 150)
                Console.WriteLine("Performance: Excellent");
            else if (total > 100)
                Console.WriteLine("Performance: Good");
            else
                Console.WriteLine("Performance: Average");

            Console.WriteLine();
        };

        Console.WriteLine("Student Performance Evaluation");
        Console.WriteLine("------------------------------");

        // Calling anonymous method
        foreach (Student s in students)
        {
            evaluateStudent(s);
        }

        // Lambda Expression to check eligibility
        Func<Student, bool> isEligible = s => s.Marks > 50;

        Console.WriteLine("Eligible Students (Marks > 50)");
        Console.WriteLine("-------------------------------");

        // Lambda Expression to filter students
        List<Student> eligibleStudents = students.FindAll(s => s.Marks > 50);

        foreach (Student s in eligibleStudents)
        {
            Console.WriteLine(s.Name + " - Marks: " + s.Marks);
        }
    }
}

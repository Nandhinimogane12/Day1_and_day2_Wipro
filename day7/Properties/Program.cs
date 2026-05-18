using System;

class Person
{
    private int _age;

    public int Age
    {
        get { return _age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age cannot be negative.");
            }
            _age = value;
        }
    }
}

class Employee
{
    private decimal _salary;

    public decimal Salary
    {
        get { return _salary; }
        set
        {
            if (value < 18000)
            {
                throw new ArgumentException("Salary cannot be less than minimum wage.");
            }
            _salary = value;
        }
    }
}

class Program
{
    static void Main()
    {
        // Person object
        Person person = new Person();
        person.Age = 22;
        Console.WriteLine("Person Age: " + person.Age);

        // Employee object
        Employee employee = new Employee();
        employee.Salary = 55000;
        Console.WriteLine("Employee Salary: " + employee.Salary);
    }
}

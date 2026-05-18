using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("===== Student Dashboard Loading System =====");

        try
        {
            Console.WriteLine("Loading data... Please wait\n");

            // Run all tasks at the same time
            Task<string> studentTask = GetStudentDetailsAsync();
            Task<string> marksTask = GetMarksAsync();
            Task<string> attendanceTask = GetAttendanceAsync();

            // Wait for all tasks to complete
            await Task.WhenAll(studentTask, marksTask, attendanceTask);

            // Display results
            Console.WriteLine("\n===== Student Information =====");
            Console.WriteLine(await studentTask);

            Console.WriteLine("\n===== Marks Details =====");
            Console.WriteLine(await marksTask);

            Console.WriteLine("\n===== Attendance Details =====");
            Console.WriteLine(await attendanceTask);

            Console.WriteLine("\nAll data loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        Console.ReadLine();
    }

    // Async method for student details
    static async Task<string> GetStudentDetailsAsync()
    {
        await Task.Delay(2000); // Simulated delay
        return "Name: Nandhini\nDepartment: CSE\nYear: Final Year";
    }

    // Async method for marks
    static async Task<string> GetMarksAsync()
    {
        await Task.Delay(2000); // Simulated delay
        return "Maths: 85\nScience: 90\nEnglish: 88";
    }

    // Async method for attendance
    static async Task<string> GetAttendanceAsync()
    {
        await Task.Delay(2000); // Simulated delay
        return "Attendance Percentage: 92%";
    }
}
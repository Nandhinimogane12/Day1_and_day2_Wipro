using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class User
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
}

class Program
{
    static List<User> users = new List<User>();
    static string logFile = "log.txt";

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n===== Secure Login & Logging System =====");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    RegisterUser();
                    break;

                case 2:
                    LoginUser();
                    break;

                case 3:
                    Console.WriteLine("Exiting program...");
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

    static void RegisterUser()
    {
        try
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Console.Write("Enter Role (Admin/User): ");
            string role = Console.ReadLine();

            string hashedPassword = HashPassword(password);

            users.Add(new User
            {
                Username = username,
                PasswordHash = hashedPassword,
                Role = role
            });

            Console.WriteLine("User Registered Successfully!");
            LogActivity(username + " registered successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            LogActivity("Registration Error: " + ex.Message);
        }
    }

    static void LoginUser()
    {
        try
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            string hashedPassword = HashPassword(password);

            User foundUser = users.Find(u =>
                u.Username == username &&
                u.PasswordHash == hashedPassword);

            if (foundUser != null)
            {
                Console.WriteLine("Login Successful!");
                Console.WriteLine("Role: " + foundUser.Role);

                if (foundUser.Role.ToLower() == "admin")
                {
                    Console.WriteLine("Welcome Admin! Full Access Granted.");
                }
                else
                {
                    Console.WriteLine("Welcome User! Limited Access Granted.");
                }

                LogActivity(username + " logged in successfully.");
            }
            else
            {
                Console.WriteLine("Invalid Username or Password!");
                LogActivity("Failed login attempt for " + username);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            LogActivity("Login Error: " + ex.Message);
        }
    }

    static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();

            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }
    }

    static void LogActivity(string message)
    {
        File.AppendAllText(logFile,
            DateTime.Now + " : " + message + Environment.NewLine);
    }
}
